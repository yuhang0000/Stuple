using Stuple.Commands;

namespace Test
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            DateTime date = DateTime.Now;

            ApplicationConfiguration.Initialize();
            GlobalState.output = new Forms.Output();
            GlobalState.mian = new Forms.Home();
            GlobalState.output.Show();
            Command.ConsoleLog("Æô¶¯ÓÚ: " + ToolKit.FixDateTime(date, 0));
            Application.Run(GlobalState.mian);
        }
    }
}