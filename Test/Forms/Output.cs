using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Test.Properties;

namespace Test.Forms
{
    public partial class Output : Form
    {
        /// <summary>
        /// 记录键入命令行的历史记录
        /// </summary>
        public List<string> CommHistory = new List<string>();

        /// <summary>
        /// 构造函数
        /// </summary>
        public Output()
        {
            InitializeComponent();
            this.Left = 0 - ((this.Width - this.ClientSize.Width) / 2);
            this.Top = SystemInformation.WorkingArea.Height - this.Height + ((this.Width - this.ClientSize.Width) / 2);
        }

        private void Output_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            e.Cancel = true;
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (this.TextBoxOutput.TextLength == 0)
            {
                this.ContextMenuItemClear.Enabled = false;
            }
            else
            {
                this.ContextMenuItemClear.Enabled = true;
            }
            if (this.TextBoxOutput.SelectionLength == 0)
            {
                this.ContextMenuItemCopy.Enabled = false;
            }
            else
            {
                this.ContextMenuItemCopy.Enabled = true;
            }
            if (this.CommHistory.Count == 0)
            {
                if (ContextMenuItemHistory.DropDownItems.Count == 0)
                {
                    ToolStripMenuItem item = new ToolStripMenuItem();
                    item.Text = "None";
                    item.Enabled = false;
                    ContextMenuItemHistory.DropDownItems.Add(item);
                }
            }
            else
            {
                if (ContextMenuItemHistory.DropDownItems.Count > 0 && ContextMenuItemHistory.DropDownItems[0].Enabled == false)
                {
                    //ContextMenuItemHistory.DropDownItems[0].Dispose();
                    ContextMenuItemHistory.DropDownItems.RemoveAt(0);
                }

                //将历史记录追加到上下文选单
                //已移至追加历史记录的地方
            }
        }

        private void ContextMenuItemClear_Click(object sender, EventArgs e)
        {
            this.TextBoxOutput.Clear();
        }

        private void ContextMenuItemCopy_Click(object sender, EventArgs e)
        {
            if (this.TextBoxOutput.SelectionLength > 0)
            {
                Clipboard.SetText(this.TextBoxOutput.SelectedText);
            }
        }

