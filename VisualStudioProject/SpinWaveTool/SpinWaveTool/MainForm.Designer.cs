
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
            this.button_start = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.address.SuspendLayout();
            this.process.SuspendLayout();
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
            this.tabControl1.Size = new System.Drawing.Size(266, 565);
            this.tabControl1.TabIndex = 0;
            // 
            // address
            // 
            this.address.Controls.Add(this.vna_status);
            this.address.Controls.Add(this.power_supply_status);
            this.address.Controls.Add(this.address_vna);
            this.address.Controls.Add(this.label2);
            this.address.Controls.Add(this.address_power_supply);
            this.address.Controls.Add(this.label1);
            this.address.Location = new System.Drawing.Point(4, 24);
            this.address.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.address.Name = "address";
            this.address.Size = new System.Drawing.Size(258, 537);
            this.address.TabIndex = 0;
            this.address.Text = "VISA";
            this.address.UseVisualStyleBackColor = true;
            // 
            // vna_status
            // 
            this.vna_status.Location = new System.Drawing.Point(3, 193);
            this.vna_status.Name = "vna_status";
            this.vna_status.Size = new System.Drawing.Size(250, 83);
            this.vna_status.TabIndex = 5;
            this.vna_status.Text = "Status";
            // 
            // power_supply_status
            // 
            this.power_supply_status.Location = new System.Drawing.Point(5, 52);
            this.power_supply_status.Name = "power_supply_status";
            this.power_supply_status.Size = new System.Drawing.Size(250, 83);
            this.power_supply_status.TabIndex = 4;
            this.power_supply_status.Text = "Status";
            // 
            // address_vna
            // 
            this.address_vna.Location = new System.Drawing.Point(3, 167);
            this.address_vna.Name = "address_vna";
            this.address_vna.Size = new System.Drawing.Size(250, 23);
            this.address_vna.TabIndex = 3;
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
            this.address_power_supply.Location = new System.Drawing.Point(5, 26);
            this.address_power_supply.Name = "address_power_supply";
            this.address_power_supply.Size = new System.Drawing.Size(250, 23);
            this.address_power_supply.TabIndex = 1;
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
            this.power_supply.Location = new System.Drawing.Point(4, 24);
            this.power_supply.Name = "power_supply";
            this.power_supply.Size = new System.Drawing.Size(258, 537);
            this.power_supply.TabIndex = 0;
            this.power_supply.Text = "N6745A";
            this.power_supply.UseVisualStyleBackColor = true;
            // 
            // vna
            // 
            this.vna.Location = new System.Drawing.Point(4, 24);
            this.vna.Name = "vna";
            this.vna.Size = new System.Drawing.Size(258, 537);
            this.vna.TabIndex = 1;
            this.vna.Text = "M9374A";
            this.vna.UseVisualStyleBackColor = true;
            // 
            // settings
            // 
            this.settings.Location = new System.Drawing.Point(4, 24);
            this.settings.Name = "settings";
            this.settings.Size = new System.Drawing.Size(258, 537);
            this.settings.TabIndex = 2;
            this.settings.Text = "Settings";
            this.settings.UseVisualStyleBackColor = true;
            // 
            // process
            // 
            this.process.Controls.Add(this.button_start);
            this.process.Location = new System.Drawing.Point(4, 24);
            this.process.Name = "process";
            this.process.Size = new System.Drawing.Size(258, 537);
            this.process.TabIndex = 3;
            this.process.Text = "Process";
            this.process.UseVisualStyleBackColor = true;
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
            this.process.ResumeLayout(false);
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
    }
}

