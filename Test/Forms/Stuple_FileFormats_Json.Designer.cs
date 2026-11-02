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
            TextBoxInput = new TextBox();
            panel1 = new Panel();
            BtnTest5 = new Button();
            BtnTest4 = new Button();
            BtnTest3 = new Button();
            BtnTest2 = new Button();
            BtnTest1 = new Button();
            BtnPaste = new Button();
            BtnPrint = new Button();
            BtnToString = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // TextBoxInput
            // 
            TextBoxInput.Dock = DockStyle.Fill;
            TextBoxInput.Location = new Point(0, 0);
            TextBoxInput.MaxLength = int.MaxValue;
            TextBoxInput.Multiline = true;
            TextBoxInput.Name = "TextBoxInput";
            TextBoxInput.ScrollBars = ScrollBars.Both;
            TextBoxInput.Size = new Size(1235, 712);
            TextBoxInput.TabIndex = 1;
            TextBoxInput.Text = "{}";
            // 
            // panel1
            // 
            panel1.Controls.Add(BtnTest5);
            panel1.Controls.Add(BtnTest4);
            panel1.Controls.Add(BtnTest3);
            panel1.Controls.Add(BtnTest2);
            panel1.Controls.Add(BtnTest1);
            panel1.Controls.Add(BtnPaste);
            panel1.Controls.Add(BtnPrint);
            panel1.Controls.Add(BtnToString);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(1235, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(234, 712);
            panel1.TabIndex = 0;
            // 
            // BtnTest5
            // 
            BtnTest5.Location = new Point(10, 172);
            BtnTest5.Name = "BtnTest5";
            BtnTest5.Size = new Size(212, 34);
            BtnTest5.TabIndex = 3;
            BtnTest5.Text = "测试5";
            BtnTest5.UseVisualStyleBackColor = true;
            BtnTest5.Click += BtnTest5_Click;
            // 
            // BtnTest4
            // 
            BtnTest4.Location = new Point(10, 132);
            BtnTest4.Name = "BtnTest4";
            BtnTest4.Size = new Size(212, 34);
            BtnTest4.TabIndex = 3;
            BtnTest4.Text = "测试4";
            BtnTest4.UseVisualStyleBackColor = true;
            BtnTest4.Click += BtnTest4_Click;
            // 
            // BtnTest3
            // 
            BtnTest3.Location = new Point(10, 92);
            BtnTest3.Name = "BtnTest3";
            BtnTest3.Size = new Size(212, 34);
            BtnTest3.TabIndex = 3;
            BtnTest3.Text = "测试3";
            BtnTest3.UseVisualStyleBackColor = true;
            BtnTest3.Click += BtnTest3_Click;
            // 
            // BtnTest2
            // 
            BtnTest2.Location = new Point(10, 52);
            BtnTest2.Name = "BtnTest2";
            BtnTest2.Size = new Size(212, 34);
            BtnTest2.TabIndex = 3;
            BtnTest2.Text = "测试2";
            BtnTest2.UseVisualStyleBackColor = true;
            BtnTest2.Click += BtnTest2_Click;
            // 
            // BtnTest1
            // 
            BtnTest1.Location = new Point(10, 12);
            BtnTest1.Name = "BtnTest1";
            BtnTest1.Size = new Size(212, 34);
            BtnTest1.TabIndex = 3;
            BtnTest1.Text = "测试1";
            BtnTest1.UseVisualStyleBackColor = true;
            BtnTest1.Click += BtnTest1_Click;
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
            BtnPrint.Click += BtnPrint_Click;
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
            Controls.Add(TextBoxInput);
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
        public TextBox TextBoxInput;
        private Button BtnTest1;
        private Button BtnTest5;
        private Button BtnTest4;
        private Button BtnTest3;
        private Button BtnTest2;
    }
}