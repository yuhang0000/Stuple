using System.Reflection;

namespace Test.Forms
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;
            this.StatusBarVersion.Text = "v" + Assembly.GetExecutingAssembly().GetName().Version;
        }

        public void StatusBarVersion_Click(object? sender, EventArgs? e)
        {
            string[] about =
            {
                "Stuple Library Test Programm",
                "By: yuhang0000",
                "Build Time: " + File.GetCreationTime(Application.ExecutablePath),
                "Version: " + Assembly.GetExecutingAssembly().GetName().Version,
            };
            MessageBox.Show(string.Join("\r\n", about), "¹ØÓÚ");
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Home_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void BtnOutput_Click(object sender, EventArgs e)
        {
            Command.ShowOrActivateForm<Forms.Output>(ref GlobalState.output);
        }

        private void BtnFileFormats_Click(object sender, EventArgs e)
        {
            Command.ShowOrActivateForm<Forms.Stuple_FileFormats>(ref GlobalState.Stuple_FileFormats);
        }
    }
}