        /// <summary>
        /// 记录命令的换挡位置, 反正是给 ↑↓ 用的
        /// </summary>
        public int TextBoxCommShiftIndex = 0;
        /// <summary>
        /// 命令行回车, 打命令行的地方
        /// </summary>
        private void TextBoxComm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Up) //箭头上 ↑
            {
                e.Handled = true;
                if(this.CommHistory.Count > 0)
                {
                    if(this.TextBoxCommShiftIndex > 0)
                    {
                        this.TextBoxCommShiftIndex--;
                    }
                    this.TextBoxComm.Text = this.CommHistory[this.TextBoxCommShiftIndex];
                    //this.TextBoxComm.SelectAll();
                    this.TextBoxComm.SelectionStart = this.TextBoxComm.Text.Length;
                }
            }
            else if(e.KeyCode == Keys.Down) //箭头下 ↓
            {
                e.Handled = true;
                if (this.CommHistory.Count > 0)
                {
                    if(this.TextBoxCommShiftIndex < this.CommHistory.Count)
                    {
                        this.TextBoxCommShiftIndex++;
                    }
                    if(this.TextBoxCommShiftIndex == this.CommHistory.Count)
                    {
                        this.TextBoxComm.Clear();
                    }
                    else
                    {
                        this.TextBoxComm.Text = this.CommHistory[this.TextBoxCommShiftIndex];
                        //this.TextBoxComm.SelectAll();
                        this.TextBoxComm.SelectionStart = this.TextBoxComm.Text.Length;
                    }
                }
            }
            else if (e.KeyCode == Keys.Enter) //回车
            {
                e.Handled = true;
                string input = this.TextBoxComm.Text.Trim();
                if (input.Length > 0)
                {
                    this.TextBoxComm.Clear();
                    string[] commands = input.Split(' ');

                    //供 switch 使用的公共变数
                    int index;
                    string msg = "";
                    string[] msgs;
                    ConsoleLogLevel level;

                    //遍历目标可用指令并执行
                    switch (commands[0].ToLower())
                    {
                        //结束
                        case "exit":
                            Command.ConsoleLog("离开. ");
                            GlobalState.mian!.Close();
                            break;
                        //强制垃圾回收
                        case "gc":
                            Command.ConsoleLog("强制垃圾回收. ");
                            GC.Collect();
                            break;
                        //打印文本
                        case "echo":
                        case "print":
                            if (commands.Length == 1)
                            {
                                Command.ConsoleLog("[PRINT]缺少文本或指定消息等级. ", ConsoleLogLevel.Error);
                            }
                            else if (commands.Length == 2)
                            {
                                Command.ConsoleLog(commands[1]);
                            }
                            else
                            {
                                index = 1;
                                level = ConsoleLogLevel.Normal;
                                switch (commands[1].ToLower())
                                {
                                    case "0":
                                    case "nor":
                                    case "normal":
                                        index = 2;
                                        level = ConsoleLogLevel.Normal;
                                        break;
                                    case "1":
                                    case "warn":
                                    case "warning":
                                        index = 2;
                                        level = ConsoleLogLevel.Warning;
                                        break;
                                    case "2":
                                    case "err":
                                    case "error":
                                        index = 2;
                                        level = ConsoleLogLevel.Error;
                                        break;
                                    default:
                                        index = 1;
                                        level = ConsoleLogLevel.Normal;
                                        break;
                                }
                                msg = "";
                                for(int i = index; i < commands.Length; i++)
                                {
                                    msg = msg + commands[i] + " ";
                                }
                                msg.Remove(msg.Length - 1);
                                Command.ConsoleLog(msg, level);
                            }
                                break;
                        //关于
                        case "about":
                            GlobalState.mian!.StatusBarVersion_Click(null, null);
                            break;
                        //帮助
                        case "help":
                            Command.ConsoleLog(Resources.TextBoxCommHelp);
                            break;
                        //啥也不是
                        default:
                            Command.ConsoleLog("未知指令: \"" + input + "\"", ConsoleLogLevel.Error);
                            break;
                    }

                    //追加历史记录
                    //先检查记录里是否存在该条指令
                    int findindex = this.CommHistory.IndexOf(input);
                    if (findindex != -1)
                    {
                        this.CommHistory.RemoveAt(findindex);
                        this.CommHistory.Add(input);
                        ToolStripItem item = ContextMenuItemHistory.DropDownItems[findindex];
                        ContextMenuItemHistory.DropDownItems.RemoveAt(findindex);
                        ContextMenuItemHistory.DropDownItems.Add(item);
                    }
                    else
                    {
                        this.CommHistory.Add(input);
                        //添加上下文选单
                        ToolStripMenuItem item = new ToolStripMenuItem();
                        item.Text = input;
                        item.Click += new EventHandler((object? sender, EventArgs e) =>
                        {
                            this.TextBoxComm.Text = item.Text;
                            //this.TextBoxComm.SelectAll();
                            this.TextBoxComm.SelectionStart = this.TextBoxComm.Text.Length;
                        });
                        ContextMenuItemHistory.DropDownItems.Add(item);
                    }
                    this.TextBoxCommShiftIndex = this.CommHistory.Count;
                }
            }
        }

        /// <summary>
        /// 将消息打印到输出狂
        /// </summary>
        /// <param name="msg">要打印的讯息</param>
        /// <param name="level">消息类型</param>
        public void Append(string msg, ConsoleLogLevel? level = null)
        {
            int selstart = this.TextBoxOutput.TextLength;
            this.TextBoxOutput.AppendText(msg);
            int _level = 0;
            if(level != null)
            {
                _level = (int)level;
            }

            switch (_level)
            {
                case 1: //警告
                    this.TextBoxOutput.Select(selstart, this.TextBoxOutput.TextLength - selstart);
                    this.TextBoxOutput.SelectionColor = Color.Orange;
                    this.TextBoxOutput.Select(this.TextBoxOutput.TextLength, 0);
                    this.TextBoxOutput.SelectionColor = SystemColors.WindowText;
                    break;
                case 2: //错误
                    this.TextBoxOutput.Select(selstart, this.TextBoxOutput.TextLength - selstart);
                    this.TextBoxOutput.SelectionColor = Color.Red;
                    this.TextBoxOutput.Select(this.TextBoxOutput.TextLength, 0);
                    this.TextBoxOutput.SelectionColor = SystemColors.WindowText;
                    break;
            }

            this.TextBoxOutput.ScrollToCaret();
        }
    }
}
