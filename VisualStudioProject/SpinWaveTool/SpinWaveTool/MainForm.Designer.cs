
namespace SpinWaveTool
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.address = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.vna_status = new System.Windows.Forms.Label();
            this.power_supply_status = new System.Windows.Forms.Label();
            this.address_vna = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.address_power_supply = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.power_supply = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.bVoltageLimit = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.bVoltageProtection = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.bRestartsDelay = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.bRestartCount = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bFieldStart = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.bFieldEnd = new System.Windows.Forms.TextBox();
            this.bFieldStep = new System.Windows.Forms.TextBox();
            this.bFieldPoints = new System.Windows.Forms.TextBox();
            this.vna = new System.Windows.Forms.TabPage();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.format4 = new System.Windows.Forms.ComboBox();
            this.format3 = new System.Windows.Forms.ComboBox();
            this.format2 = new System.Windows.Forms.ComboBox();
            this.format1 = new System.Windows.Forms.ComboBox();
            this.sour4 = new System.Windows.Forms.ComboBox();
            this.sour3 = new System.Windows.Forms.ComboBox();
            this.sour2 = new System.Windows.Forms.ComboBox();
            this.sour1 = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.vnaPower = new System.Windows.Forms.TextBox();
            this.vnaBand = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.bFreqPoints = new System.Windows.Forms.TextBox();
            this.bFreqStep = new System.Windows.Forms.TextBox();
            this.bFreqEnd = new System.Windows.Forms.TextBox();
            this.bFreqStart = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.settings = new System.Windows.Forms.TabPage();
            this.bFileExt = new System.Windows.Forms.TextBox();
            this.bFilePath = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.process = new System.Windows.Forms.TabPage();
            this.labelProcessState = new System.Windows.Forms.Label();
            this.labelState = new System.Windows.Forms.Label();
            this.button_stop = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.powerSupplyStatus = new System.Windows.Forms.Label();
            this.powerSupplyOutput = new System.Windows.Forms.Label();
            this.powerSupplyVoltage = new System.Windows.Forms.Label();
            this.powerSupplyCurrent = new System.Windows.Forms.Label();
            this.button_start = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.lTrigger = new System.Windows.Forms.Label();
            this.updateGraph = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.address.SuspendLayout();
            this.power_supply.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.vna.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.settings.SuspendLayout();
            this.process.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControl1.Controls.Add(this.address);
            this.tabControl1.Controls.Add(this.power_supply);
            this.tabControl1.Controls.Add(this.vna);
            this.tabControl1.Controls.Add(this.settings);
            this.tabControl1.Controls.Add(this.process);
            this.tabControl1.Location = new System.Drawing.Point(12, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(266, 588);
            this.tabControl1.TabIndex = 0;
            // 
            // address
            // 
            this.address.Controls.Add(this.button1);
            this.address.Controls.Add(this.vna_status);
            this.address.Controls.Add(this.power_supply_status);
            this.address.Controls.Add(this.address_vna);
            this.address.Controls.Add(this.label2);
            this.address.Controls.Add(this.address_power_supply);
            this.address.Controls.Add(this.label1);
            this.address.Location = new System.Drawing.Point(4, 24);
            this.address.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.address.Name = "address";
            this.address.Size = new System.Drawing.Size(258, 560);
            this.address.TabIndex = 0;
            this.address.Text = "VISA";
            this.address.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Image = global::SpinWaveTool.Properties.Resources.icon_update1;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(5, 510);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.button1.Size = new System.Drawing.Size(248, 47);
            this.button1.TabIndex = 6;
            this.button1.Text = "UPDATE STATUS";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // vna_status
            // 
            this.vna_status.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vna_status.Location = new System.Drawing.Point(3, 193);
            this.vna_status.Name = "vna_status";
            this.vna_status.Size = new System.Drawing.Size(250, 83);
            this.vna_status.TabIndex = 5;
            this.vna_status.Text = "Status";
            // 
            // power_supply_status
            // 
            this.power_supply_status.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.power_supply_status.Location = new System.Drawing.Point(5, 52);
            this.power_supply_status.Name = "power_supply_status";
            this.power_supply_status.Size = new System.Drawing.Size(250, 83);
            this.power_supply_status.TabIndex = 4;
            this.power_supply_status.Text = "Status";
            // 
            // address_vna
            // 
            this.address_vna.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.address_vna.Location = new System.Drawing.Point(3, 167);
            this.address_vna.Name = "address_vna";
            this.address_vna.Size = new System.Drawing.Size(250, 23);
            this.address_vna.TabIndex = 3;
            this.address_vna.Text = "WINDOWS-VQFA9LI";
            this.address_vna.TextChanged += new System.EventHandler(this.address_vna_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(240, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Vector Network Analyzer, KEYSIGHT M9374A";
            // 
            // address_power_supply
            // 
            this.address_power_supply.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.address_power_supply.Location = new System.Drawing.Point(5, 26);
            this.address_power_supply.Name = "address_power_supply";
            this.address_power_supply.Size = new System.Drawing.Size(250, 23);
            this.address_power_supply.TabIndex = 1;
            this.address_power_supply.Text = "192.168.0.105";
            this.address_power_supply.TextChanged += new System.EventHandler(this.address_power_supply_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Power Supply, N6745A";
            // 
            // power_supply
            // 
            this.power_supply.Controls.Add(this.groupBox4);
            this.power_supply.Controls.Add(this.groupBox3);
            this.power_supply.Controls.Add(this.groupBox2);
            this.power_supply.Location = new System.Drawing.Point(4, 24);
            this.power_supply.Name = "power_supply";
            this.power_supply.Size = new System.Drawing.Size(258, 560);
            this.power_supply.TabIndex = 0;
            this.power_supply.Text = "N6745A";
            this.power_supply.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.bVoltageLimit);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.bVoltageProtection);
            this.groupBox4.Location = new System.Drawing.Point(8, 267);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(237, 122);
            this.groupBox4.TabIndex = 17;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Voltage Settings";
            // 
            // bVoltageLimit
            // 
            this.bVoltageLimit.Location = new System.Drawing.Point(6, 84);
            this.bVoltageLimit.Name = "bVoltageLimit";
            this.bVoltageLimit.Size = new System.Drawing.Size(116, 23);
            this.bVoltageLimit.TabIndex = 14;
            this.bVoltageLimit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnAccept);
            this.bVoltageLimit.Leave += new System.EventHandler(this.ChangeReact);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(122, 15);
            this.label9.TabIndex = 10;
            this.label9.Text = "Voltage Protection (V)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 66);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(94, 15);
            this.label10.TabIndex = 11;
            this.label10.Text = "Voltage Limit (V)";
            // 
            // bVoltageProtection
            // 
            this.bVoltageProtection.Location = new System.Drawing.Point(6, 40);
            this.bVoltageProtection.Name = "bVoltageProtection";
            this.bVoltageProtection.Size = new System.Drawing.Size(116, 23);
            this.bVoltageProtection.TabIndex = 13;
            this.bVoltageProtection.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnAccept);
            this.bVoltageProtection.Leave += new System.EventHandler(this.ChangeReact);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.bRestartsDelay);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.bRestartCount);
            this.groupBox3.Location = new System.Drawing.Point(8, 137);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(237, 124);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Field Stasis Solution";
            // 
            // bRestartsDelay
            // 
            this.bRestartsDelay.Location = new System.Drawing.Point(6, 85);
            this.bRestartsDelay.Name = "bRestartsDelay";
            this.bRestartsDelay.Size = new System.Drawing.Size(116, 23);
            this.bRestartsDelay.TabIndex = 13;
            this.bRestartsDelay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnAccept);
            this.bRestartsDelay.Leave += new System.EventHandler(this.ChangeReact);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(159, 15);
            this.label7.TabIndex = 8;
            this.label7.Text = "Power Supply Restarts Count";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 67);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(177, 15);
            this.label8.TabIndex = 9;
            this.label8.Text = "Power Supply Restarts Delay, ms";
            // 
            // bRestartCount
            // 
            this.bRestartCount.Location = new System.Drawing.Point(6, 41);
            this.bRestartCount.Name = "bRestartCount";
            this.bRestartCount.Size = new System.Drawing.Size(116, 23);
            this.bRestartCount.TabIndex = 12;
            this.bRestartCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnAccept);
            this.bRestartCount.Leave += new System.EventHandler(this.ChangeReact);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.bFieldStart);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.bFieldEnd);
            this.groupBox2.Controls.Add(this.bFieldStep);
            this.groupBox2.Controls.Add(this.bFieldPoints);
            this.groupBox2.Location = new System.Drawing.Point(8, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(238, 123);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Field Options";
            // 
            // bFieldStart
            // 
            this.bFieldStart.Location = new System.Drawing.Point(6, 38);
            this.bFieldStart.Name = "bFieldStart";
            this.bFieldStart.Size = new System.Drawing.Size(105, 23);
            this.bFieldStart.TabIndex = 4;
            this.bFieldStart.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnAccept);
            this.bFieldStart.Validated += new System.EventHandler(this.ChangeReact);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Field Start (A)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(117, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "Field End (A)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 15);
            this.label5.TabIndex = 2;
            this.label5.Text = "Field Step (A)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(117, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 15);
            this.label6.TabIndex = 3;
            this.label6.Text = "Field Points Number";
            // 
            // bFieldEnd
            // 
            this.bFieldEnd.Location = new System.Drawing.Point(117, 38);
            this.bFieldEnd.Name = "bFieldEnd";
            this.bFieldEnd.Size = new System.Drawing.Size(107, 23);
            this.bFieldEnd.TabIndex = 5;
            this.bFieldEnd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnAccept);
            this.bFieldEnd.Leave += new System.EventHandler(this.ChangeReact);
            this.bFieldEnd.Validated += new System.EventHandler(this.ChangeReact);
            // 
            // bFieldStep
            // 
            this.bFieldStep.Location = new System.Drawing.Point(6, 82);
            this.bFieldStep.Name = "bFieldStep";
            this.bFieldStep.Size = new System.Drawing.Size(105, 23);
            this.bFieldStep.TabIndex = 6;
            this.bFieldStep.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnAccept);
            this.bFieldStep.Leave += new System.EventHandler(this.ChangeReact);
            // 
            // bFieldPoints
            // 
            this.bFieldPoints.Location = new System.Drawing.Point(117, 82);
            this.bFieldPoints.Name = "bFieldPoints";
            this.bFieldPoints.Size = new System.Drawing.Size(107, 23);
            this.bFieldPoints.TabIndex = 7;
            this.bFieldPoints.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnAccept);
            this.bFieldPoints.Leave += new System.EventHandler(this.ChangeReact);
            // 
            // vna
            // 
            this.vna.Controls.Add(this.groupBox7);
            this.vna.Controls.Add(this.groupBox6);
            this.vna.Controls.Add(this.groupBox5);
            this.vna.Location = new System.Drawing.Point(4, 24);
            this.vna.Name = "vna";
            this.vna.Size = new System.Drawing.Size(258, 560);
            this.vna.TabIndex = 1;
            this.vna.Text = "M9374A";
            this.vna.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label22);
            this.groupBox7.Controls.Add(this.label21);
            this.groupBox7.Controls.Add(this.format4);
            this.groupBox7.Controls.Add(this.format3);
            this.groupBox7.Controls.Add(this.format2);
            this.groupBox7.Controls.Add(this.format1);
            this.groupBox7.Controls.Add(this.sour4);
            this.groupBox7.Controls.Add(this.sour3);
            this.groupBox7.Controls.Add(this.sour2);
            this.groupBox7.Controls.Add(this.sour1);
            this.groupBox7.Controls.Add(this.label20);
            this.groupBox7.Controls.Add(this.label19);
            this.groupBox7.Controls.Add(this.label18);
            this.groupBox7.Controls.Add(this.label17);
            this.groupBox7.Location = new System.Drawing.Point(9, 254);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(237, 175);
            this.groupBox7.TabIndex = 2;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Measurement Settings";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(186, 25);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(45, 15);
            this.label22.TabIndex = 11;
            this.label22.Text = "Format";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(69, 25);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(43, 15);
            this.label21.TabIndex = 10;
            this.label21.Text = "Source";
            // 
            // format4
            // 
            this.format4.FormattingEnabled = true;
            this.format4.Items.AddRange(new object[] {
            "MLOG",
            "PHAS",
            "GDEL",
            "SLIN",
            "SLOG",
            "SCOM",
            "SMIT",
            "SADM",
            "PLIN",
            "PLOG",
            "POL",
            "MLIN",
            "SWR",
            "REAL",
            "IMAG",
            "UPH",
            "PPH"});
            this.format4.Location = new System.Drawing.Point(118, 138);
            this.format4.Name = "format4";
            this.format4.Size = new System.Drawing.Size(113, 23);
            this.format4.TabIndex = 9;
            this.format4.SelectedIndexChanged += new System.EventHandler(this.IndexChanged);
            // 
            // format3
            // 
            this.format3.FormattingEnabled = true;
            this.format3.Items.AddRange(new object[] {
            "MLOG",
            "PHAS",
            "GDEL",
            "SLIN",
            "SLOG",
            "SCOM",
            "SMIT",
            "SADM",
            "PLIN",
            "PLOG",
            "POL",
            "MLIN",
            "SWR",
            "REAL",
            "IMAG",
            "UPH",
            "PPH"});
            this.format3.Location = new System.Drawing.Point(118, 109);
            this.format3.Name = "format3";
            this.format3.Size = new System.Drawing.Size(113, 23);
            this.format3.TabIndex = 8;
            this.format3.SelectedIndexChanged += new System.EventHandler(this.IndexChanged);
            // 
            // format2
            // 
            this.format2.FormattingEnabled = true;
            this.format2.Items.AddRange(new object[] {
            "MLOG",
            "PHAS",
            "GDEL",
            "SLIN",
            "SLOG",
            "SCOM",
            "SMIT",
            "SADM",
            "PLIN",
            "PLOG",
            "POL",
            "MLIN",
            "SWR",
            "REAL",
            "IMAG",
            "UPH",
            "PPH"});
            this.format2.Location = new System.Drawing.Point(118, 80);
            this.format2.Name = "format2";
            this.format2.Size = new System.Drawing.Size(113, 23);
            this.format2.TabIndex = 7;
            this.format2.SelectedIndexChanged += new System.EventHandler(this.IndexChanged);
            // 
            // format1
            // 
            this.format1.FormattingEnabled = true;
            this.format1.Items.AddRange(new object[] {
            "MLOG",
            "PHAS",
            "GDEL",
            "SLIN",
            "SLOG",
            "SCOM",
            "SMIT",
            "SADM",
            "PLIN",
            "PLOG",
            "POL",
            "MLIN",
            "SWR",
            "REAL",
            "IMAG",
            "UPH",
            "PPH"});
            this.format1.Location = new System.Drawing.Point(118, 50);
            this.format1.Name = "format1";
            this.format1.Size = new System.Drawing.Size(113, 23);
            this.format1.TabIndex = 3;
            this.format1.SelectedIndexChanged += new System.EventHandler(this.IndexChanged);
            // 
            // sour4
            // 
            this.sour4.FormattingEnabled = true;
            this.sour4.Items.AddRange(new object[] {
            "OFF",
            "S11",
            "S12",
            "S21",
            "S22"});
            this.sour4.Location = new System.Drawing.Point(23, 138);
            this.sour4.Name = "sour4";
            this.sour4.Size = new System.Drawing.Size(89, 23);
            this.sour4.TabIndex = 6;
            this.sour4.SelectedIndexChanged += new System.EventHandler(this.IndexChanged);
            // 
            // sour3
            // 
            this.sour3.FormattingEnabled = true;
            this.sour3.Items.AddRange(new object[] {
            "OFF",
            "S11",
            "S12",
            "S21",
            "S22"});
            this.sour3.Location = new System.Drawing.Point(23, 109);
            this.sour3.Name = "sour3";
            this.sour3.Size = new System.Drawing.Size(89, 23);
            this.sour3.TabIndex = 5;
            this.sour3.SelectedIndexChanged += new System.EventHandler(this.IndexChanged);
            // 
            // sour2
            // 
            this.sour2.FormattingEnabled = true;
            this.sour2.Items.AddRange(new object[] {
            "OFF",
            "S11",
            "S12",
            "S21",
            "S22"});
            this.sour2.Location = new System.Drawing.Point(23, 80);
            this.sour2.Name = "sour2";
            this.sour2.Size = new System.Drawing.Size(89, 23);
            this.sour2.TabIndex = 4;
            this.sour2.SelectedIndexChanged += new System.EventHandler(this.IndexChanged);
            // 
            // sour1
            // 
            this.sour1.FormattingEnabled = true;
            this.sour1.Items.AddRange(new object[] {
            "OFF",
            "S11",
            "S12",
            "S21",
            "S22"});
            this.sour1.Location = new System.Drawing.Point(23, 50);
            this.sour1.Name = "sour1";
            this.sour1.Size = new System.Drawing.Size(89, 23);
            this.sour1.TabIndex = 3;
            this.sour1.SelectedIndexChanged += new System.EventHandler(this.IndexChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(5, 141);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(13, 15);
            this.label20.TabIndex = 3;
            this.label20.Text = "4";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(5, 112);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(13, 15);
            this.label19.TabIndex = 2;
            this.label19.Text = "3";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(5, 83);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(13, 15);
            this.label18.TabIndex = 1;
            this.label18.Text = "2";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(5, 55);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(13, 15);
            this.label17.TabIndex = 0;
            this.label17.Text = "1";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.vnaPower);
            this.groupBox6.Controls.Add(this.vnaBand);
            this.groupBox6.Controls.Add(this.label16);
            this.groupBox6.Controls.Add(this.label15);
            this.groupBox6.Location = new System.Drawing.Point(9, 134);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(237, 114);
            this.groupBox6.TabIndex = 1;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Additional VNA Settings";
            // 
            // vnaPower
            // 
            this.vnaPower.Location = new System.Drawing.Point(6, 81);
            this.vnaPower.Name = "vnaPower";
            this.vnaPower.Size = new System.Drawing.Size(217, 23);
            this.vnaPower.TabIndex = 9;
            this.vnaPower.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnAccept);
            this.vnaPower.Validated += new System.EventHandler(this.ChangeReact);
            // 
            // vnaBand
            // 
            this.vnaBand.Location = new System.Drawing.Point(6, 37);
            this.vnaBand.Name = "vnaBand";
            this.vnaBand.Size = new System.Drawing.Size(217, 23);
            this.vnaBand.TabIndex = 8;
            this.vnaBand.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnAccept);
            this.vnaBand.Validated += new System.EventHandler(this.ChangeReact);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 63);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(106, 15);
            this.label16.TabIndex = 1;
            this.label16.Text = "Power Level (dBm)";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 19);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(101, 15);
            this.label15.TabIndex = 0;
            this.label15.Text = "IF Bandwidth (Hz)";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.bFreqPoints);
            this.groupBox5.Controls.Add(this.bFreqStep);
            this.groupBox5.Controls.Add(this.bFreqEnd);
            this.groupBox5.Controls.Add(this.bFreqStart);
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Location = new System.Drawing.Point(9, 8);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(237, 120);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Frequency Options";
            // 
            // bFreqPoints
            // 
            this.bFreqPoints.Location = new System.Drawing.Point(123, 83);
            this.bFreqPoints.Name = "bFreqPoints";
            this.bFreqPoints.Size = new System.Drawing.Size(100, 23);
            this.bFreqPoints.TabIndex = 7;
            this.bFreqPoints.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnAccept);
            this.bFreqPoints.Validated += new System.EventHandler(this.ChangeReact);
            // 
            // bFreqStep
            // 
            this.bFreqStep.Location = new System.Drawing.Point(6, 83);
            this.bFreqStep.Name = "bFreqStep";
            this.bFreqStep.Size = new System.Drawing.Size(100, 23);
            this.bFreqStep.TabIndex = 6;
            this.bFreqStep.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnAccept);
            this.bFreqStep.Validated += new System.EventHandler(this.ChangeReact);
            // 
            // bFreqEnd
            // 
            this.bFreqEnd.Location = new System.Drawing.Point(123, 39);
            this.bFreqEnd.Name = "bFreqEnd";
            this.bFreqEnd.Size = new System.Drawing.Size(100, 23);
            this.bFreqEnd.TabIndex = 5;
            this.bFreqEnd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnAccept);
            this.bFreqEnd.Validated += new System.EventHandler(this.ChangeReact);
            // 
            // bFreqStart
            // 
            this.bFreqStart.Location = new System.Drawing.Point(6, 39);
            this.bFreqStart.Name = "bFreqStart";
            this.bFreqStart.Size = new System.Drawing.Size(100, 23);
            this.bFreqStart.TabIndex = 4;
            this.bFreqStart.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnAccept);
            this.bFreqStart.Validated += new System.EventHandler(this.ChangeReact);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(123, 65);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(87, 15);
            this.label14.TabIndex = 3;
            this.label14.Text = "Points Number";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(7, 65);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(66, 15);
            this.label13.TabIndex = 2;
            this.label13.Text = "Step (MHz)";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(123, 21);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 15);
            this.label12.TabIndex = 1;
            this.label12.Text = "End (MHz)";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 21);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 15);
            this.label11.TabIndex = 0;
            this.label11.Text = "Start (MHz)";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // settings
            // 
            this.settings.Controls.Add(this.bFileExt);
            this.settings.Controls.Add(this.bFilePath);
            this.settings.Controls.Add(this.label24);
            this.settings.Controls.Add(this.label23);
            this.settings.Location = new System.Drawing.Point(4, 24);
            this.settings.Name = "settings";
            this.settings.Size = new System.Drawing.Size(258, 560);
            this.settings.TabIndex = 2;
            this.settings.Text = "Settings";
            this.settings.UseVisualStyleBackColor = true;
            // 
            // bFileExt
            // 
            this.bFileExt.Location = new System.Drawing.Point(12, 77);
            this.bFileExt.Name = "bFileExt";
            this.bFileExt.Size = new System.Drawing.Size(230, 23);
            this.bFileExt.TabIndex = 3;
            this.bFileExt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnAccept);
            this.bFileExt.Leave += new System.EventHandler(this.ChangeReact);
            // 
            // bFilePath
            // 
            this.bFilePath.Location = new System.Drawing.Point(12, 35);
            this.bFilePath.Name = "bFilePath";
            this.bFilePath.Size = new System.Drawing.Size(230, 23);
            this.bFilePath.TabIndex = 2;
            this.bFilePath.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnAccept);
            this.bFilePath.Leave += new System.EventHandler(this.ChangeReact);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(12, 59);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(106, 15);
            this.label24.TabIndex = 1;
            this.label24.Text = "Save File Extension";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(12, 17);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(79, 15);
            this.label23.TabIndex = 0;
            this.label23.Text = "Save File Path";
            // 
            // process
            // 
            this.process.Controls.Add(this.button2);
            this.process.Controls.Add(this.updateGraph);
            this.process.Controls.Add(this.groupBox8);
            this.process.Controls.Add(this.labelProcessState);
            this.process.Controls.Add(this.labelState);
            this.process.Controls.Add(this.button_stop);
            this.process.Controls.Add(this.groupBox1);
            this.process.Controls.Add(this.button_start);
            this.process.Location = new System.Drawing.Point(4, 24);
            this.process.Name = "process";
            this.process.Size = new System.Drawing.Size(258, 560);
            this.process.TabIndex = 3;
            this.process.Text = "Process";
            this.process.UseVisualStyleBackColor = true;
            // 
            // labelProcessState
            // 
            this.labelProcessState.AutoSize = true;
            this.labelProcessState.Location = new System.Drawing.Point(10, 86);
            this.labelProcessState.Name = "labelProcessState";
            this.labelProcessState.Size = new System.Drawing.Size(79, 15);
            this.labelProcessState.TabIndex = 5;
            this.labelProcessState.Text = "Process State:";
            // 
            // labelState
            // 
            this.labelState.AutoSize = true;
            this.labelState.Location = new System.Drawing.Point(10, 71);
            this.labelState.Name = "labelState";
            this.labelState.Size = new System.Drawing.Size(36, 15);
            this.labelState.TabIndex = 4;
            this.labelState.Text = "State:";
            // 
            // button_stop
            // 
            this.button_stop.Image = global::SpinWaveTool.Properties.Resources.stop;
            this.button_stop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_stop.Location = new System.Drawing.Point(130, 3);
            this.button_stop.Name = "button_stop";
            this.button_stop.Padding = new System.Windows.Forms.Padding(5, 0, 29, 0);
            this.button_stop.Size = new System.Drawing.Size(125, 54);
            this.button_stop.TabIndex = 3;
            this.button_stop.Text = "Stop";
            this.button_stop.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_stop.UseVisualStyleBackColor = true;
            this.button_stop.Click += new System.EventHandler(this.End);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.powerSupplyStatus);
            this.groupBox1.Controls.Add(this.powerSupplyOutput);
            this.groupBox1.Controls.Add(this.powerSupplyVoltage);
            this.groupBox1.Controls.Add(this.powerSupplyCurrent);
            this.groupBox1.Location = new System.Drawing.Point(4, 116);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(241, 123);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Power Supply, N6745A";
            // 
            // powerSupplyStatus
            // 
            this.powerSupplyStatus.AutoSize = true;
            this.powerSupplyStatus.Location = new System.Drawing.Point(6, 19);
            this.powerSupplyStatus.Name = "powerSupplyStatus";
            this.powerSupplyStatus.Size = new System.Drawing.Size(42, 15);
            this.powerSupplyStatus.TabIndex = 3;
            this.powerSupplyStatus.Text = "Status:";
            // 
            // powerSupplyOutput
            // 
            this.powerSupplyOutput.AutoSize = true;
            this.powerSupplyOutput.Location = new System.Drawing.Point(6, 93);
            this.powerSupplyOutput.Name = "powerSupplyOutput";
            this.powerSupplyOutput.Size = new System.Drawing.Size(48, 15);
            this.powerSupplyOutput.TabIndex = 2;
            this.powerSupplyOutput.Text = "Output:";
            // 
            // powerSupplyVoltage
            // 
            this.powerSupplyVoltage.AutoSize = true;
            this.powerSupplyVoltage.Location = new System.Drawing.Point(6, 69);
            this.powerSupplyVoltage.Name = "powerSupplyVoltage";
            this.powerSupplyVoltage.Size = new System.Drawing.Size(49, 15);
            this.powerSupplyVoltage.TabIndex = 1;
            this.powerSupplyVoltage.Text = "Voltage:";
            // 
            // powerSupplyCurrent
            // 
            this.powerSupplyCurrent.AutoSize = true;
            this.powerSupplyCurrent.Location = new System.Drawing.Point(6, 45);
            this.powerSupplyCurrent.Name = "powerSupplyCurrent";
            this.powerSupplyCurrent.Size = new System.Drawing.Size(50, 15);
            this.powerSupplyCurrent.TabIndex = 0;
            this.powerSupplyCurrent.Text = "Current:";
            // 
            // button_start
            // 
            this.button_start.Image = global::SpinWaveTool.Properties.Resources.round_play_button;
            this.button_start.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_start.Location = new System.Drawing.Point(3, 3);
            this.button_start.Name = "button_start";
            this.button_start.Padding = new System.Windows.Forms.Padding(5, 0, 25, 0);
            this.button_start.Size = new System.Drawing.Size(121, 54);
            this.button_start.TabIndex = 1;
            this.button_start.Text = "Start";
            this.button_start.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.Start);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(3, 400);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // menuMain
            // 
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(1012, 24);
            this.menuMain.TabIndex = 2;
            this.menuMain.Text = "menuStrip1";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.lTrigger);
            this.groupBox8.Location = new System.Drawing.Point(4, 245);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(241, 113);
            this.groupBox8.TabIndex = 6;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Vector Network Analyzer, M9374A";
            // 
            // lTrigger
            // 
            this.lTrigger.AutoSize = true;
            this.lTrigger.Location = new System.Drawing.Point(6, 28);
            this.lTrigger.Name = "lTrigger";
            this.lTrigger.Size = new System.Drawing.Size(46, 15);
            this.lTrigger.TabIndex = 0;
            this.lTrigger.Text = "Trigger:";
            // 
            // updateGraph
            // 
            this.updateGraph.Location = new System.Drawing.Point(4, 364);
            this.updateGraph.Name = "updateGraph";
            this.updateGraph.Size = new System.Drawing.Size(241, 30);
            this.updateGraph.TabIndex = 7;
            this.updateGraph.Text = "Update Graph";
            this.updateGraph.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 627);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuMain);
            this.MainMenuStrip = this.menuMain;
            this.Name = "MainForm";
            this.Text = "SpinWaveTool";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.address.ResumeLayout(false);
            this.address.PerformLayout();
            this.power_supply.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.vna.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.settings.ResumeLayout(false);
            this.settings.PerformLayout();
            this.process.ResumeLayout(false);
            this.process.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage address;
        private System.Windows.Forms.TabPage power_supply;
        private System.Windows.Forms.TabPage vna;
        private System.Windows.Forms.TabPage settings;
        private System.Windows.Forms.TabPage process;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.TextBox address_vna;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox address_power_supply;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label vna_status;
        private System.Windows.Forms.Label power_supply_status;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label powerSupplyVoltage;
        private System.Windows.Forms.Label powerSupplyCurrent;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label powerSupplyOutput;
        private System.Windows.Forms.Label powerSupplyStatus;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox bVoltageLimit;
        private System.Windows.Forms.TextBox bVoltageProtection;
        private System.Windows.Forms.TextBox bRestartsDelay;
        private System.Windows.Forms.TextBox bRestartCount;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox bFieldPoints;
        private System.Windows.Forms.TextBox bFieldStep;
        private System.Windows.Forms.TextBox bFieldEnd;
        private System.Windows.Forms.TextBox bFieldStart;
        private System.Windows.Forms.Button button_stop;
        private System.Windows.Forms.Label labelProcessState;
        private System.Windows.Forms.Label labelState;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ComboBox sour4;
        private System.Windows.Forms.ComboBox sour3;
        private System.Windows.Forms.ComboBox sour2;
        private System.Windows.Forms.ComboBox sour1;
        private System.Windows.Forms.ComboBox format1;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox format;
        private System.Windows.Forms.ComboBox format3;
        private System.Windows.Forms.ComboBox format2;
        private System.Windows.Forms.TextBox vnaPower;
        private System.Windows.Forms.TextBox vnaBand;
        private System.Windows.Forms.TextBox bFreqPoints;
        private System.Windows.Forms.TextBox bFreqStep;
        private System.Windows.Forms.TextBox bFreqEnd;
        private System.Windows.Forms.TextBox bFreqStart;
        private System.Windows.Forms.ComboBox ur1;
        private System.Windows.Forms.ComboBox format4;
        private System.Windows.Forms.TextBox bFileExt;
        private System.Windows.Forms.TextBox bFilePath;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Label lTrigger;
        private System.Windows.Forms.Button updateGraph;
    }
}

