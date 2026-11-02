using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Stuple.FileFormats;

namespace Test.Forms
{
    public partial class Stuple_FileFormats_Json : Form
    {
        public Stuple_FileFormats_Json()
        {
            InitializeComponent();
            //this.MinimumSize = this.Size;
            //this.MaximumSize = this.Size;
            this.TestItem = Test.Properties.Resources.StupleFileFormatsJsonTestFile.Split(new string[] { "#####" }, StringSplitOptions.None);
            this.json = new Json();
        }

        /// <summary>
        /// 測試文本
        /// </summary>
        string[] TestItem;
        /// <summary>
        /// Json 數據
        /// </summary>
        Json json;

        private void BtnPaste_Click(object sender, EventArgs e)
        {
            this.TextBoxInput.Clear();
            this.TextBoxInput.Text = Clipboard.GetText();
        }

        private void BtnTest1_Click(object sender, EventArgs e)
        {
            this.TextBoxInput.Clear();
            this.TextBoxInput.Text = this.TestItem[0].Trim();
        }

        private void BtnTest2_Click(object sender, EventArgs e)
        {
            this.TextBoxInput.Clear();
            this.TextBoxInput.Text = this.TestItem[1].Trim();
        }

        private void BtnTest3_Click(object sender, EventArgs e)
        {
            this.TextBoxInput.Clear();
            this.TextBoxInput.Text = this.TestItem[2].Trim();
        }

        private void BtnTest4_Click(object sender, EventArgs e)
        {
            this.TextBoxInput.Clear();
            this.TextBoxInput.Text = this.TestItem[3].Trim();
        }

        private void BtnTest5_Click(object sender, EventArgs e)
        {
            this.TextBoxInput.Clear();
            this.TextBoxInput.Text = this.TestItem[4].Trim();
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                this.json = new Json(this.TextBoxInput.Text);
                Command.ConsoleLog(this.json.PrintTree());
            }
            catch (Exception ex)
            {
                Command.ConsoleLog(ex.ToString(), ConsoleLogLevel.Error);
            }
        }
    }
}
