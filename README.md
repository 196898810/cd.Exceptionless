# Exceptionless扩展类库
## 1.cd.Exceptionless.Framework Framework扩展类库,需要Framework4以上版本使用
可以通过从NuGet添加cd.Exceptionless.Framework包或者使用代码编译后使用
使用前需要在configuration节加入Key和Url

`<configuration>
	<configSections>
		<section name="exceptionless" type="Exceptionless.ExceptionlessSection, Exceptionless.Extras" />
	</configSections>
	<appSettings>
		<add key="Exceptionless:ServerUrl" value="如果不是本地部署请注释"/>
	</appSettings>
	<exceptionless apiKey="Youkey" />
</configuration>`

全局异常使用方法
在`Program`修改`Main`方法

```
static void Main()
        {
            try
            {

                //处理未捕获的异常
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                //处理UI线程异常
                Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(ExceptionRegister.Application_ThreadException);
                //处理非UI线程异常
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(ExceptionRegister.CurrentDomain_UnhandledException);

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
            catch (Exception ex)
            {
                Information.ShowMessage(ex);
            }
        }
```
## 2.cd.Exceptionless NETCore扩展类库,当前版本Net5
可以通过从NuGet添加cd.Exceptionless包直接使用,若需要低版本下载源码重新编译
使用前需要在appsettings.json节加入Key和Url
注册方法: app.UseExceptionless(Configuration);
