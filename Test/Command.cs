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
    }

    /// <summary>
    /// 全局变量
    /// </summary>
    public static class GlobalState
    {
        /// <summary>
        /// 主窗体
        /// </summary>
        public static Home? mian;
        /// <summary>
        /// 输出
        /// </summary>
        public static Output? output;
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
