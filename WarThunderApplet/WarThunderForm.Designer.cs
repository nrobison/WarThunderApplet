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
            this.titleBar = new System.Windows.Forms.Label();
            this.MapLabel = new System.Windows.Forms.Label();
            this.Map = new System.Windows.Forms.PictureBox();
            this.LoadTimer = new System.Windows.Forms.Timer(this.components);
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Map)).BeginInit();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.BackgroundImage = global::WarThunderApplet.Properties.Resources.background;
            this.mainPanel.Controls.Add(this.titleBar);
            this.mainPanel.Controls.Add(this.MapLabel);
            this.mainPanel.Controls.Add(this.Map);
            this.mainPanel.Location = new System.Drawing.Point(1, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(320, 240);
            this.mainPanel.TabIndex = 0;
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
            this.MapLabel.Location = new System.Drawing.Point(3, 49);
            this.MapLabel.Name = "MapLabel";
            this.MapLabel.Size = new System.Drawing.Size(155, 15);
            this.MapLabel.TabIndex = 3;
            this.MapLabel.Text = "Map - Currently Not Connected";
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
    }
}

