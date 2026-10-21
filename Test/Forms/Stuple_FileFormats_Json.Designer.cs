namespace Test.Forms
{
    partial class Stuple_FileFormats_Json
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
            TextBoxOutput = new TextBox();
            panel1 = new Panel();
            BtnPaste = new Button();
            BtnPrint = new Button();
            BtnToString = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // TextBoxOutput
            // 
            TextBoxOutput.Dock = DockStyle.Fill;
            TextBoxOutput.Location = new Point(0, 0);
            TextBoxOutput.MaxLength = int.MaxValue;
            TextBoxOutput.Multiline = true;
            TextBoxOutput.Name = "TextBoxOutput";
            TextBoxOutput.ScrollBars = ScrollBars.Both;
            TextBoxOutput.Size = new Size(1235, 712);
            TextBoxOutput.TabIndex = 1;
            TextBoxOutput.Text = "{}";
            // 
            // panel1
            // 
            panel1.Controls.Add(BtnPaste);
            panel1.Controls.Add(BtnPrint);
            panel1.Controls.Add(BtnToString);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(1235, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(234, 712);
            panel1.TabIndex = 0;
            // 
            // BtnPaste
            // 
            BtnPaste.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BtnPaste.Location = new Point(10, 614);
            BtnPaste.Name = "BtnPaste";
            BtnPaste.Size = new Size(103, 40);
            BtnPaste.TabIndex = 0;
            BtnPaste.Text = "贴入";
            BtnPaste.UseVisualStyleBackColor = true;
            BtnPaste.Click += BtnPaste_Click;
            // 
            // BtnPrint
            // 
            BtnPrint.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BtnPrint.Location = new Point(10, 660);
            BtnPrint.Name = "BtnPrint";
            BtnPrint.Size = new Size(212, 40);
            BtnPrint.TabIndex = 2;
            BtnPrint.Text = "列印为树状文本";
            BtnPrint.UseVisualStyleBackColor = true;
            // 
            // BtnToString
            // 
            BtnToString.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BtnToString.Location = new Point(119, 614);
            BtnToString.Name = "BtnToString";
            BtnToString.Size = new Size(103, 40);
            BtnToString.TabIndex = 1;
            BtnToString.Text = "列印";
            BtnToString.UseVisualStyleBackColor = true;
            // 
            // Stuple_FileFormats_Json
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1469, 712);
            Controls.Add(TextBoxOutput);
            Controls.Add(panel1);
            Name = "Stuple_FileFormats_Json";
            Text = "Stuple.FileFormats.Json";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button BtnPaste;
        private Button BtnToString;
        private Button BtnPrint;
        public TextBox TextBoxOutput;
    }
}