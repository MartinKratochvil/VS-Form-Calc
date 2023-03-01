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
            this.buttonBasicCalc = new System.Windows.Forms.Button();
            this.buttonAdvanceCalc = new System.Windows.Forms.Button();
            this.buttonPrgCalc = new System.Windows.Forms.Button();
            this.buttonPaperMode = new System.Windows.Forms.Button();
            this.buttonGrid = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.timerMenuPanel = new System.Windows.Forms.Timer(this.components);
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
            this.panelMenuContent.Controls.Add(this.button3);
            this.panelMenuContent.Controls.Add(this.button4);
            this.panelMenuContent.Controls.Add(this.button5);
            this.panelMenuContent.Controls.Add(this.button6);
            this.panelMenuContent.Controls.Add(this.button7);
            this.panelMenuContent.Controls.Add(this.button8);
            this.panelMenuContent.Controls.Add(this.button9);
            this.panelMenuContent.Controls.Add(this.button10);
            this.panelMenuContent.Location = new System.Drawing.Point(0, 47);
            this.panelMenuContent.Name = "panelMenuContent";
            this.panelMenuContent.Size = new System.Drawing.Size(217, 445);
            this.panelMenuContent.TabIndex = 1;
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
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button3.Location = new System.Drawing.Point(3, 218);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(194, 37);
            this.button3.TabIndex = 5;
            this.button3.Text = "Programátrorská";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button4.Location = new System.Drawing.Point(3, 261);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(194, 37);
            this.button4.TabIndex = 6;
            this.button4.Text = "Programátrorská";
            this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button5.Location = new System.Drawing.Point(3, 304);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(194, 37);
            this.button5.TabIndex = 7;
            this.button5.Text = "Programátrorská";
            this.button5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button6.Location = new System.Drawing.Point(3, 347);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(194, 37);
            this.button6.TabIndex = 8;
            this.button6.Text = "Programátrorská";
            this.button6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button7.Location = new System.Drawing.Point(3, 390);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(194, 37);
            this.button7.TabIndex = 9;
            this.button7.Text = "Programátrorská";
            this.button7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button8.Location = new System.Drawing.Point(3, 433);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(194, 37);
            this.button8.TabIndex = 10;
            this.button8.Text = "Programátrorská";
            this.button8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button8.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button9.Location = new System.Drawing.Point(3, 476);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(194, 37);
            this.button9.TabIndex = 11;
            this.button9.Text = "Programátrorská";
            this.button9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button9.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            this.button10.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button10.Location = new System.Drawing.Point(3, 519);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(194, 37);
            this.button10.TabIndex = 12;
            this.button10.Text = "Programátrorská";
            this.button10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button10.UseVisualStyleBackColor = true;
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.panelMenu.Controls.Add(this.panelMenuContent);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.MaximumSize = new System.Drawing.Size(217, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(10, 495);
            this.panelMenu.TabIndex = 3;
            // 
            // timerMenuPanel
            // 
            this.timerMenuPanel.Interval = 5;
            this.timerMenuPanel.Tick += new System.EventHandler(this.timerMenuPanel_Tick);
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
        private System.Windows.Forms.Button buttonBasicCalc;
        private System.Windows.Forms.Button buttonAdvanceCalc;
        private System.Windows.Forms.Button buttonPrgCalc;
        private System.Windows.Forms.Button buttonPaperMode;
        private System.Windows.Forms.Button buttonGrid;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Timer timerMenuPanel;
    }
}