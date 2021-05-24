using System;
using System.Globalization;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IniParser;
using IniParser.Model;

//<div>Автор иконок: <a href="https://smashicons.com/" title="Smashicons">Smashicons</a> from <a href="https://www.flaticon.com/ru/" title="Flaticon">www.flaticon.com</a></div>
namespace SpinWaveToolsFramework
{
    public class Measurement : IDisposable
    {
        public enum State
        {
            Disable,
            Connecting,
            Starting,
            Processing,
            Analysis,
            Ending
        }
        public enum ProcessState
        {
            Nothing,
            PowerSupply,
            VNA,
            Waiting
        }
        public PowerSupply powerSupply = new PowerSupply();
        public VNA vna = new VNA();
        public State state = State.Disable;
        public ProcessState processState = ProcessState.PowerSupply;
        public int timer = 0;
        public Data data = new Data();
        public string addressPowerSupply;
        public string addressVNA;
        public void TryToConnect()
        {
            if (powerSupply == null)
            {
                powerSupply = new PowerSupply();
            }
            if (!powerSupply.IsOpen || powerSupply.host != addressPowerSupply)
            {
                powerSupply.Dispose();
                powerSupply.Open(addressPowerSupply);
            }
            
            if (vna == null)
            {
                vna = new VNA();
            }
            if (!vna.IsOpen || vna.host != addressVNA)
            {
                vna.Dispose();
                vna.Open(addressVNA);
            }
        }
        public async Task Start() 
        {
            state = State.Connecting;

            TryToConnect();

            state = State.Starting;

            if (powerSupply.IsOpen)
            {
                Task taskPowerSupply = Task.Run(() =>
                {
                    powerSupply.CLS();
                    powerSupply.Init(data.ps_protection, data.ps_protection);
                });
                await taskPowerSupply;
            }
            Task taskVNA = Task.Run(() =>
            {
                vna.CLS();
                vna.Init();
            });

            await taskVNA;

            if (!vna.IsOpen)
            {
                await End();
                return;
            }

            await Task.Run(() =>
            {
                vna.SetBandwidth(data.bandwidth);
                vna.SetSelectedMeasurement();
                vna.SetFreqPoints(data.freq_start, data.freq_end, data.freq_points);
                vna.SetPowerLevel(data.power);
                vna.ConfigMeasurements(data.parameters, data.formats);
            });

            state = State.Processing;
            Process();
        }
        private async void Process()
        {
            int stepCount = powerSupply.IsOpen ? data.field_points : 1;
            List<string> files = new List<string>();

            for(var i = 0; i < stepCount; i++)
            {
                double currentField = powerSupply.IsOpen ? data.field_start + data.field_step * i : 0;

                if (powerSupply.IsOpen)
                {
                    processState = ProcessState.PowerSupply;
                    await Task.Run(() => powerSupply.SafeCurrentSet(currentField, data.reloads, data.reload_delay));
                }

                if (state != State.Processing) return;

                await Task.Run(() =>
                {
                    processState = ProcessState.VNA;
                    vna.SetTrigger(VNA.Trigger.SING);

                    while(vna.GetTrigger() != VNA.Trigger.HOLD)
                    {
                        if (state != State.Processing) return;
                        Thread.Sleep(100);
                    }

                    if (state != State.Processing) return;

                    string filename = GetMeasurementName(data.filePath, data.fileExt, currentField);
                    vna.DataSave(filename, data.saveFormat.ToString());
                    vna.OPC();

                    if (data.duplicate)
                    {
                        string content = vna.DataFlow(filename);
                        string name = Path.GetFileName(filename);
                        string newname = data.duplicate_path + name;
                        SaveLocal(data.duplicate_path, name, content);
                        files.Add(newname);
                    }
                });

                if (state != State.Processing) return;

                processState = ProcessState.Waiting;
                timer = data.measure_delay;
                DateTime delay = DateTime.Now.AddSeconds(timer);
                powerSupply.OutputSet(false);
                if (i != stepCount - 1)
                {
                    await Task.Run(() =>
                    {
                        while (processState == ProcessState.Waiting && timer > 0)
                        {
                            timer = (int)(delay - DateTime.Now).TotalSeconds;
                        }
                    });
                }
            }

            if (state != State.Processing) return;

            processState = ProcessState.Nothing;
            if (files.Count > 1 && data.MakeCorVersion) {
                state = State.Analysis;
                for (var i = 0; i < files.Count; i++)
                {
                    string  A = files[i], 
                            B = files[i > files.Count/2 ? 0 : files.Count - 1];
                    try
                    {
                        MathWorker.DoWork(A, B, A + "_cor", "!Operation: " + A + " - " + B + "\r\n");
                    }
                    catch { }
                }
            }
            await End();
        }
        public async Task End()
        {
            state = State.Ending;
            processState = ProcessState.Nothing;

            await Task.Run(() => {
                if (powerSupply.IsOpen)
                {
                    powerSupply.OutputSet(false);
                }
                vna.SetTrigger(VNA.Trigger.HOLD);
            });

            state = State.Disable;
        }
        string GetMeasurementName(string filename, string extension, double power)
        {
            string powerValue = power.ToString(CultureInfo.InvariantCulture);
            
            bool addpoint = false;
            if (powerValue.Length == 1)
                addpoint = true;
            else if (powerValue[powerValue.Length - 2] != '.')
                addpoint = true;

            if (addpoint) powerValue += ".0";

            if (filename.Contains("{I}"))
            {
                filename = filename.Replace("{I}", powerValue);
            } else
            {
                filename += powerValue;
            }

            filename += extension;
            return filename;
        }
        void SaveLocal(string location, string name, string content)
        {
            if (!Directory.Exists(location))
            {
                Directory.CreateDirectory(location);
            }

            File.WriteAllText(location + name, content);
        }
        public void Dispose()
        {
            vna?.Dispose();
            powerSupply?.Dispose();
        }

