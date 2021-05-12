using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpinWaveTool
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
    public class InstrumentInterface
    {
        public static string name = "";
        public static IInstrument instance = null;
        static IInstrument instance_checking = null;
        public static bool IsOpen
        {
            get
            {
                return instance == null ? false : instance.IsOpen;
            }
        }
        public static bool Reached { get; set; }
        static IInstrument Connect(string host)
        {
            return null;
        }
        public static void Open(string host)
        {
            try
            {
                instance = Connect(host);
                Reached = true;
            } 
            catch
            {
                Reached = false;
            }
        }
        public static void Close(string host)
        {
            if (!IsOpen)
            {
                instance.Dispose();
                instance = null;
            }
        }
        public static void Write(string command, Action<string> callback = null)
        {
            if (IsOpen)
            {
                instance.Write(command, callback);
            }
        }
        public static string WriteRead(string command)
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
        public static double WriteReadDouble(string command)
        {
            if (!IsOpen) return 0;
            return Convert.ToDouble(WriteRead(command));
        }
        public static string IDN()
        {
            return WriteRead("*IDN?");
        }
        public static string OPC()
        {
            return WriteRead("*OPC?");
        }
        public static void CLS()
        {
            Write("*CLS");
        }
        public static string ERROR()
        {
            return WriteRead("SYST:ERR?");
        }
        public static void CheckStatus(string host, Action<InstrumentStatus> callback)
        {
            if (instance_checking != null)
                instance_checking.Dispose();

            var status = new InstrumentStatus();
            try
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
            }
            catch(Exception e)
            {
                status.error = e.Message;
            }
            Reached = status.status;
            callback(status);
        }
    }
    public class VNA : InstrumentInterface
    {
        public static new string name = "M9374A";
        
        
    }

    public class PowerSupply : InstrumentInterface
    {
        public static new string name = "N6745A";
        
        public static double MeasureCurrent()
        {
            return WriteReadDouble("MEAS:CURR?");
        }
        public static double MeasureVoltage()
        {
            return WriteReadDouble("MEAS:VOLT?");
        }
        public static double VoltageProtectionGet()
        {
            return WriteReadDouble("VOLT:PROT:LEV?");
        }
        public static void VoltageProtectionSet(double protection)
        {
            Write("VOLT:PROT:LEV " + protection);
        }
        public static double VoltageLimitGet()
        {
            return WriteReadDouble("VOLT?");
        }
        public static void VoltageLimitSet(double limit)
        {
            Write("VOLT " + limit);
        }
        public static double CurrentGet()
        {
            return WriteReadDouble("CURR?");
        }
        public static void CurrentSet(double current)
        {
            Write("CURR " + current);
        }
        public static bool OutputGet()
        {
            return WriteRead("VOLT?") == "1";
        }
        public static void OutputSet(bool status)
        {
            Write("VOLT " + (status ? "ON" : "OFF"));
        }

        public static void SafeCurrentSet(double current)
        {
            CurrentSet(current);
            for(var i = 0; i < 4; i++)
            {
                OutputSet(false);
                OutputSet(true);
            }
        }
    }
}
