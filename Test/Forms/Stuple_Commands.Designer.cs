namespace Test.Forms
{
    partial class Stuple_Commands
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
            BtnToolKit = new Button();
            BtnExit = new Button();
            SuspendLayout();
            // 
            // BtnToolKit
            // 
            BtnToolKit.Location = new Point(12, 12);
            BtnToolKit.Name = "BtnToolKit";
            BtnToolKit.Size = new Size(377, 50);
            BtnToolKit.TabIndex = 0;
            BtnToolKit.Text = "ToolKit";
            BtnToolKit.UseVisualStyleBackColor = true;
            BtnToolKit.Click += BtnToolKit_Click;
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
            // Stuple_Commands
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = BtnExit;
            ClientSize = new Size(401, 450);
            Controls.Add(BtnExit);
            Controls.Add(BtnToolKit);
            Name = "Stuple_Commands";
            Text = "Stuple.Commands";
            ResumeLayout(false);
        }

        #endregion

        private Button BtnToolKit;
        private Button BtnExit;
    }
}