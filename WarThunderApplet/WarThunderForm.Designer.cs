namespace WarThunderApplet
{
    partial class WarThunderForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.aircraftOutput = new System.Windows.Forms.Label();
            this.aircraftLabel = new System.Windows.Forms.Label();
            this.altitudeOutput = new System.Windows.Forms.Label();
            this.altitudeLabel = new System.Windows.Forms.Label();
            this.speedOutput = new System.Windows.Forms.Label();
            this.speedLabel = new System.Windows.Forms.Label();
            this.titleBar = new System.Windows.Forms.Label();
            this.MapLabel = new System.Windows.Forms.Label();
            this.Map = new System.Windows.Forms.PictureBox();
            this.LoadTimer = new System.Windows.Forms.Timer(this.components);
            this.throttleLabel = new System.Windows.Forms.Label();
            this.throttleOutput = new System.Windows.Forms.Label();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Map)).BeginInit();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.BackgroundImage = global::WarThunderApplet.Properties.Resources.background;
            this.mainPanel.Controls.Add(this.throttleOutput);
            this.mainPanel.Controls.Add(this.throttleLabel);
            this.mainPanel.Controls.Add(this.aircraftOutput);
            this.mainPanel.Controls.Add(this.aircraftLabel);
            this.mainPanel.Controls.Add(this.altitudeOutput);
            this.mainPanel.Controls.Add(this.altitudeLabel);
            this.mainPanel.Controls.Add(this.speedOutput);
            this.mainPanel.Controls.Add(this.speedLabel);
            this.mainPanel.Controls.Add(this.titleBar);
            this.mainPanel.Controls.Add(this.MapLabel);
            this.mainPanel.Controls.Add(this.Map);
            this.mainPanel.ForeColor = System.Drawing.Color.Transparent;
            this.mainPanel.Location = new System.Drawing.Point(1, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(320, 240);
            this.mainPanel.TabIndex = 0;
            // 
            // aircraftOutput
            // 
            this.aircraftOutput.AutoSize = true;
            this.aircraftOutput.BackColor = System.Drawing.Color.Transparent;
            this.aircraftOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aircraftOutput.Location = new System.Drawing.Point(69, 33);
            this.aircraftOutput.Name = "aircraftOutput";
            this.aircraftOutput.Size = new System.Drawing.Size(33, 16);
            this.aircraftOutput.TabIndex = 9;
            this.aircraftOutput.Text = "N/a";
            // 
            // aircraftLabel
            // 
            this.aircraftLabel.AutoSize = true;
            this.aircraftLabel.BackColor = System.Drawing.Color.Transparent;
            this.aircraftLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aircraftLabel.Location = new System.Drawing.Point(4, 33);
            this.aircraftLabel.Name = "aircraftLabel";
            this.aircraftLabel.Size = new System.Drawing.Size(69, 16);
            this.aircraftLabel.TabIndex = 8;
            this.aircraftLabel.Text = "Aircraft : ";
            // 
            // altitudeOutput
            // 
            this.altitudeOutput.AutoSize = true;
            this.altitudeOutput.BackColor = System.Drawing.Color.Transparent;
            this.altitudeOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.altitudeOutput.ForeColor = System.Drawing.Color.Transparent;
            this.altitudeOutput.Location = new System.Drawing.Point(234, 47);
            this.altitudeOutput.Name = "altitudeOutput";
            this.altitudeOutput.Size = new System.Drawing.Size(40, 16);
            this.altitudeOutput.TabIndex = 7;
            this.altitudeOutput.Text = "0 km";
            // 
            // altitudeLabel
            // 
            this.altitudeLabel.AutoSize = true;
            this.altitudeLabel.BackColor = System.Drawing.Color.Transparent;
            this.altitudeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.altitudeLabel.ForeColor = System.Drawing.Color.Transparent;
            this.altitudeLabel.Location = new System.Drawing.Point(164, 47);
            this.altitudeLabel.Name = "altitudeLabel";
            this.altitudeLabel.Size = new System.Drawing.Size(68, 16);
            this.altitudeLabel.TabIndex = 6;
            this.altitudeLabel.Text = "Altitude :";
            // 
            // speedOutput
            // 
            this.speedOutput.AutoSize = true;
            this.speedOutput.BackColor = System.Drawing.Color.Transparent;
            this.speedOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.speedOutput.ForeColor = System.Drawing.Color.Transparent;
            this.speedOutput.Location = new System.Drawing.Point(234, 28);
            this.speedOutput.Name = "speedOutput";
            this.speedOutput.Size = new System.Drawing.Size(53, 16);
            this.speedOutput.TabIndex = 5;
            this.speedOutput.Text = "0 km/h";
            // 
            // speedLabel
            // 
            this.speedLabel.AutoSize = true;
            this.speedLabel.BackColor = System.Drawing.Color.Transparent;
            this.speedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.speedLabel.ForeColor = System.Drawing.Color.Transparent;
            this.speedLabel.Location = new System.Drawing.Point(164, 28);
            this.speedLabel.Name = "speedLabel";
            this.speedLabel.Size = new System.Drawing.Size(70, 16);
            this.speedLabel.TabIndex = 4;
            this.speedLabel.Text = "Speed  : ";
            // 
            // titleBar
            // 
            this.titleBar.BackColor = System.Drawing.Color.Transparent;
            this.titleBar.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleBar.ForeColor = System.Drawing.Color.White;
            this.titleBar.Location = new System.Drawing.Point(0, 0);
            this.titleBar.Name = "titleBar";
            this.titleBar.Size = new System.Drawing.Size(320, 24);
            this.titleBar.TabIndex = 0;
            this.titleBar.Text = "War Thunder ";
            this.titleBar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MapLabel
            // 
            this.MapLabel.AutoSize = true;
            this.MapLabel.BackColor = System.Drawing.Color.Transparent;
            this.MapLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MapLabel.ForeColor = System.Drawing.Color.Snow;
            this.MapLabel.Location = new System.Drawing.Point(0, 58);
            this.MapLabel.Name = "MapLabel";
            this.MapLabel.Size = new System.Drawing.Size(2, 15);
            this.MapLabel.TabIndex = 3;
            // 
            // Map
            // 
            this.Map.Location = new System.Drawing.Point(3, 76);
            this.Map.Name = "Map";
            this.Map.Size = new System.Drawing.Size(155, 131);
            this.Map.TabIndex = 2;
            this.Map.TabStop = false;
            // 
            // LoadTimer
            // 
            this.LoadTimer.Tick += new System.EventHandler(this.LoadTimer_Tick);
            // 
            // throttleLabel
            // 
            this.throttleLabel.AutoSize = true;
            this.throttleLabel.BackColor = System.Drawing.Color.Transparent;
            this.throttleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.throttleLabel.ForeColor = System.Drawing.Color.Transparent;
            this.throttleLabel.Location = new System.Drawing.Point(164, 63);
            this.throttleLabel.Name = "throttleLabel";
            this.throttleLabel.Size = new System.Drawing.Size(69, 16);
            this.throttleLabel.TabIndex = 10;
            this.throttleLabel.Text = "Throttle :";
            // 
            // throttleOutput
            // 
            this.throttleOutput.AutoSize = true;
            this.throttleOutput.BackColor = System.Drawing.Color.Transparent;
            this.throttleOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.throttleOutput.ForeColor = System.Drawing.Color.Transparent;
            this.throttleOutput.Location = new System.Drawing.Point(234, 63);
            this.throttleOutput.Name = "throttleOutput";
            this.throttleOutput.Size = new System.Drawing.Size(29, 16);
            this.throttleOutput.TabIndex = 11;
            this.throttleOutput.Text = "0%";
            // 
            // WarThunderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 262);
            this.Controls.Add(this.mainPanel);
            this.Name = "WarThunderForm";
            this.Text = "War Thunder";
            this.Load += new System.EventHandler(this.WarThunderForm_Load);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Map)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.PictureBox Map;
        private System.Windows.Forms.Label MapLabel;
        private System.Windows.Forms.Timer LoadTimer;
        private System.Windows.Forms.Label titleBar;
        private System.Windows.Forms.Label speedLabel;
        private System.Windows.Forms.Label speedOutput;
        private System.Windows.Forms.Label altitudeOutput;
        private System.Windows.Forms.Label altitudeLabel;
        private System.Windows.Forms.Label aircraftOutput;
        private System.Windows.Forms.Label aircraftLabel;
        private System.Windows.Forms.Label throttleOutput;
        private System.Windows.Forms.Label throttleLabel;
    }
}