        public class Data
        {
            public List<VNA.CalcParameter> parameters = new List<VNA.CalcParameter> { VNA.CalcParameter.S11, VNA.CalcParameter.S12, VNA.CalcParameter.OFF, VNA.CalcParameter.OFF, VNA.CalcParameter.OFF, VNA.CalcParameter.OFF, VNA.CalcParameter.OFF, VNA.CalcParameter.OFF };
            public List<VNA.DataFormat> formats = new List<VNA.DataFormat> { VNA.DataFormat.MLOG, VNA.DataFormat.MLOG, VNA.DataFormat.MLOG, VNA.DataFormat.MLOG, VNA.DataFormat.MLOG, VNA.DataFormat.MLOG, VNA.DataFormat.MLOG, VNA.DataFormat.MLOG };

            public bool MakeCorVersion = false;

            public bool duplicate = true;
            public string duplicate_path = "D:/Measurements/";

            public double field_start
            {
                set
                {
                    _field_start = value;
                    _field_end = Math.Max(field_start, field_end);
                }
                get
                {
                    return _field_start;
                }
            }
            double _field_start = 1;
            
            public double field_end
            {
                set
                {
                    _field_end = Math.Max(0, value);
                    _field_start = Math.Min(field_end, field_start);
                }
                get
                {
                    return _field_end;
                }
            }
            double _field_end = 2;
            
            public int field_points
            {
                set
                {
                    _field_points = Math.Max(value, 1);
                }
                get
                {
                    return _field_points;
                }
            }
            int _field_points = 2;
            public double field_step
            {
                set
                {
                    if (field_points == 0)
                        return;
                    field_points = (int)((field_end - field_start) / value + 1);
                }
                get
                {
                    if (field_points <= 1)
                        return 0;
                    return (field_end - field_start) / (field_points - 1);
                }
            }

            public int ps_protection
            {
                set
                {
                    _ps_protection = value;
                    _ps_limit = Math.Min(ps_protection - 1, ps_limit);
                }
                get
                {
                    return _ps_protection;
                }
            }
            int _ps_protection = 25;
            public int ps_limit
            {
                set
                {
                    _ps_limit = value;
                    _ps_protection = Math.Max(ps_limit + 1, ps_protection);
                }
                get
                {
                    return _ps_limit;
                }
            }
            int _ps_limit = 20;

            public double freq_start
            {
                set
                {
                    _freq_start = Math.Max(0.01, value);
                    _freq_end = Math.Max(freq_start, freq_end);
                }
                get
                {
                    return _freq_start;
                }
            }
            double _freq_start = 1;
            public double freq_end
            {
                set
                {
                    _freq_end = Math.Max(0.01, value);
                    _freq_start = Math.Min(freq_start, freq_end);
                }
                get
                {
                    return _freq_end;
                }
            }
            double _freq_end = 1.5;
            public int freq_points
            {
                set
                {
                    _freq_points = Math.Max(value, 1);
                }
                get
                {
                    return _freq_points;
                }
            }
            int _freq_points = 500;
            public double freq_step
            {
                set
                {
                    if (freq_step == 0)
                        return;
                    freq_points = (int)((freq_end - freq_start) / value + 1);
                }
                get
                {
                    if (freq_points <= 1)
                        return 0;
                    return (freq_end - freq_start) / (freq_points - 1);
                }
            }
            public int bandwidth
            {
                set
                {
                    _bandwidth = Math.Max(1, Math.Min(value, 99999));
                }
                get
                {
                    return _bandwidth;
                }
            }
            int _bandwidth = 75;
            public int power
            {
                set
                {
                    _power = Math.Max(value, -43);
                }
                get
                {
                    return _power;
                }
            }
            int _power = 0;
            public VNA.SaveFormat saveFormat = VNA.SaveFormat.RI;

