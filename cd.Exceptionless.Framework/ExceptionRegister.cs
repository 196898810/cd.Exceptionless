using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cd.Exceptionless
{
    public  class ExceptionRegister
    {
        public static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            Information.ShowMessage(new MetroMessageBoxControl(), e.Exception as Exception);
        }

        public static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Information.ShowMessage(new MetroMessageBoxControl(), e.ExceptionObject as Exception);
        }
    }
}
