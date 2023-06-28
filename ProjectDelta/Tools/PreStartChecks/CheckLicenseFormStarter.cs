using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDelta.Tools.PreStartChecks
{
    internal class CheckLicenseFormStarter
    {
        public static void NewForm()
        {
            try
            {
                if (!Program.silent)
                {
                    CheckLicenseForm checkLicenseForm = new CheckLicenseForm();
                    checkLicenseForm.ShowDialog();
                }
            }
            catch (Exception e) { Console.WriteLine(e.ToString()); }
        }
    }
}
