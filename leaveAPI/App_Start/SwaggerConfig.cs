using System.Web.Http;
using WebActivatorEx;
using leaveAPI;
using Swashbuckle.Application;
using Swashbuckle.Swagger;
using System.Linq;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace leaveAPI
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "LeaveAPP_API");

                        //显示api接口注释
                        var xmlFile = string.Format(@"{0}\bin\leaveAPI.xml", System.AppDomain.CurrentDomain.BaseDirectory);
                        if (System.IO.File.Exists(xmlFile))
                        {
                            c.IncludeXmlComments(xmlFile);
                        }
                        c.CustomProvider((defaultProvider) => new SwaggerControllerDescProvider(defaultProvider, xmlFile));

                        //设置分组名字
                        c.GroupActionsBy(apiDesc =>
                        apiDesc.GetControllerAndActionAttributes<ControllerGroupAttribute>().Any() ?
                        apiDesc.GetControllerAndActionAttributes<ControllerGroupAttribute>().First().GroupName : "暂未设置ControllGroup");
                    })
                .EnableSwaggerUi(c =>
                    {
                        c.DocumentTitle("My Swagger UI");
                        //加载汉化的js文件
                        c.InjectJavaScript(System.Reflection.Assembly.GetExecutingAssembly(), "leaveAPI.swagger-China.js");
                    });
        }
    }
}
