using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stuple.Commands;

namespace Test
{
    /// <summary>
    /// 命令集
    /// </summary>
    internal class Command
    {
        /// <summary>
        /// 打印调试信息在输出窗体
        /// </summary>
        /// <param name="msg">要打印的消息</param>
        /// <param name="level">消息等级</param>
        public static void ConsoleLog(string msg, ConsoleLogLevel? level= null)
        {
            msg = ToolKit.FixDateTime() + "|" + msg;
            Console.WriteLine(msg);
            if(GlobalState.output != null)
            {
                //调用方不在一个 UI 线程
                if(GlobalState.output.TextBoxOutput.InvokeRequired == true)
                {
                    GlobalState.output.TextBoxOutput.Invoke(new MethodInvoker( () =>
                    {
                        GlobalState.output.Append(msg + "\r\n", level);
                    }));
                }
                else
                {
                    GlobalState.output.Append(msg + "\r\n", level);
                }
            }
        }

        /// <summary>
        /// 显示窗体, 若窗体不存在就创建
        /// </summary>
        /// <typeparam name="T">这个好像是泛型</typeparam>
        /// <param name="Form">目标窗体</param>
        public static void ShowOrActivateForm<T>(ref T? Form) where T : Form, new() //T 泛型, 就是个 "变量类型" 的占位符; where T : Form, T 是谁, 这里 T 是 Form; new(), 不知道, 但是如果要创建窗体的话, T() == new Form()
        {
            if(Form == null || Form.IsDisposed == true)
            {
                Form = new T();
                Form.Show();
            }
            else
            {
                Form.WindowState = FormWindowState.Normal;
                Form.Activate();
            }
        }
    }

    /// <summary>
    /// 全局变量
    /// </summary>
    public static class GlobalState
    {
        /// <summary>
        /// 主窗体
        /// </summary>
        public static Forms.Home? mian;
        /// <summary>
        /// 输出
        /// </summary>
        public static Forms.Output? output;

        public static Forms.Stuple_FileFormats? Stuple_FileFormats;

        public static Forms.Stuple_FileFormats_Json? Stuple_FileFormats_Json;
    }

    /// <summary>
    /// 输出打印等级
    /// </summary>
    public enum ConsoleLogLevel
    {
        /// <summary>
        /// 正常
        /// </summary>
        Normal = 0,
        /// <summary>
        /// 警告
        /// </summary>
        Warning = 1,
        /// <summary>
        /// 错误
        /// </summary>
        Error = 2,
    }
}
