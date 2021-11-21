using System;
using System.Windows.Forms;


namespace cd.Exceptionless
{
    public class Information
    {
        public static void ShowMessage(Exception ex)
        {
            ShowMessage(new MetroMessageBoxControl(), ex);
        }
        public static void ShowMessage(IWin32Window owner, Exception ex)
        {
            string str = "";
            string strDateInfo = "出现应用程序未处理的异常：" + DateTime.Now.ToString() + "\r\n";
            if (ex != null)
            {
                str = string.Format(strDateInfo + "异常类型：{0}\r\n异常消息：{1}\r\n异常信息：{2}\r\n",
                   ex.GetType().Name, ex.Message, ex.StackTrace);
            }
            else
            {
                str = string.Format("应用程序线程错误:{0}", ex);
            }
            MetroMessageBox.Show(owner, str, "系统错误");
            ExceptionEx.ExceptionSubmit(ex);


        }      

        public static void ShowMessage(IWin32Window owner, string msg)
        {
            MetroMessageBox.Show(owner, msg, "系统提示");
        }

        


    }
}
