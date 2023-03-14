namespace WinFormCalc.Forms
{
    partial class MainForm
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
            this.contentPanel = new System.Windows.Forms.Panel();
            this.placeholderLabel = new System.Windows.Forms.Label();
            this.menuIcon = new System.Windows.Forms.PictureBox();
            this.menuContentPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.basicCalcButton = new System.Windows.Forms.Button();
            this.advanceCalcButton = new System.Windows.Forms.Button();
            this.prgCalcButton = new System.Windows.Forms.Button();
            this.paperModeButton = new System.Windows.Forms.Button();
            this.gridButton = new System.Windows.Forms.Button();
            this.areaConvertorButton = new System.Windows.Forms.Button();
            this.dataConvertorButton = new System.Windows.Forms.Button();
            this.lengthConvertorButton = new System.Windows.Forms.Button();
            this.speedConvertorButton = new System.Windows.Forms.Button();
            this.temperatureConvertorButton = new System.Windows.Forms.Button();
            this.timeConvertorButton = new System.Windows.Forms.Button();
            this.volumeConvertorButton = new System.Windows.Forms.Button();
            this.menuPanel = new System.Windows.Forms.Panel();
            this.timerMenuPanel = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.menuIcon)).BeginInit();
            this.menuContentPanel.SuspendLayout();
            this.menuPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // contentPanel
            // 
            this.contentPanel.BackColor = System.Drawing.Color.Transparent;
            this.contentPanel.Location = new System.Drawing.Point(0, 50);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(320, 445);
            this.contentPanel.TabIndex = 2;
            // 
            // placeholderLabel
            // 
            this.placeholderLabel.AutoSize = true;
            this.placeholderLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.placeholderLabel.Location = new System.Drawing.Point(55, 9);
            this.placeholderLabel.Name = "placeholderLabel";
            this.placeholderLabel.Size = new System.Drawing.Size(108, 32);
            this.placeholderLabel.TabIndex = 0;
            this.placeholderLabel.Text = "Základní";
            this.placeholderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // menuIcon
            // 
            this.menuIcon.BackColor = System.Drawing.Color.Fuchsia;
            this.menuIcon.Location = new System.Drawing.Point(3, 3);
            this.menuIcon.Name = "menuIcon";
            this.menuIcon.Size = new System.Drawing.Size(44, 44);
            this.menuIcon.TabIndex = 0;
            this.menuIcon.TabStop = false;
            this.menuIcon.Click += new System.EventHandler(this.MenuIconClick);
            // 
            // menuContentPanel
            // 
            this.menuContentPanel.AutoScroll = true;
            this.menuContentPanel.Controls.Add(this.basicCalcButton);
            this.menuContentPanel.Controls.Add(this.advanceCalcButton);
            this.menuContentPanel.Controls.Add(this.prgCalcButton);
            this.menuContentPanel.Controls.Add(this.paperModeButton);
            this.menuContentPanel.Controls.Add(this.gridButton);
            this.menuContentPanel.Controls.Add(this.areaConvertorButton);
            this.menuContentPanel.Controls.Add(this.dataConvertorButton);
            this.menuContentPanel.Controls.Add(this.lengthConvertorButton);
            this.menuContentPanel.Controls.Add(this.speedConvertorButton);
            this.menuContentPanel.Controls.Add(this.temperatureConvertorButton);
            this.menuContentPanel.Controls.Add(this.timeConvertorButton);
            this.menuContentPanel.Controls.Add(this.volumeConvertorButton);
            this.menuContentPanel.Location = new System.Drawing.Point(0, 47);
            this.menuContentPanel.Name = "menuContentPanel";
            this.menuContentPanel.Size = new System.Drawing.Size(217, 445);
            this.menuContentPanel.TabIndex = 1;
            // 
            // basicCalcButton
            // 
            this.basicCalcButton.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.basicCalcButton.Location = new System.Drawing.Point(3, 3);
            this.basicCalcButton.Name = "basicCalcButton";
            this.basicCalcButton.Size = new System.Drawing.Size(194, 37);
            this.basicCalcButton.TabIndex = 0;
            this.basicCalcButton.Text = "Základní";
            this.basicCalcButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.basicCalcButton.UseVisualStyleBackColor = true;
            this.basicCalcButton.Click += new System.EventHandler(this.BasicCalcButtonClick);
            // 
            // advanceCalcButton
            // 
            this.advanceCalcButton.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.advanceCalcButton.Location = new System.Drawing.Point(3, 46);
            this.advanceCalcButton.Name = "advanceCalcButton";
            this.advanceCalcButton.Size = new System.Drawing.Size(194, 37);
            this.advanceCalcButton.TabIndex = 1;
            this.advanceCalcButton.Text = "Pokročilá";
            this.advanceCalcButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.advanceCalcButton.UseVisualStyleBackColor = true;
            this.advanceCalcButton.Click += new System.EventHandler(this.AdvanceCalcButtonClick);
            // 
            // prgCalcButton
            // 
            this.prgCalcButton.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.prgCalcButton.Location = new System.Drawing.Point(3, 89);
            this.prgCalcButton.Name = "prgCalcButton";
            this.prgCalcButton.Size = new System.Drawing.Size(194, 37);
            this.prgCalcButton.TabIndex = 2;
            this.prgCalcButton.Text = "Programátrorská";
            this.prgCalcButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.prgCalcButton.UseVisualStyleBackColor = true;
            this.prgCalcButton.Click += new System.EventHandler(this.PrgCalcButtonClick);
            // 
            // paperModeButton
            // 
            this.paperModeButton.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.paperModeButton.Location = new System.Drawing.Point(3, 132);
            this.paperModeButton.Name = "paperModeButton";
            this.paperModeButton.Size = new System.Drawing.Size(194, 37);
            this.paperModeButton.TabIndex = 3;
            this.paperModeButton.Text = "Paper Mode";
            this.paperModeButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.paperModeButton.UseVisualStyleBackColor = true;
            this.paperModeButton.Click += new System.EventHandler(this.PaperModeButtonClick);
            // 
            // gridButton
            // 
            this.gridButton.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gridButton.Location = new System.Drawing.Point(3, 175);
            this.gridButton.Name = "gridButton";
            this.gridButton.Size = new System.Drawing.Size(194, 37);
            this.gridButton.TabIndex = 4;
            this.gridButton.Text = "Vytváření Grafů";
            this.gridButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.gridButton.UseVisualStyleBackColor = true;
            this.gridButton.Click += new System.EventHandler(this.GraphButtonClick);
            // 
            // areaConvertorButton
            // 
            this.areaConvertorButton.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.areaConvertorButton.Location = new System.Drawing.Point(3, 218);
            this.areaConvertorButton.Name = "areaConvertorButton";
            this.areaConvertorButton.Size = new System.Drawing.Size(194, 37);
            this.areaConvertorButton.TabIndex = 5;
            this.areaConvertorButton.Text = "Plocha";
            this.areaConvertorButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.areaConvertorButton.UseVisualStyleBackColor = true;
            this.areaConvertorButton.Click += new System.EventHandler(this.AreaConvertorButtonClick);
            // 
            // dataConvertorButton
            // 
            this.dataConvertorButton.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dataConvertorButton.Location = new System.Drawing.Point(3, 261);
            this.dataConvertorButton.Name = "dataConvertorButton";
            this.dataConvertorButton.Size = new System.Drawing.Size(194, 37);
            this.dataConvertorButton.TabIndex = 6;
            this.dataConvertorButton.Text = "Data";
            this.dataConvertorButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.dataConvertorButton.UseVisualStyleBackColor = true;
            this.dataConvertorButton.Click += new System.EventHandler(this.DataConvertorButtonClick);
            // 
            // lengthConvertorButton
            // 
            this.lengthConvertorButton.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lengthConvertorButton.Location = new System.Drawing.Point(3, 304);
            this.lengthConvertorButton.Name = "lengthConvertorButton";
            this.lengthConvertorButton.Size = new System.Drawing.Size(194, 37);
            this.lengthConvertorButton.TabIndex = 7;
            this.lengthConvertorButton.Text = "Délka";
            this.lengthConvertorButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lengthConvertorButton.UseVisualStyleBackColor = true;
            this.lengthConvertorButton.Click += new System.EventHandler(this.LengthConvertorButtonClick);
            // 
            // speedConvertorButton
            // 
            this.speedConvertorButton.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.speedConvertorButton.Location = new System.Drawing.Point(3, 347);
            this.speedConvertorButton.Name = "speedConvertorButton";
            this.speedConvertorButton.Size = new System.Drawing.Size(194, 37);
            this.speedConvertorButton.TabIndex = 8;
            this.speedConvertorButton.Text = "Rychlost";
            this.speedConvertorButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.speedConvertorButton.UseVisualStyleBackColor = true;
            this.speedConvertorButton.Click += new System.EventHandler(this.SpeedConvertorButtonClick);
            // 
            // temperatureConvertorButton
            // 
            this.temperatureConvertorButton.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.temperatureConvertorButton.Location = new System.Drawing.Point(3, 390);
            this.temperatureConvertorButton.Name = "temperatureConvertorButton";
            this.temperatureConvertorButton.Size = new System.Drawing.Size(194, 37);
            this.temperatureConvertorButton.TabIndex = 9;
            this.temperatureConvertorButton.Text = "Teplota";
            this.temperatureConvertorButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.temperatureConvertorButton.UseVisualStyleBackColor = true;
            this.temperatureConvertorButton.Click += new System.EventHandler(this.TemperatureConvertorButtonClick);
            // 
            // timeConvertorButton
            // 
            this.timeConvertorButton.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.timeConvertorButton.Location = new System.Drawing.Point(3, 433);
            this.timeConvertorButton.Name = "timeConvertorButton";
            this.timeConvertorButton.Size = new System.Drawing.Size(194, 37);
            this.timeConvertorButton.TabIndex = 10;
            this.timeConvertorButton.Text = "Čas";
            this.timeConvertorButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.timeConvertorButton.UseVisualStyleBackColor = true;
            this.timeConvertorButton.Click += new System.EventHandler(this.TimeConvertorButtonClick);
            // 
            // volumeConvertorButton
            // 
            this.volumeConvertorButton.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.volumeConvertorButton.Location = new System.Drawing.Point(3, 476);
            this.volumeConvertorButton.Name = "volumeConvertorButton";
            this.volumeConvertorButton.Size = new System.Drawing.Size(194, 37);
            this.volumeConvertorButton.TabIndex = 11;
            this.volumeConvertorButton.Text = "Objem";
            this.volumeConvertorButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.volumeConvertorButton.UseVisualStyleBackColor = true;
            this.volumeConvertorButton.Click += new System.EventHandler(this.VolumeConvertorButtonClick);
            // 
            // menuPanel
            // 
            this.menuPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.menuPanel.Controls.Add(this.menuContentPanel);
            this.menuPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuPanel.Location = new System.Drawing.Point(0, 0);
            this.menuPanel.MaximumSize = new System.Drawing.Size(217, 0);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(200, 495);
            this.menuPanel.TabIndex = 3;
            // 
            // timerMenuPanel
            // 
            this.timerMenuPanel.Interval = 5;
            this.timerMenuPanel.Tick += new System.EventHandler(this.MenuPanelTimerTick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 495);
            this.Controls.Add(this.menuIcon);
            this.Controls.Add(this.menuPanel);
            this.Controls.Add(this.placeholderLabel);
            this.Controls.Add(this.contentPanel);
            this.KeyPreview = true;
            this.MaximumSize = new System.Drawing.Size(1296, 979);
            this.MinimumSize = new System.Drawing.Size(336, 534);
            this.Name = "MainForm";
            this.Text = "Main";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MainFormKeyPress);
            this.Resize += new System.EventHandler(this.MainFormResize);
            ((System.ComponentModel.ISupportInitialize)(this.menuIcon)).EndInit();
            this.menuContentPanel.ResumeLayout(false);
            this.menuPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label placeholderLabel;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.FlowLayoutPanel menuContentPanel;
        private System.Windows.Forms.PictureBox menuIcon;
        private System.Windows.Forms.Button advanceCalcButton;
        private System.Windows.Forms.Button prgCalcButton;
        private System.Windows.Forms.Button paperModeButton;
        private System.Windows.Forms.Button gridButton;
        private System.Windows.Forms.Panel menuPanel;
        private System.Windows.Forms.Timer timerMenuPanel;
        private System.Windows.Forms.Button basicCalcButton;
        private System.Windows.Forms.Button areaConvertorButton;
        private System.Windows.Forms.Button dataConvertorButton;
        private System.Windows.Forms.Button lengthConvertorButton;
        private System.Windows.Forms.Button speedConvertorButton;
        private System.Windows.Forms.Button temperatureConvertorButton;
        private System.Windows.Forms.Button timeConvertorButton;
        private System.Windows.Forms.Button volumeConvertorButton;
    }
}