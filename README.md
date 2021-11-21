# Exceptionless扩展类库
1.cd.Exceptionless.Framework Framework扩展类库,需要Framework4以上版本使用
可以通过从NuGet添加cd.Exceptionless.Framework包或者使用代码编译后使用
使用前需要在configuration节加入Key和Url
<configuration>
	<configSections>
		<section name="exceptionless" type="Exceptionless.ExceptionlessSection, Exceptionless.Extras" />
	</configSections>
	<appSettings>
		<add key="Exceptionless:ServerUrl" value="如果不是本地部署请注释"/>
	</appSettings>
	<exceptionless apiKey="Youkey" />
</configuration>
