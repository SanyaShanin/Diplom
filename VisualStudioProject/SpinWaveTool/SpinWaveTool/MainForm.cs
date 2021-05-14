using System;
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

namespace SpinWaveTool
{
    public partial class MainForm : Form
    {
        Measurement measurement = new Measurement();
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(VNA.CalcParameter.S11.ToString());
            CheckInstruments();
            StatusUpdater();
            UpdateData();

            bFieldStart.LostFocus += (sender, args) => { MessageBox.Show("changed"); };
            bFieldEnd.LostFocus += ChangeReact;
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

        bool sendEvent = true;
        private void ChangeReact(object sender, EventArgs args)
        {

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
                powerSupplyStatus.Text = measurement.powerSupply.IsOpen ? "Ready" : "Failed";
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
        private async void Start(object sender, EventArgs e)
        {
            if (measurement.state != Measurement.State.Disable)
                return;

            await measurement.Start();
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
            button_start.Enabled = false;
            for(var i = 0; i < tabControl1.TabCount - 1; i++)
            {
                foreach(Control c in tabControl1.TabPages[i].Controls)
                {
                    c.Enabled = false;
                }
            }
            tabControl1.TabPages[4].Select();
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
            while(measurement.state != Measurement.State.Disable)
            {
                await Task.Run(() => Thread.Sleep(200));
                labelState.Text = "State: " + measurement.state.ToString();
                labelProcessState.Text = "Working With: " + measurement.processState.ToString();
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
    }
}
