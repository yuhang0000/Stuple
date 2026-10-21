namespace Test.Forms
{
    partial class Stuple_FileFormats
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
            BtnJson = new Button();
            BtnExit = new Button();
            SuspendLayout();
            // 
            // BtnJson
            // 
            BtnJson.Location = new Point(12, 12);
            BtnJson.Name = "BtnJson";
            BtnJson.Size = new Size(377, 50);
            BtnJson.TabIndex = 0;
            BtnJson.Text = "Json";
            BtnJson.UseVisualStyleBackColor = true;
            BtnJson.Click += BtnJson_Click;
            // 
            // BtnExit
            // 
            BtnExit.Location = new Point(-12, -12);
            BtnExit.Name = "BtnExit";
            BtnExit.Size = new Size(0, 0);
            BtnExit.TabIndex = 1;
            BtnExit.Text = "离开";
            BtnExit.UseVisualStyleBackColor = true;
            BtnExit.Click += BtnExit_Click;
            // 
            // Stuple_FileFormats
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = BtnExit;
            ClientSize = new Size(401, 450);
            Controls.Add(BtnExit);
            Controls.Add(BtnJson);
            Name = "Stuple_FileFormats";
            Text = "Stuple.FileFormats";
            ResumeLayout(false);
        }

        #endregion

        private Button BtnJson;
        private Button BtnExit;
    }
}