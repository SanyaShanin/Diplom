using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;


namespace SpinWaveToolsFramework
{
    public class InstrumentStatus
    {
        public bool connected = false;
        public bool validate = false;
        public string error = "";
        public string response = "";

        public bool status
        {
            get
            {
                return error == "";
            }
        }

        override public string ToString()
        {
            return (connected ? "Connected;" : "") + (validate ? "Validated;" : "") + (error != "" ? "Error: " + error : "Response: " + response);
        }
    }
    public class InstrumentInterface : IDisposable
    {
        public static string name = "";
        public IInstrument instance = null;
        static IInstrument instance_checking = null;
        public string host
        {
            get
            {
                return instance != null ? instance.host() : "";
            }
        }
        public bool IsOpen
        {
            get
            {
                return instance == null ? false : instance.IsOpen;
            }
        }
        public static bool Reached { get; set; }
        public virtual IInstrument Connect(string host)
        {
            return null;
        }
        public void Open(string host)
        {
            try
            {
                instance = Connect(host);
                CLS();
                Reached = true;
            } 
            catch
            {
                Reached = false;
            }
        }
        public void Close(string host)
        {
            if (!IsOpen)
            {
                instance.Dispose();
                instance = null;
            }
        }
        public void Write(string command, Action<string> callback = null)
        {
            if (IsOpen)
            {
                instance.Write(command, callback);
            }
        }
        public string WriteRead(string command)
        {
            string answer = "";
            if (IsOpen)
            {
                instance.Write(command, (a) =>
                {
                    answer = a;
                        
                });
            }
            return answer;
        }
        public double WriteReadDouble(string command)
        {
            if (!IsOpen) return 0;
            var answer = WriteRead(command);
            var styles = NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands |
               NumberStyles.AllowExponent;
            var provider = CultureInfo.CreateSpecificCulture("en-GB");
            if (answer[0] == '+')
                answer = answer.Remove(0, 1);
            return Double.Parse(answer, styles, provider);
        }
        public string IDN()
        {
            return WriteRead("*IDN?");
        }
        public string OPC()
        {
            return WriteRead("*OPC?");
        }
        public void CLS()
        {
            Write("*CLS");
        }
        public string ERROR()
        {
            return WriteRead("SYST:ERR?");
        }
        public void Init()
        {
            
        }
        public void ShutDown()
        {

        }
        public void Dispose()
        {
            ShutDown();
            instance?.Dispose();
        }
        public async Task<InstrumentStatus> CheckStatus(string host)
        {
            if (instance_checking != null)
                instance_checking.Dispose();

            var status = new InstrumentStatus();
            try
            {
                await Task.Run(() =>
                {
                    instance_checking = Connect(host);
                    instance_checking.Write("*IDN?", (answer) =>
                    {
                        if (answer.Contains(name))
                        {
                            status.validate = true;
                            status.response = answer;
                        }
                        else
                            status.error = "Wrong instrument: " + answer + ", " + name + " excepted!";
                    });
                });
            }
            catch(Exception e)
            {
                status.error = e.Message;
            }
            Reached = status.status;
            return status;
        }
    }
    public class VNA : InstrumentInterface
    {
        public static new string name = "M9374A";
        public enum SaveFormat
        {
            AUTO,
            MA,
            RI,
            DB
        }
        public enum CalcParameter
        {
            OFF,
            S11,
            S12,
            S21,
            S22
        }
        public enum DataFormat
        {
            MLOG,
            PHAS,
            GDEL,
            SLIN,
            SLOG,
            SCOM,
            SMIT,
            SADM,
            PLIN,
            PLOG,
            POL ,
            MLIN,
            SWR ,
            REAL,
            IMAG,
            UPH ,
            PPH
        }
        public enum Trigger
        {
            HOLD,
            CONT,
            GRO,
            SING
        }
        public override IInstrument Connect(string host)
        {
            var connect = new Hislip();
            connect.Open(host);
            return connect;
        }
        public void SetSelectedMeasurement()
        {
            Write("CALC1:PAR:MNUM 1");
        }
        public void SetFreqPoints(double start, double stop, int points)
        {
            string sStart = (start * 1000000).ToString(CultureInfo.InvariantCulture);
            string sStop  = (stop  * 1000000).ToString(CultureInfo.InvariantCulture);
            Write("SENS:FREQ:STAR " + sStart + ";STOP " + sStop + ";:SENS:SWE:POIN " + points);
        }
        public void SetBandwidth(int bandwidth)
        {
            Write("SENS:BWID " + bandwidth);
        }
        public void SetPowerLevel(double power)
        {
            Write("SOUR1:POW1:LEVel:IMMediate:AMPLitude " + power);
        }
        public void SelectMeasurement(string name)
        {
            Write(String.Format(":CALC:PAR:SEL '{0}';", name));
        }
        public void ConfigMeasurements(List<CalcParameter> calcs, List<DataFormat> formats)
        {
            string command =  ":DISP:WIND1:ENAB 1;" +
                              ":CALC:PAR:COUN 0;";

            int index = 1;
            for(var i = 0; i < calcs.Count; i++)
            {
                var calc = calcs[i];
                var format = formats[i];
                var name = calc.ToString() + "_" + format.ToString();

                if (calc == CalcParameter.OFF)
                    continue;

                command += String.Format(":CALC:PAR:EXT '{0}', '{1}';" +
                                         ":DISP:WIND:TRAC{2}:FEED '{0}';" +
                                         ":CALC:PAR:SEL '{0}';" +
                                         ":CALC:FORM {3};", new string[] { name, calc.ToString(), index.ToString(), format.ToString() });
                index++;
            }

            Write(command);
        }
        public void SetTrigger(Trigger trigger)
        {
            Write("SENS:SWE:MODE " + trigger);
        }
        public Trigger GetTrigger()
        {
            try
            {
                return (Trigger)Enum.Parse(typeof(Trigger), WriteRead("SENS:SWE:MODE?"), true);
            } catch
            {
                return Trigger.GRO;
            }
        }
        public void DataSave(string filename, string format)
        {
            if (format != null)
                Write("MMEM:STOR:TRAC:FORM:SNP " + format);
            Write(String.Format("CALC1:DATA:SNP:PORT:SAVE '1,2','{0}'", filename));
        }
        public string DataFlow(string filename)
        {
            var answer = WriteRead(string.Format(":MMEM:TRAN? '{0}'", filename)).Remove(0, 1);
            while("0123456789".Contains(answer[0]))
            {
                answer = answer.Remove(0, 1);
            }
            return answer;
        }
        public string MeasurementGetData(string type = "FDATA")
        {
            return WriteRead("CALC1:DATA? FDATA");
        }
    }
    public class PowerSupply : InstrumentInterface
    {
        public static new string name = "N6745A";
        public override IInstrument Connect(string host)
        {
            var connect = new TelnetConnection();
            connect.Open(host);
            return connect;
        }
        public new void Init()
        {
            Init(20, 25);
        }
        public void Init(double voltage_limit, double voltage_protection)
        {
            VoltageLimitSet(voltage_limit);
            VoltageProtectionSet(voltage_protection);
        }
        public new void ShutDown()
        {
            OutputSet(false);
        }
        public double MeasureCurrent()
        {
            return WriteReadDouble("MEAS:CURR?");
        }
        public double MeasureVoltage()
        {
            return WriteReadDouble("MEAS:VOLT?");
        }
        public double VoltageProtectionGet()
        {
            return WriteReadDouble("VOLT:PROT:LEV?");
        }
        public void VoltageProtectionSet(double protection)
        {
            Write("VOLT:PROT:LEV " + protection.ToString(CultureInfo.InvariantCulture));
        }
        public double VoltageLimitGet()
        {
            return WriteReadDouble("VOLT?");
        }
        public void VoltageLimitSet(double limit)
        {
            Write("VOLT " + limit.ToString(CultureInfo.InvariantCulture));
        }
        public double CurrentGet()
        {
            return WriteReadDouble("CURR?");
        }
        public void CurrentSet(double current)
        {
            Write("CURR " + current.ToString(CultureInfo.InvariantCulture));
        }
        public double VoltageGet()
        {
            return WriteReadDouble("MEAS:VOLT?");
        }
        public bool OutputGet()
        {
            return WriteRead("OUTP?") == "1";
        }
        public void OutputSet(bool status)
        {
            Write("OUTP " + (status ? "ON" : "OFF"));
        }
        public void SafeCurrentSet(double current, int cycles = 4, int sleep = 750)
        {
            if (current == 0)
            {
                OutputSet(false);
                return;
            }
            CurrentSet(current);
            for(var i = 0; i < cycles; i++)
            {
                OutputSet(false);
                Thread.Sleep(sleep);
                OutputSet(true);
                Thread.Sleep(sleep);
            }
        }
    }
}