            public int reloads
            {
                set
                {
                    _reloads = Clamp(value, 1, 16);
                }
                get
                {
                    return _reloads;
                }
            }
            int _reloads = 4;
            public int reload_delay
            {
                set
                {
                    _reload_delay = Clamp(value, 50, 9999);
                }
                get
                {
                    return _reload_delay;
                }
            }
            int _reload_delay = 750;

            public int measure_delay = 30;

            private int Clamp(int value, int min, int max)
            {
                return Math.Max(min, Math.Min(value, max));
            }

            public string filePath = "C:\\NA_Measurements\\Temp\\test_new_";
            public string fileExt = ".s2p";

            public void SetParameter(int index, VNA.CalcParameter parameter, VNA.DataFormat format)
            {
                parameters[index] = parameter;
                formats[index] = format;
            }
            public KeyValuePair<VNA.CalcParameter, VNA.DataFormat> GetParameter(int index)
            {
                return new KeyValuePair<VNA.CalcParameter, VNA.DataFormat>(parameters[index], formats[index]);
            }
            
            public void Save(string file)
            {
                var data = new IniData();
                data["powerSupply"]["start"] = field_start.ToString();
                data["powerSupply"]["end"] = field_end.ToString();
                data["powerSupply"]["points"] = field_points.ToString();
                data["powerSupply"]["protection"] = ps_protection.ToString();
                data["powerSupply"]["limit"] = ps_limit.ToString();
                data["powerSupply"]["reloads"] = reloads.ToString();
                data["powerSupply"]["reloadDelay"] = reload_delay.ToString();

                data["vna"]["start"] = freq_start.ToString();
                data["vna"]["end"] = freq_end.ToString();
                data["vna"]["points"] = freq_points.ToString();
                data["vna"]["bandwidth"] = bandwidth.ToString();
                data["vna"]["power"] = power.ToString();
                data["vna"]["format"] = saveFormat.ToString();
                for(var i = 0; i < 8; i++)
                {
                    var parameter = GetParameter(i);
                    data["vna"]["parameter_" + i] = parameter.Key.ToString();
                    data["vna"]["format_" + i] = parameter.Value.ToString();
                }

                data["settings"]["path"] = filePath;
                data["settings"]["ext"] = fileExt;
                data["settings"]["duplicate"] = duplicate ? "on" : "off";
                data["settings"]["duplicate_path"] = duplicate_path;
                data["settings"]["make_cor"] = MakeCorVersion ? "on" : "off";
                File.WriteAllText(file, data.ToString());
            }
            public void Load(string file)
            {
                if (!File.Exists(file))
                    return;

                var data = new IniParser.FileIniDataParser().ReadFile(file);
                field_start = Convert.ToDouble(data["powerSupply"]["start"]);
                field_end = Convert.ToDouble(data["powerSupply"]["end"]);
                field_points = Convert.ToInt32(data["powerSupply"]["points"]);
                ps_protection = Convert.ToInt32(data["powerSupply"]["protection"]);
                ps_limit = Convert.ToInt32(data["powerSupply"]["limit"]);
                reloads = Convert.ToInt32(data["powerSupply"]["reloads"]);
                reload_delay = Convert.ToInt32(data["powerSupply"]["reloadDelay"]);

                freq_start = Convert.ToDouble(data["vna"]["start"]);
                freq_end = Convert.ToDouble(data["vna"]["end"]);
                freq_points = Convert.ToInt32(data["vna"]["points"]);
                bandwidth = Convert.ToInt32(data["vna"]["bandwidth"]);
                power = Convert.ToInt32(data["vna"]["power"]);
                saveFormat = (VNA.SaveFormat)Enum.Parse(typeof(VNA.SaveFormat), data["vna"]["format"], true);
                for (var i = 0; i < 8; i++)
                {
                    var parameter = (VNA.CalcParameter)Enum.Parse(typeof(VNA.CalcParameter), data["vna"]["parameter_" + i], true);
                    var format = (VNA.DataFormat)Enum.Parse(typeof(VNA.DataFormat), data["vna"]["format_" + i], true);
                    SetParameter(i, parameter, format);
                }

                filePath = data["settings"]["path"];
                fileExt = data["settings"]["ext"];
                duplicate = data["settings"]["duplicate"] == "on";
                duplicate_path = data["settings"]["duplicate_path"];
                MakeCorVersion = data["settings"]["make_cor"] == "on";
            }
        }
    }
}
