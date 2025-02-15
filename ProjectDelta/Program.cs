using ProjectDelta.Controllers;
using ProjectDelta.Forms;
using ProjectDelta.Tools.PreStartChecks;
using System;
using System.Threading;
using System.Windows.Forms;

namespace ProjectDelta
{
    internal static class Program
    {
        public static Mutex CreatedMutex;
        public static string MutexNumber = "000";
        public static bool singleInstance = true, disableAutoUpdateCheck = false, silent = false;

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo("en-US");
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo("en-US");

            foreach (var arg in args)
            {
                switch (arg.Remove(0, 1).ToLower())
                {
                    case "disablesingleinstance": singleInstance = false; break;
                    case "disableautoupdatecheck": disableAutoUpdateCheck = true; break;
                    case "silent": silent = true; break;
                    default: break;
                }
            }

            //var t = new Thread(() => CheckLicenseFormStarter.NewForm());
            //t.Start();
            //Thread.Sleep(100);

            //DLLHash.CheckDLLHash();
            //MutexChecker.CheckMutex();
            //CheckLicense.Check();

            //Thread.Sleep(100);
            //t.Abort();

            //if (!disableAutoUpdateCheck && !silent && UpdateChecker.NewVersion()) Application.Run(new ChangeLog());

            var initThread = new Thread(() => InitializingForm.StartNewInitForm());
            initThread.Start();
            while (!InitializingForm.ShutDownForm) { Thread.Sleep(1000); }
            initThread.Abort();

            new Thread(() => DBController.SaveWithCheck()).Start();
            Thread.Sleep(250);

            Application.Run(new MainForm());
        }
    }
}
