namespace RomsetFilterApp
{
    internal static class Program
    {
        public static string LogFileLocation = $"{Environment.CurrentDirectory}\\ErrorLog.txt";

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += new
                ThreadExceptionEventHandler(Catch);
            AppDomain.CurrentDomain.UnhandledException += new
            UnhandledExceptionEventHandler(Catch);

            ApplicationConfiguration.Initialize();
            Application.Run(new MainWindow());

        }


        static void Catch(object sender, ThreadExceptionEventArgs e)
        {
            MessageBox.Show($"An error has occured with the following message:{Environment.NewLine} {e.Exception.Message}" +
                $"{Environment.NewLine}{Environment.NewLine}Please contact the developer with the log file found at {LogFileLocation}");
            Log("MyHandler caught : " + e.Exception.Message);
            Log("Stack Trace : " + e.Exception.StackTrace);
        }

        static void Catch(object sender, UnhandledExceptionEventArgs args)
        {
            Exception e = (Exception)args.ExceptionObject;
            Log("MyHandler caught : " + e.Message); 
            Log("Stack Trace : " + e.StackTrace);
        }

        static void Log(string message)
        {
            File.WriteAllText(LogFileLocation, message);
        }
    }
}