namespace Test
{
    partial class Home
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
            BtnCommands = new Button();
            BtnVariables = new Button();
            BtnFileFormats = new Button();
            statusStrip1 = new StatusStrip();
            StatusBarVersion = new ToolStripStatusLabel();
            BtnOutput = new Button();
            BtnExit = new Button();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // BtnCommands
            // 
            BtnCommands.Location = new Point(12, 12);
            BtnCommands.Name = "BtnCommands";
            BtnCommands.Size = new Size(172, 46);
            BtnCommands.TabIndex = 2;
            BtnCommands.Text = "Stuple.Commands";
            BtnCommands.UseVisualStyleBackColor = true;
            // 
            // BtnVariables
            // 
            BtnVariables.Location = new Point(190, 12);
            BtnVariables.Name = "BtnVariables";
            BtnVariables.Size = new Size(172, 46);
            BtnVariables.TabIndex = 3;
            BtnVariables.Text = "Stuple.Variables";
            BtnVariables.UseVisualStyleBackColor = true;
            // 
            // BtnFileFormats
            // 
            BtnFileFormats.Location = new Point(368, 12);
            BtnFileFormats.Name = "BtnFileFormats";
            BtnFileFormats.Size = new Size(172, 46);
            BtnFileFormats.TabIndex = 4;
            BtnFileFormats.Text = "Stuple.FileFormats";
            BtnFileFormats.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { StatusBarVersion });
            statusStrip1.Location = new Point(0, 424);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(800, 26);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // StatusBarVersion
            // 
            StatusBarVersion.Name = "StatusBarVersion";
            StatusBarVersion.Size = new Size(65, 20);
            StatusBarVersion.Text = "v0.0.0.1";
            StatusBarVersion.Click += StatusBarVersion_Click;
            // 
            // BtnOutput
            // 
            BtnOutput.Location = new Point(12, 392);
            BtnOutput.Name = "BtnOutput";
            BtnOutput.Size = new Size(94, 29);
            BtnOutput.TabIndex = 1;
            BtnOutput.Text = "输出";
            BtnOutput.UseVisualStyleBackColor = true;
            BtnOutput.Click += BtnOutput_Click;
            // 
            // BtnExit
            // 
            BtnExit.Location = new Point(112, 392);
            BtnExit.Name = "BtnExit";
            BtnExit.Size = new Size(94, 29);
            BtnExit.TabIndex = 0;
            BtnExit.Text = "离开";
            BtnExit.UseVisualStyleBackColor = true;
            BtnExit.Click += BtnExit_Click;
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(BtnExit);
            Controls.Add(BtnOutput);
            Controls.Add(statusStrip1);
            Controls.Add(BtnFileFormats);
            Controls.Add(BtnVariables);
            Controls.Add(BtnCommands);
            Name = "Home";
            Text = "测试";
            FormClosing += Home_FormClosing;
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BtnCommands;
        private Button BtnVariables;
        private Button BtnFileFormats;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel StatusBarVersion;
        private Button BtnOutput;
        private Button BtnExit;
    }
}
