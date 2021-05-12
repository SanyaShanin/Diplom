using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpinWaveTool
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void address_power_supply_TextChanged(object sender, EventArgs e)
        {
            PowerSupply.CheckStatus(((TextBox)sender).Text, (status) => power_supply_status.Text = status.ToString());
            
        }

        private void address_vna_TextChanged(object sender, EventArgs e)
        {
            VNA.CheckStatus(((TextBox)sender).Text, (status) => vna_status.Text = status.ToString());
        }
    }
}
