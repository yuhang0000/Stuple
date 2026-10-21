namespace Test.Forms
{
    partial class Output
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
            components = new System.ComponentModel.Container();
            panel1 = new Panel();
            TextBoxComm = new TextBox();
            TextBoxOutput = new RichTextBox();
            contextMenuStrip1 = new ContextMenuStrip(components);
            ContextMenuItemClear = new ToolStripMenuItem();
            ContextMenuItemCopy = new ToolStripMenuItem();
            ContextMenuItemHistory = new ToolStripMenuItem();
            panel1.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(TextBoxComm);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 353);
            panel1.Name = "panel1";
            panel1.Size = new Size(1016, 27);
            panel1.TabIndex = 0;
            // 
            // TextBoxComm
            // 
            TextBoxComm.Dock = DockStyle.Fill;
            TextBoxComm.Location = new Point(0, 0);
            TextBoxComm.Name = "TextBoxComm";
            TextBoxComm.Size = new Size(1016, 27);
            TextBoxComm.TabIndex = 0;
            TextBoxComm.KeyDown += TextBoxComm_KeyDown;
            // 
            // TextBoxOutput
            // 
            TextBoxOutput.BorderStyle = BorderStyle.None;
            TextBoxOutput.ContextMenuStrip = contextMenuStrip1;
            TextBoxOutput.Dock = DockStyle.Fill;
            TextBoxOutput.Location = new Point(0, 0);
            TextBoxOutput.Name = "TextBoxOutput";
            TextBoxOutput.ReadOnly = true;
            TextBoxOutput.ScrollBars = RichTextBoxScrollBars.ForcedBoth;
            TextBoxOutput.Size = new Size(1016, 353);
            TextBoxOutput.TabIndex = 1;
            TextBoxOutput.Text = "";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { ContextMenuItemClear, ContextMenuItemCopy, ContextMenuItemHistory });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(109, 76);
            contextMenuStrip1.Opening += contextMenuStrip1_Opening;
            // 
            // ContextMenuItemClear
            // 
            ContextMenuItemClear.Name = "ContextMenuItemClear";
            ContextMenuItemClear.Size = new Size(108, 24);
            ContextMenuItemClear.Text = "清空";
            ContextMenuItemClear.Click += ContextMenuItemClear_Click;
            // 
            // ContextMenuItemCopy
            // 
            ContextMenuItemCopy.Name = "ContextMenuItemCopy";
            ContextMenuItemCopy.Size = new Size(108, 24);
            ContextMenuItemCopy.Text = "复制";
            ContextMenuItemCopy.Click += ContextMenuItemCopy_Click;
            // 
            // ContextMenuItemHistory
            // 
            ContextMenuItemHistory.Name = "ContextMenuItemHistory";
            ContextMenuItemHistory.Size = new Size(108, 24);
            ContextMenuItemHistory.Text = "历史";
            // 
            // Output
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1016, 380);
            Controls.Add(TextBoxOutput);
            Controls.Add(panel1);
            Name = "Output";
            StartPosition = FormStartPosition.Manual;
            Text = "输出";
            FormClosing += Output_FormClosing;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        public TextBox TextBoxComm;
        public RichTextBox TextBoxOutput;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem ContextMenuItemClear;
        private ToolStripMenuItem ContextMenuItemCopy;
        private ToolStripMenuItem ContextMenuItemHistory;
    }
}