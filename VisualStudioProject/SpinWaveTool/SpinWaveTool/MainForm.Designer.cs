
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
            this.vna = new System.Windows.Forms.TabPage();
            this.settings = new System.Windows.Forms.TabPage();
            this.process = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.powerSupplyStatus = new System.Windows.Forms.Label();
            this.powerSupplyOutput = new System.Windows.Forms.Label();
            this.powerSupplyVoltage = new System.Windows.Forms.Label();
            this.powerSupplyCurrent = new System.Windows.Forms.Label();
            this.button_start = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.bFieldStart = new System.Windows.Forms.TextBox();
            this.bFieldEnd = new System.Windows.Forms.TextBox();
            this.bFieldStep = new System.Windows.Forms.TextBox();
            this.bFieldPoints = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.bRestartCount = new System.Windows.Forms.TextBox();
            this.bRestartsDelay = new System.Windows.Forms.TextBox();
            this.bVoltageProtection = new System.Windows.Forms.TextBox();
            this.bVoltageLimit = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.address.SuspendLayout();
            this.power_supply.SuspendLayout();
            this.process.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(266, 615);
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
            this.address.Size = new System.Drawing.Size(258, 587);
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
            this.button1.Location = new System.Drawing.Point(5, 537);
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
            this.power_supply.Controls.Add(this.bVoltageLimit);
            this.power_supply.Controls.Add(this.bVoltageProtection);
            this.power_supply.Controls.Add(this.bRestartsDelay);
            this.power_supply.Controls.Add(this.bRestartCount);
            this.power_supply.Controls.Add(this.label10);
            this.power_supply.Controls.Add(this.label9);
            this.power_supply.Controls.Add(this.label8);
            this.power_supply.Controls.Add(this.label7);
            this.power_supply.Controls.Add(this.bFieldPoints);
            this.power_supply.Controls.Add(this.bFieldStep);
            this.power_supply.Controls.Add(this.bFieldEnd);
            this.power_supply.Controls.Add(this.bFieldStart);
            this.power_supply.Controls.Add(this.label6);
            this.power_supply.Controls.Add(this.label5);
            this.power_supply.Controls.Add(this.label4);
            this.power_supply.Controls.Add(this.label3);
            this.power_supply.Location = new System.Drawing.Point(4, 24);
            this.power_supply.Name = "power_supply";
            this.power_supply.Size = new System.Drawing.Size(258, 587);
            this.power_supply.TabIndex = 0;
            this.power_supply.Text = "N6745A";
            this.power_supply.UseVisualStyleBackColor = true;
            // 
            // vna
            // 
            this.vna.Location = new System.Drawing.Point(4, 24);
            this.vna.Name = "vna";
            this.vna.Size = new System.Drawing.Size(258, 587);
            this.vna.TabIndex = 1;
            this.vna.Text = "M9374A";
            this.vna.UseVisualStyleBackColor = true;
            // 
            // settings
            // 
            this.settings.Location = new System.Drawing.Point(4, 24);
            this.settings.Name = "settings";
            this.settings.Size = new System.Drawing.Size(258, 587);
            this.settings.TabIndex = 2;
            this.settings.Text = "Settings";
            this.settings.UseVisualStyleBackColor = true;
            // 
            // process
            // 
            this.process.Controls.Add(this.groupBox1);
            this.process.Controls.Add(this.button_start);
            this.process.Location = new System.Drawing.Point(4, 24);
            this.process.Name = "process";
            this.process.Size = new System.Drawing.Size(258, 587);
            this.process.TabIndex = 3;
            this.process.Text = "Process";
            this.process.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.powerSupplyStatus);
            this.groupBox1.Controls.Add(this.powerSupplyOutput);
            this.groupBox1.Controls.Add(this.powerSupplyVoltage);
            this.groupBox1.Controls.Add(this.powerSupplyCurrent);
            this.groupBox1.Location = new System.Drawing.Point(4, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(251, 123);
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
            this.button_start.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_start.Location = new System.Drawing.Point(3, 3);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(92, 35);
            this.button_start.TabIndex = 1;
            this.button_start.Text = "Start";
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.Start);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Field Start (A)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(133, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "Field End (A)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 15);
            this.label5.TabIndex = 2;
            this.label5.Text = "Field Step (A)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(133, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 15);
            this.label6.TabIndex = 3;
            this.label6.Text = "Field Points Number";
            // 
            // bFieldStart
            // 
            this.bFieldStart.Location = new System.Drawing.Point(11, 30);
            this.bFieldStart.Name = "bFieldStart";
            this.bFieldStart.Size = new System.Drawing.Size(116, 23);
            this.bFieldStart.TabIndex = 4;
            // 
            // bFieldEnd
            // 
            this.bFieldEnd.Location = new System.Drawing.Point(133, 30);
            this.bFieldEnd.Name = "bFieldEnd";
            this.bFieldEnd.Size = new System.Drawing.Size(115, 23);
            this.bFieldEnd.TabIndex = 5;
            // 
            // bFieldStep
            // 
            this.bFieldStep.Location = new System.Drawing.Point(11, 74);
            this.bFieldStep.Name = "bFieldStep";
            this.bFieldStep.Size = new System.Drawing.Size(116, 23);
            this.bFieldStep.TabIndex = 6;
            // 
            // bFieldPoints
            // 
            this.bFieldPoints.Location = new System.Drawing.Point(133, 74);
            this.bFieldPoints.Name = "bFieldPoints";
            this.bFieldPoints.Size = new System.Drawing.Size(115, 23);
            this.bFieldPoints.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 130);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(159, 15);
            this.label7.TabIndex = 8;
            this.label7.Text = "Power Supply Restarts Count";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 174);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(177, 15);
            this.label8.TabIndex = 9;
            this.label8.Text = "Power Supply Restarts Delay, ms";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 240);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(122, 15);
            this.label9.TabIndex = 10;
            this.label9.Text = "Voltage Protection (V)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(11, 284);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(94, 15);
            this.label10.TabIndex = 11;
            this.label10.Text = "Voltage Limit (V)";
            // 
            // bRestartCount
            // 
            this.bRestartCount.Location = new System.Drawing.Point(11, 148);
            this.bRestartCount.Name = "bRestartCount";
            this.bRestartCount.Size = new System.Drawing.Size(116, 23);
            this.bRestartCount.TabIndex = 12;
            // 
            // bRestartsDelay
            // 
            this.bRestartsDelay.Location = new System.Drawing.Point(11, 192);
            this.bRestartsDelay.Name = "bRestartsDelay";
            this.bRestartsDelay.Size = new System.Drawing.Size(116, 23);
            this.bRestartsDelay.TabIndex = 13;
            // 
            // bVoltageProtection
            // 
            this.bVoltageProtection.Location = new System.Drawing.Point(11, 258);
            this.bVoltageProtection.Name = "bVoltageProtection";
            this.bVoltageProtection.Size = new System.Drawing.Size(116, 23);
            this.bVoltageProtection.TabIndex = 13;
            // 
            // bVoltageLimit
            // 
            this.bVoltageLimit.Location = new System.Drawing.Point(11, 302);
            this.bVoltageLimit.Name = "bVoltageLimit";
            this.bVoltageLimit.Size = new System.Drawing.Size(116, 23);
            this.bVoltageLimit.TabIndex = 14;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 639);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.Text = "SpinWaveTool";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.address.ResumeLayout(false);
            this.address.PerformLayout();
            this.power_supply.ResumeLayout(false);
            this.power_supply.PerformLayout();
            this.process.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

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
    }
}

