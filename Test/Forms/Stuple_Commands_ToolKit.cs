using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Stuple.Commands;

namespace Test.Forms
{
    public partial class Stuple_Commands_ToolKit : Form
    {
        public Stuple_Commands_ToolKit()
        {
            InitializeComponent();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text;
            switch (this.numericUpDown1.Value)
            {
                default:
                case -1:
                    text = ToolKit.FixDateTime(null, ToolKit.FixDataTimeType.Default);
                    break;
                case 0:
                    text = ToolKit.FixDateTime(null, ToolKit.FixDataTimeType.DashWithDate);
                    break;
                case 1:
                    text = ToolKit.FixDateTime(null, ToolKit.FixDataTimeType.SlashWithDate);
                    break;
                case 2:
                    text = ToolKit.FixDateTime(null, ToolKit.FixDataTimeType.DashDateOnly);
                    break;
                case 3:
                    text = ToolKit.FixDateTime(null, ToolKit.FixDataTimeType.SlashDateOnly);
                    break;
                case 4:
                    text = ToolKit.FixDateTime(null, ToolKit.FixDataTimeType.TimeOnly);
                    break;
                case 5:
                    text = ToolKit.FixDateTime(null, ToolKit.FixDataTimeType.ChineseData);
                    break;
                case 6:
                    text = ToolKit.FixDateTime(null, ToolKit.FixDataTimeType.ChineseDateWithWeek);
                    break;
                case 7:
                    text = ToolKit.FixDateTime(null, ToolKit.FixDataTimeType.ChineseDateWeekNotTime);
                    break;
                case 8:
                    text = ToolKit.FixDateTime(null, ToolKit.FixDataTimeType.WeekOnly);
                    break;
            }
            Command.ConsoleLog(text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Command.ConsoleLog(ToolKit.NumAbbr(this.textBox1.Text, (int)this.numericUpDown2.Value));
            }
            catch (Exception ex)
            {
                Command.ConsoleLog(ex.ToString(), ConsoleLogLevel.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (this.checkBox1.Checked == true)
            {
                this.textBox3.Text = ToolKit.GetTimeStampMs().ToString();
            }
            else
            {
                this.textBox3.Text = ToolKit.GetTimeStamp().ToString();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Command.ConsoleLog(ToolKit.FixDateTime(ToolKit.TimeStamp2Date(long.Parse(this.textBox3.Text)), ToolKit.FixDataTimeType.DashWithDate));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Command.ConsoleLog(ToolKit.NumUnAbbr(this.textBox2.Text));
            }
            catch (Exception ex)
            {
                Command.ConsoleLog(ex.ToString(), ConsoleLogLevel.Error);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                Command.ConsoleLog(ToolKit.GetExt4Url(this.textBox6.Text)!);
            }
            catch (Exception ex)
            {
                Command.ConsoleLog(ex.ToString(), ConsoleLogLevel.Error);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> array = new List<string>();
                Dictionary<string, string> dict = ToolKit.GetDict4Url(this.textBox6.Text)!;
                array.Add("总计: " + dict.Count + " 个");
                foreach (string key in dict.Keys)
                {
                    string? value = dict[key];
                    if (value == null)
                    {
                        array.Add(key);
                    }
                    else
                    {
                        array.Add(key + ": " + value);
                    }
                }
                Command.ConsoleLog(string.Join("\r\n", array));
            }
            catch (Exception ex)
            {
                Command.ConsoleLog(ex.ToString(), ConsoleLogLevel.Error);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                string[] array = this.textBox5.Text.Split(',');
                int scopestart = int.Parse(array[0]);
                int scopelength = int.Parse(array[1]);
                int pointerstart = int.Parse(array[2]);
                int pointerlength = int.Parse(array[3]);
                Command.ConsoleLog(ToolKit.ShowCaretPointer(this.textBox4.Text, scopestart, scopelength, pointerstart, pointerlength));
            }
            catch (Exception ex)
            {
                Command.ConsoleLog(ex.ToString(), ConsoleLogLevel.Error);
            }
        }
    }
}
