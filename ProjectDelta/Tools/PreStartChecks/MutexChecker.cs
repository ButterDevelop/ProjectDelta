using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectDelta.Tools.PreStartChecks
{
    internal class MutexChecker
    {
        public static void CheckMutex()
        {
            int i = -1;
            while (i <= 100)
            {
                try
                {
                    ++i;
                    Mutex.OpenExisting("Project_Delta_" + i.ToString());

                    if (i == 0 && Program.singleInstance) Environment.Exit(0);
                }
                catch { break; }
            }
            bool createdMutex = false;
            Mutex mutex = new Mutex(false, "Project_Delta_" + i.ToString(), out createdMutex);
            if (createdMutex)
            {
                Program.MutexNumber = i.ToString();
                Program.CreatedMutex = mutex;
            }
            else
            {
                mutex.Close();
                if (!Program.silent) MessageBox.Show("Program is already opened!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
        }
    }
}
