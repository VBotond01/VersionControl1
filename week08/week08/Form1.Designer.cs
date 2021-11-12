namespace week08
{
    partial class Form1
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
            this.createTimer = new System.Windows.Forms.Timer(this.components);
            this.conveyorTimer = new System.Windows.Forms.Timer(this.components);
            this.CarButton = new System.Windows.Forms.Button();
            this.ballButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonColor = new System.Windows.Forms.Button();
            this.buttonPresent = new System.Windows.Forms.Button();
            this.buttonBox = new System.Windows.Forms.Button();
            this.buttonRibbon = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainPanel.Location = new System.Drawing.Point(12, 49);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(756, 118);
            this.mainPanel.TabIndex = 0;
            // 
            // createTimer
            // 
            this.createTimer.Enabled = true;
            this.createTimer.Interval = 3000;
            this.createTimer.Tick += new System.EventHandler(this.createTimer_Tick);
            // 
            // conveyorTimer
            // 
            this.conveyorTimer.Enabled = true;
            this.conveyorTimer.Interval = 10;
            this.conveyorTimer.Tick += new System.EventHandler(this.conveyorTimer_Tick);
            // 
            // CarButton
            // 
            this.CarButton.Location = new System.Drawing.Point(13, 4);
            this.CarButton.Name = "CarButton";
            this.CarButton.Size = new System.Drawing.Size(75, 23);
            this.CarButton.TabIndex = 1;
            this.CarButton.Text = "Car";
            this.CarButton.UseVisualStyleBackColor = true;
            this.CarButton.Click += new System.EventHandler(this.CarButton_Click);
            // 
            // ballButton
            // 
            this.ballButton.Location = new System.Drawing.Point(95, 4);
            this.ballButton.Name = "ballButton";
            this.ballButton.Size = new System.Drawing.Size(75, 23);
            this.ballButton.TabIndex = 2;
            this.ballButton.Text = "Ball";
            this.ballButton.UseVisualStyleBackColor = true;
            this.ballButton.Click += new System.EventHandler(this.ballButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(358, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Coming Next";
            // 
            // buttonColor
            // 
            this.buttonColor.BackColor = System.Drawing.Color.Blue;
            this.buttonColor.Location = new System.Drawing.Point(193, 4);
            this.buttonColor.Name = "buttonColor";
            this.buttonColor.Size = new System.Drawing.Size(75, 23);
            this.buttonColor.TabIndex = 4;
            this.buttonColor.UseVisualStyleBackColor = false;
            this.buttonColor.Click += new System.EventHandler(this.buttonColor_Click);
            // 
            // buttonPresent
            // 
            this.buttonPresent.Location = new System.Drawing.Point(13, 185);
            this.buttonPresent.Name = "buttonPresent";
            this.buttonPresent.Size = new System.Drawing.Size(75, 23);
            this.buttonPresent.TabIndex = 5;
            this.buttonPresent.Text = "Present";
            this.buttonPresent.UseVisualStyleBackColor = true;
            this.buttonPresent.Click += new System.EventHandler(this.buttonPresent_Click);
            // 
            // buttonBox
            // 
            this.buttonBox.BackColor = System.Drawing.Color.Red;
            this.buttonBox.Location = new System.Drawing.Point(107, 185);
            this.buttonBox.Name = "buttonBox";
            this.buttonBox.Size = new System.Drawing.Size(75, 23);
            this.buttonBox.TabIndex = 6;
            this.buttonBox.UseVisualStyleBackColor = false;
            // 
            // buttonRibbon
            // 
            this.buttonRibbon.BackColor = System.Drawing.Color.Blue;
            this.buttonRibbon.Location = new System.Drawing.Point(107, 214);
            this.buttonRibbon.Name = "buttonRibbon";
            this.buttonRibbon.Size = new System.Drawing.Size(75, 23);
            this.buttonRibbon.TabIndex = 7;
            this.buttonRibbon.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 269);
            this.Controls.Add(this.buttonRibbon);
            this.Controls.Add(this.buttonBox);
            this.Controls.Add(this.buttonPresent);
            this.Controls.Add(this.buttonColor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ballButton);
            this.Controls.Add(this.CarButton);
            this.Controls.Add(this.mainPanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Timer createTimer;
        private System.Windows.Forms.Timer conveyorTimer;
        private System.Windows.Forms.Button CarButton;
        private System.Windows.Forms.Button ballButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonColor;
        private System.Windows.Forms.Button buttonPresent;
        private System.Windows.Forms.Button buttonBox;
        private System.Windows.Forms.Button buttonRibbon;
    }
}

