using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test.Forms
{
    public partial class Stuple_FileFormats_Json : Form
    {
        public Stuple_FileFormats_Json()
        {
            InitializeComponent();
            //this.MinimumSize = this.Size;
            //this.MaximumSize = this.Size;
        }

        private void BtnPaste_Click(object sender, EventArgs e)
        {
            this.TextBoxOutput.Clear();
            this.TextBoxOutput.Text = Clipboard.GetText();
        }
    }
}
