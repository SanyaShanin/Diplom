using System;
using System.IO;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace SpinWaveToolsFramework
{
    public partial class MainForm : Form
    {
        Measurement measurement = new Measurement();
        public MainForm()
        {
            InitializeComponent();
            instance = this;
        }
        public static MainForm instance;
        public void Log(string message)
        {
            string all = "";
            if (File.Exists("logger.txt"))
            {
                all = File.ReadAllText("logger.txt");
            }
            all += "\n" + message;
            File.WriteAllText("logger.txt", all);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            CheckInstruments();
            StatusUpdater();
            UpdateData();
        }
        private void address_power_supply_TextChanged(object sender, EventArgs e)
        {
            CheckInstruments();
        }
        private void address_vna_TextChanged(object sender, EventArgs e)
        {
            measurement.addressVNA = ((TextBox)sender).Text;
            CheckInstruments();
        }

        private long lastInstrumentUpdate = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            CheckInstruments();
        }
        
        private int ParseInt(string input, int def)
        {
            int output = def;
            try
            {
                output = int.Parse(input, CultureInfo.InvariantCulture);
            }
            catch { }
            return output;
        }
        private double ParseDouble(string input, double def)
        {
            double output = def;
            try
            {
                output = double.Parse(input, CultureInfo.InvariantCulture);
            }
            catch {}
            return output;
        }

        private void OnAccept(object sender, KeyPressEventArgs args)
        {
            if (args.KeyChar == '\r')
                ChangeReact(sender, new EventArgs());
        }
        bool sendEvent = true;
        private void ChangeReact(object sender, EventArgs args)
        {
            if (!sendEvent) return;

            var data = measurement.data;
            var textBox = sender as TextBox;
            var text = textBox.Text;

            switch (textBox.Name)
            {
                case "bFieldEnd":           data.field_end = ParseDouble(text, data.field_end); break;
                case "bFieldStart":         data.field_start = ParseDouble(text, data.field_start); break;
                case "bFieldPoints":        data.field_points = ParseInt(text, data.field_points); break;
                case "bFieldStep":          data.field_step = ParseDouble(text, data.field_step); break;
                
                case "bRestartCount":       data.reloads = ParseInt(text, data.reloads); break;
                case "bRestartsDelay":      data.reload_delay = ParseInt(text, data.reload_delay); break;
                case "bVoltageLimit":       data.ps_limit = ParseInt(text, data.ps_limit); break;
                case "bVoltageProtection":  data.ps_protection = ParseInt(text, data.ps_protection); break;
                
                case "bFreqStart":          data.freq_start = ParseDouble(text, data.freq_start); break;
                case "bFreqEnd":            data.freq_end = ParseDouble(text, data.freq_end); break;
                case "bFreqPoints":         data.freq_points = ParseInt(text, data.freq_points); break;
                case "bFreqStep":           data.freq_step = ParseDouble(text, data.freq_step); break;
                
                case "vnaBand":             data.bandwidth = ParseInt(text, data.bandwidth); break;
                case "vnaPower":            data.power = ParseInt(text, data.power); break;
                
                case "bFilePath":           data.filePath = text; break;
                case "bFileExt":            data.fileExt = text; break;

                case "bDuplicate":          data.duplicate_path = text; break;
                
                case "bMeasDelay":          data.measure_delay = ParseInt(text, data.measure_delay); break;
            }
            UpdateData();
        }
        private void UpdateData()
        {
            sendEvent = false;
            bFieldEnd.Text          = measurement.data.field_end    .ToString(CultureInfo.InvariantCulture);
            bFieldStart.Text        = measurement.data.field_start  .ToString(CultureInfo.InvariantCulture);
            bFieldPoints.Text       = measurement.data.field_points .ToString(CultureInfo.InvariantCulture);
            bFieldStep.Text         = measurement.data.field_step   .ToString(CultureInfo.InvariantCulture);
            
            bRestartCount.Text      = measurement.data.reloads      .ToString(CultureInfo.InvariantCulture);
            bRestartsDelay.Text     = measurement.data.reload_delay .ToString(CultureInfo.InvariantCulture);
            bVoltageLimit.Text      = measurement.data.ps_limit     .ToString(CultureInfo.InvariantCulture);
            bVoltageProtection.Text = measurement.data.ps_protection.ToString(CultureInfo.InvariantCulture);

            bFreqStart.Text         = measurement.data.freq_start   .ToString(CultureInfo.InvariantCulture);
            bFreqEnd.Text           = measurement.data.freq_end     .ToString(CultureInfo.InvariantCulture);
            bFreqPoints.Text        = measurement.data.freq_points  .ToString(CultureInfo.InvariantCulture);
            bFreqStep.Text          = measurement.data.freq_step    .ToString(CultureInfo.InvariantCulture);

            vnaBand.Text            = measurement.data.bandwidth    .ToString(CultureInfo.InvariantCulture);
            vnaPower.Text           = measurement.data.power        .ToString(CultureInfo.InvariantCulture);
            
            bMeasDelay.Text         = measurement.data.measure_delay.ToString(CultureInfo.InvariantCulture);

            var value = (int)measurement.data.GetParameter(0).Key;
            sour1   .SelectedIndex  = (int)measurement.data.GetParameter(0).Key;
            format1 .SelectedIndex  = (int)measurement.data.GetParameter(0).Value;

            sour2   .SelectedIndex  = (int)measurement.data.GetParameter(1).Key;
            format2 .SelectedIndex  = (int)measurement.data.GetParameter(1).Value;

            sour3   .SelectedIndex  = (int)measurement.data.GetParameter(2).Key;
            format3 .SelectedIndex  = (int)measurement.data.GetParameter(2).Value;

            sour4   .SelectedIndex  = (int)measurement.data.GetParameter(3).Key;
            format4 .SelectedIndex  = (int)measurement.data.GetParameter(3).Value;

            sour5.SelectedIndex     = (int)measurement.data.GetParameter(4).Key;
            format5.SelectedIndex   = (int)measurement.data.GetParameter(4).Value;

            sour6.SelectedIndex     = (int)measurement.data.GetParameter(5).Key;
            format6.SelectedIndex   = (int)measurement.data.GetParameter(5).Value;

            sour7.SelectedIndex     = (int)measurement.data.GetParameter(6).Key;
            format7.SelectedIndex   = (int)measurement.data.GetParameter(6).Value;

            sour8.SelectedIndex     = (int)measurement.data.GetParameter(7).Key;
            format8.SelectedIndex   = (int)measurement.data.GetParameter(7).Value;

            bSaveFormat.SelectedIndex = (int)measurement.data.saveFormat;

            bFilePath.Text = measurement.data.filePath;
            bFileExt.Text = measurement.data.fileExt;

            cDuplicate.Checked = measurement.data.duplicate;
            bDuplicatePath.Text = measurement.data.duplicate_path;

            sendEvent = true;
        }
        private async void CheckInstruments()
        {
            power_supply_status.Text = "Updating...";
            vna_status.Text = "Updating...";
            lastInstrumentUpdate = DateTime.Now.Ticks;
            var currentTick = lastInstrumentUpdate;

            measurement.addressPowerSupply = address_power_supply.Text;
            measurement.addressVNA = address_vna.Text;

            await Task.Run(() => measurement.TryToConnect());
            if (lastInstrumentUpdate > currentTick) return;

            power_supply_status.Text = measurement.powerSupply.IsOpen ? "Ready;\n" + measurement.powerSupply.WriteRead("*IDN?") : "Failed";
            vna_status.Text = measurement.vna.IsOpen ? "Ready;\n" + measurement.vna.WriteRead("*IDN?") : "Failed";
        }
        private async void StatusUpdater()
        {
            while (true)
            {
                await Task.Run(() => Thread.Sleep(500));
                var status = await PowerSupplyUpdate();
                powerSupplyCurrent.Text = "Current: " + status[0] + " (A)";
                powerSupplyVoltage.Text = "Voltage: " + status[1] + " (V)";
                powerSupplyOutput.Text = "Output: " + status[2];
            }
        }
        private async Task<List<string>> PowerSupplyUpdate()
        {
            List<string> output = new List<string>();
            await Task.Run(() => {
                //powerSupplyStatus.Text = measurement.powerSupply.IsOpen ? "Ready" : "Failed";
                if (measurement.powerSupply.IsOpen)
                {
                    output.Add(measurement.powerSupply.CurrentGet().ToString());
                    output.Add(measurement.powerSupply.VoltageGet().ToString());
                    output.Add(measurement.powerSupply.OutputGet() ? "ON" : "OFF");
                } else
                {
                    output.Add("0");
                    output.Add("0");
                    output.Add("OFF");
                }
            });
            return output;
        }
        private void Start(object sender, EventArgs e)
        {
            if (measurement.state != Measurement.State.Disable)
            {
                if (measurement.processState == Measurement.ProcessState.Waiting)
                {
                    measurement.processState = Measurement.ProcessState.Waiting;
                }
                return;
            }
            Task.Run(() => measurement.Start());
            ProcessHandler();
        }
        private async void End(object sender, EventArgs e)
        {
            if (measurement.state == Measurement.State.Disable || measurement.state == Measurement.State.Ending)
                return;

            await measurement.End();
        }
        private void OnProcessStart()
        {
            menuMain.Enabled = false;
            button_start.Enabled = false;
            for(var i = 0; i < tabControl1.TabCount - 1; i++)
            {
                foreach(Control c in tabControl1.TabPages[i].Controls)
                {
                    c.Enabled = false;
                }
            }
            tabControl1.TabPages[4].Select();
            menuMain.Enabled = true;
        }
        private void OnProcessEnd()
        {
            for (var i = 0; i < tabControl1.TabCount - 1; i++)
            {
                foreach (Control c in tabControl1.TabPages[i].Controls)
                {
                    c.Enabled = true;
                }
            }
            button_start.Enabled = true;
        }
        private async void ProcessHandler()
        {
            OnProcessStart();
            int c = 0;
            while(measurement.state != Measurement.State.Disable)
            {
                await Task.Run(() => Thread.Sleep(200));
                labelState.Text = "State: " + measurement.state.ToString();
                labelProcessState.Text = "Current Work: " + measurement.processState.ToString();
                if (measurement.processState == Measurement.ProcessState.Waiting)
                {
                    labelProcessState.Text += ", " + TimeSpan.FromSeconds(measurement.timer).ToString();
                }
                c++;
                if (c > 30)
                {
                    c = 0;
                    updateGraph_Click(0, new EventArgs());
                }
            }
            OnProcessEnd();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            if (measurement.vna.IsOpen)
            {
                var start = DateTime.Now;
                System.IO.File.WriteAllText("testfile.txt", ">" + measurement.vna.DataFlow("C:\\NA_Measurements\\Temp\\test.s2p") + "<");
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void IndexChanged(object sender, EventArgs e)
        {
            if (!sendEvent) return;

            var data = measurement.data;
            data.SetParameter(0, (VNA.CalcParameter)Enum.Parse(typeof(VNA.CalcParameter),sour1.Text, true), (VNA.DataFormat)Enum.Parse(typeof(VNA.DataFormat), format1.Text, true));
            data.SetParameter(1, (VNA.CalcParameter)Enum.Parse(typeof(VNA.CalcParameter),sour2.Text, true), (VNA.DataFormat)Enum.Parse(typeof(VNA.DataFormat), format2.Text, true));
            data.SetParameter(2, (VNA.CalcParameter)Enum.Parse(typeof(VNA.CalcParameter),sour3.Text, true), (VNA.DataFormat)Enum.Parse(typeof(VNA.DataFormat), format3.Text, true));
            data.SetParameter(3, (VNA.CalcParameter)Enum.Parse(typeof(VNA.CalcParameter),sour4.Text, true), (VNA.DataFormat)Enum.Parse(typeof(VNA.DataFormat), format4.Text, true));
            data.SetParameter(4, (VNA.CalcParameter)Enum.Parse(typeof(VNA.CalcParameter),sour5.Text, true), (VNA.DataFormat)Enum.Parse(typeof(VNA.DataFormat), format5.Text, true));
            data.SetParameter(5, (VNA.CalcParameter)Enum.Parse(typeof(VNA.CalcParameter),sour6.Text, true), (VNA.DataFormat)Enum.Parse(typeof(VNA.DataFormat), format6.Text, true));
            data.SetParameter(6, (VNA.CalcParameter)Enum.Parse(typeof(VNA.CalcParameter),sour7.Text, true), (VNA.DataFormat)Enum.Parse(typeof(VNA.DataFormat), format7.Text, true));
            data.SetParameter(7, (VNA.CalcParameter)Enum.Parse(typeof(VNA.CalcParameter),sour8.Text, true), (VNA.DataFormat)Enum.Parse(typeof(VNA.DataFormat), format8.Text, true));
        }

        private async void updateGraph_Click(object sender, EventArgs e)
        {
            var charts = new System.Windows.Forms.DataVisualization.Charting.Chart[] { chart1, chart2, chart3, chart4 };
            for (var cnum = 0; cnum < 4; cnum++)
            {
                var chart = charts[cnum];
                List<string> meas = new List<string>();
                List<KeyValuePair<VNA.CalcParameter, VNA.DataFormat>> calcs = new List<KeyValuePair<VNA.CalcParameter, VNA.DataFormat>>();
                chart.Legends.Clear();
                chart.Series.Clear();
                chart.Titles.Clear();
                string title = "";
                for(var i = cnum * 2; i < cnum * 2 + 2; i++)
                {
                    var cmeas = measurement.data.GetParameter(i);
                    meas.Add(cmeas.Key.ToString() + "_" + cmeas.Value.ToString());
                    calcs.Add(cmeas);
                    title += cmeas + ", ";
                }
                chart.Titles.Add(title);
                /*for(var i = 0; i < chart.Legends.Count; i++)
                {
                    var legend = chart.Legends[i];
                    if (meas.IndexOf(legend.Name) < 0)
                    {
                        chart.Legends.RemoveAt(i);

                        i--;
                    }
                }*/
                for (var i = 0; i < meas.Count; i++)
                {
                    try
                    {
                        var calc = calcs[i];
                        if (calc.Key == VNA.CalcParameter.OFF) continue;
                        var cmeas = meas[i];

                        var serie = new System.Windows.Forms.DataVisualization.Charting.Series(i.ToString() + " " + calc.Key.ToString() + " " + calc.Value.ToString());// chart1.Series.Add(calc.Key.ToString());
                                                                                                                                                                       //var legend = chart1.Legends.Add(i.ToString() + " " + calc.Key.ToString() + " " + calc.Value.ToString());
                        serie.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;

                        string data;
                        string[] parse = Array.Empty<string>();
                        int it = 0;

                        await Task.Run(() =>
                        {
                            if (measurement.vna.IsOpen)
                            {
                                measurement.vna.SelectMeasurement(cmeas);
                                data = measurement.vna.MeasurementGetData();
                            }
                            else
                            {
                                data = "";
                                var r = new Random(DateTime.Now.Millisecond);
                                for (var j = 0; j < 8001; j++)
                                {
                                    data += (r.NextDouble() * 10 + i * 100).ToString() + ",";
                                }
                            }
                            parse = data.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        });

                        await Task.Run(() =>
                        {
                            foreach (var point in parse)
                            {
                                var cpoint = point;
                                var provider = CultureInfo.CreateSpecificCulture("en-GB");
                                if (cpoint[0] == '+') cpoint = point.Remove(0, 1);
                                var value = Double.Parse(cpoint, NumberStyles.Float, provider);
                                serie.Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(it/*(int)((double)it / (double)parse.Length * measurement.data.freq_end + measurement.data.freq_start)*/, value));
                                it++;
                            }
                        });

                        chart.Series.Add(serie);
                    }
                    catch { }
                }
            }
        }

        private void cDuplicate_CheckedChanged(object sender, EventArgs e)
        {
            if (!sendEvent) return;
            sendEvent = false;
            measurement.data.duplicate = (sender as CheckBox).Checked;
            sendEvent = true;
        }

        private void setDefaultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            measurement.data = new Measurement.Data();
            UpdateData();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new SaveFileDialog();
            dialog.Filter = "*.ini|Ini File";
            dialog.DefaultExt = ".ini";
            dialog.Title = "Save Settings";
            dialog.AddExtension = true;
            var result = dialog.ShowDialog();

            if (result == DialogResult.OK || result == DialogResult.Yes)
            {
                measurement.data.Save(dialog.FileName);
            }

            dialog.Dispose();
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "Ini File|*.ini";
            dialog.DefaultExt = ".ini";
            dialog.Title = "Save Settings";
            dialog.AddExtension = true;
            var result = dialog.ShowDialog();

            if (result == DialogResult.OK || result == DialogResult.Yes)
            {
                measurement.data.Load(dialog.FileName);
                UpdateData();
            }

            dialog.Dispose();
        }

        private void bSaveFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!sendEvent) return;

            var data = measurement.data;
            var value = (sender as ComboBox).SelectedIndex;
            data.saveFormat = (VNA.SaveFormat)value;
        }
    }
}
