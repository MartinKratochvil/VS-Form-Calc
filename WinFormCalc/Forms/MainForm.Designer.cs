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
            this.labelPlaceholer = new System.Windows.Forms.Label();
            this.pictureBoxMenu = new System.Windows.Forms.PictureBox();
            this.panelMenuContent = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonAdvanceCalc = new System.Windows.Forms.Button();
            this.buttonPrgCalc = new System.Windows.Forms.Button();
            this.buttonPaperMode = new System.Windows.Forms.Button();
            this.buttonGrid = new System.Windows.Forms.Button();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.timerMenuPanel = new System.Windows.Forms.Timer(this.components);
            this.buttonBasicCalc = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMenu)).BeginInit();
            this.panelMenuContent.SuspendLayout();
            this.panelMenu.SuspendLayout();
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
            // labelPlaceholer
            // 
            this.labelPlaceholer.AutoSize = true;
            this.labelPlaceholer.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelPlaceholer.Location = new System.Drawing.Point(55, 9);
            this.labelPlaceholer.Name = "labelPlaceholer";
            this.labelPlaceholer.Size = new System.Drawing.Size(107, 32);
            this.labelPlaceholer.TabIndex = 0;
            this.labelPlaceholer.Text = "Základní";
            this.labelPlaceholer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBoxMenu
            // 
            this.pictureBoxMenu.BackColor = System.Drawing.Color.Fuchsia;
            this.pictureBoxMenu.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxMenu.Name = "pictureBoxMenu";
            this.pictureBoxMenu.Size = new System.Drawing.Size(44, 44);
            this.pictureBoxMenu.TabIndex = 0;
            this.pictureBoxMenu.TabStop = false;
            this.pictureBoxMenu.Click += new System.EventHandler(this.pictureBoxMenu_Click);
            // 
            // panelMenuContent
            // 
            this.panelMenuContent.AutoScroll = true;
            this.panelMenuContent.Controls.Add(this.buttonBasicCalc);
            this.panelMenuContent.Controls.Add(this.buttonAdvanceCalc);
            this.panelMenuContent.Controls.Add(this.buttonPrgCalc);
            this.panelMenuContent.Controls.Add(this.buttonPaperMode);
            this.panelMenuContent.Controls.Add(this.buttonGrid);
            this.panelMenuContent.Location = new System.Drawing.Point(0, 47);
            this.panelMenuContent.Name = "panelMenuContent";
            this.panelMenuContent.Size = new System.Drawing.Size(217, 445);
            this.panelMenuContent.TabIndex = 1;
            // 
            // buttonAdvanceCalc
            // 
            this.buttonAdvanceCalc.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonAdvanceCalc.Location = new System.Drawing.Point(3, 46);
            this.buttonAdvanceCalc.Name = "buttonAdvanceCalc";
            this.buttonAdvanceCalc.Size = new System.Drawing.Size(194, 37);
            this.buttonAdvanceCalc.TabIndex = 1;
            this.buttonAdvanceCalc.Text = "Pokročilá";
            this.buttonAdvanceCalc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAdvanceCalc.UseVisualStyleBackColor = true;
            this.buttonAdvanceCalc.Click += new System.EventHandler(this.buttonAdvanceCalc_Click);
            // 
            // buttonPrgCalc
            // 
            this.buttonPrgCalc.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonPrgCalc.Location = new System.Drawing.Point(3, 89);
            this.buttonPrgCalc.Name = "buttonPrgCalc";
            this.buttonPrgCalc.Size = new System.Drawing.Size(194, 37);
            this.buttonPrgCalc.TabIndex = 2;
            this.buttonPrgCalc.Text = "Programátrorská";
            this.buttonPrgCalc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonPrgCalc.UseVisualStyleBackColor = true;
            this.buttonPrgCalc.Click += new System.EventHandler(this.buttonPrgCalc_Click);
            // 
            // buttonPaperMode
            // 
            this.buttonPaperMode.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonPaperMode.Location = new System.Drawing.Point(3, 132);
            this.buttonPaperMode.Name = "buttonPaperMode";
            this.buttonPaperMode.Size = new System.Drawing.Size(194, 37);
            this.buttonPaperMode.TabIndex = 3;
            this.buttonPaperMode.Text = "Paper Mode";
            this.buttonPaperMode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonPaperMode.UseVisualStyleBackColor = true;
            this.buttonPaperMode.Click += new System.EventHandler(this.buttonPaperMode_Click);
            // 
            // buttonGrid
            // 
            this.buttonGrid.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonGrid.Location = new System.Drawing.Point(3, 175);
            this.buttonGrid.Name = "buttonGrid";
            this.buttonGrid.Size = new System.Drawing.Size(194, 37);
            this.buttonGrid.TabIndex = 4;
            this.buttonGrid.Text = "Vytváření Grafů";
            this.buttonGrid.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonGrid.UseVisualStyleBackColor = true;
            this.buttonGrid.Click += new System.EventHandler(this.buttonGrid_Click);
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.panelMenu.Controls.Add(this.panelMenuContent);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.MaximumSize = new System.Drawing.Size(217, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(0, 495);
            this.panelMenu.TabIndex = 3;
            // 
            // timerMenuPanel
            // 
            this.timerMenuPanel.Interval = 5;
            this.timerMenuPanel.Tick += new System.EventHandler(this.timerMenuPanel_Tick);
            // 
            // buttonBasicCalc
            // 
            this.buttonBasicCalc.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonBasicCalc.Location = new System.Drawing.Point(3, 3);
            this.buttonBasicCalc.Name = "buttonBasicCalc";
            this.buttonBasicCalc.Size = new System.Drawing.Size(194, 37);
            this.buttonBasicCalc.TabIndex = 0;
            this.buttonBasicCalc.Text = "Základní";
            this.buttonBasicCalc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonBasicCalc.UseVisualStyleBackColor = true;
            this.buttonBasicCalc.Click += new System.EventHandler(this.buttonBasicCalc_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 495);
            this.Controls.Add(this.pictureBoxMenu);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.labelPlaceholer);
            this.Controls.Add(this.contentPanel);
            this.MaximumSize = new System.Drawing.Size(1296, 979);
            this.MinimumSize = new System.Drawing.Size(336, 534);
            this.Name = "MainForm";
            this.Text = "Main";
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMenu)).EndInit();
            this.panelMenuContent.ResumeLayout(false);
            this.panelMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelPlaceholer;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.FlowLayoutPanel panelMenuContent;
        private System.Windows.Forms.PictureBox pictureBoxMenu;
        private System.Windows.Forms.Button buttonAdvanceCalc;
        private System.Windows.Forms.Button buttonPrgCalc;
        private System.Windows.Forms.Button buttonPaperMode;
        private System.Windows.Forms.Button buttonGrid;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Timer timerMenuPanel;
        private System.Windows.Forms.Button buttonBasicCalc;
    }
}