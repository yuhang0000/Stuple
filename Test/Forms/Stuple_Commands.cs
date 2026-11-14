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
    public partial class Stuple_Commands : Form
    {
        public Stuple_Commands()
        {
            InitializeComponent();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void BtnToolKit_Click(object sender, EventArgs e)
        {
            Command.ShowOrActivateForm<Stuple_Commands_ToolKit>(ref GlobalState.Stuple_Commands_ToolKit);
        }
    }
}
