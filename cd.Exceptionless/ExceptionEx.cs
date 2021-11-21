using Exceptionless;
using Exceptionless.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cd.Exceptionless
{
    public class ExceptionEx
    {
        // <summary>
        ///使用Exceptionless上传异常日志
        /// </summary>
        /// <param name="ex">异常信息</param>
        public static void ExceptionSubmit(Exception ex)
        {

            ex.ToExceptionless().Submit();
        }

        // <summary>
        ///使用Exceptionless上传自定义日志
        /// </summary>
        /// <param name="message">日志信息</param>
        /// <param name="notic">传入描述</param>
        public static void ExceptionSubmit(string message, string notic = "日志", int logLeverl = 1)
        {
            LogLevel level = LogLevel.Info;

            switch (logLeverl)
            {
                case 1:
                    level = LogLevel.Other;
                    break;
                case 2:
                    level = LogLevel.Warn;
                    break;
                case 3:
                    level = LogLevel.Error;
                    break;
                case 4:
                    level = LogLevel.Fatal;
                    break;
            }
            if (message.Length > 2000)
                ExceptionlessClient.Default.SubmitLog(notic, message.Substring(0, 2000), level);
            else
                ExceptionlessClient.Default.SubmitLog(notic, message, level);

        }

    }

    public enum Level
    {
        Info,
        Other,
        Warn,
        Error,
        Fatal
    }
}
