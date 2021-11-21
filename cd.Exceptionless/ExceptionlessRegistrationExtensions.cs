using Exceptionless;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace cd.Exceptionless
{
    public static class ExceptionlessRegistrationExtensions
    {
        public static void UseExceptionless(this IApplicationBuilder app, IConfiguration configuration)
        {
            ExceptionlessClient.Default.Configuration.ApiKey = configuration.GetSection("Exceptionless:apikey").Value;
            ExceptionlessClient.Default.Configuration.ServerUrl = configuration.GetSection("Exceptionless:ServerUrl").Value;
            ExceptionlessClient.Default.SubmittingEvent += OnSubmittingEvent;
            app.UseExceptionless();
        }

        /// <summary>
        /// 全局配置Exceptionless
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static  void OnSubmittingEvent(object sender, EventSubmittingEventArgs e)
        {
            // 只处理未处理的异常
            if (!e.IsUnhandledError)
                return;

            // 忽略404错误
            if (e.Event.IsNotFound())
            {
                e.Cancel = true;
                return;
            }

            // 忽略没有错误体的错误
            var error = e.Event.GetError();
            if (error == null)
                return;
            // 忽略 401 (Unauthorized) 和 请求验证的错误.
            if (error.Code == "401" || error.Type == "System.Web.HttpRequestValidationException")
            {
                e.Cancel = true;
                return;
            }
            // Ignore any exceptions that were not thrown by our code.
            var handledNamespaces = new List<string> { "Exceptionless" };
            if (!error.StackTrace.Select(s => s.DeclaringNamespace).Distinct().Any(ns => handledNamespaces.Any(ns.Contains)))
            {
                e.Cancel = true;
                return;
            }
            // 添加附加信息.
            //e.Event.AddObject(order, "Order", excludedPropertyNames: new[] { "CreditCardNumber" }, maxDepth: 2);
            e.Event.Tags.Add("MunicipalPublicCenter.BusinessApi");
            e.Event.MarkAsCritical();
            //e.Event.SetUserIdentity();
        }
    }
}
