using DanielBogdan.PlainRSS.Core.Logging;
using System;
using System.Windows.Forms;


namespace DanielBogdan.PlainRSS.UI
{
    static class Program
    {

        private static readonly Logger Logger =
            new Logger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Add the event handler for handling UI thread exceptions to the event.
            Application.ThreadException += (sender, args) => FatalExceptionHandler(args.Exception);
            // Set the unhandled exception mode to force all Windows Forms errors to go through
            // our handler.
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            // Add the event handler for handling non-UI thread exceptions to the event. 
            AppDomain.CurrentDomain.UnhandledException += (sender, args) => FatalExceptionHandler(args.ExceptionObject);


            try
            {
                Application.Run(new MainForm());
            }
            catch (Exception exception)
            {
                Logger.Fatal($"{nameof(Program)} fatal exception", exception);

                FatalExceptionHandler(exception);
            }


        }

        /// <summary>
        /// Handle critical errors and show a friendly message (containing technical information though) before crashing application
        /// </summary>
        /// <param name="exceptionObject"></param>
        private static void FatalExceptionHandler(object exceptionObject)
        {
            var exception = exceptionObject as Exception;
            if (exception == null)
            {
                exception = new NotSupportedException(
                    "Unhandled exception doesn't derive from System.Exception: "
                    + exceptionObject.ToString()
                );
            }

            MessageBox.Show(@"An application error occured. Please report this issue to your software vendor:" + Environment.NewLine + Environment.NewLine + exception.ToString(),
                @"Unhandled exception",
                MessageBoxButtons.OK, MessageBoxIcon.Error);

            Application.Exit();
        }
    }
}