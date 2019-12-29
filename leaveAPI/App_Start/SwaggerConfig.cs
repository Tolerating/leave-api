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

                        //��ʾapi�ӿ�ע��
                        var xmlFile = string.Format(@"{0}\bin\leaveAPI.xml", System.AppDomain.CurrentDomain.BaseDirectory);
                        if (System.IO.File.Exists(xmlFile))
                        {
                            c.IncludeXmlComments(xmlFile);
                        }
                        c.CustomProvider((defaultProvider) => new SwaggerControllerDescProvider(defaultProvider, xmlFile));

                        //���÷�������
                        c.GroupActionsBy(apiDesc =>
                        apiDesc.GetControllerAndActionAttributes<ControllerGroupAttribute>().Any() ?
                        apiDesc.GetControllerAndActionAttributes<ControllerGroupAttribute>().First().GroupName : "��δ����ControllGroup");
                    })
                .EnableSwaggerUi(c =>
                    {
                        c.DocumentTitle("My Swagger UI");
                        //���غ�����js�ļ�
                        c.InjectJavaScript(System.Reflection.Assembly.GetExecutingAssembly(), "leaveAPI.swagger-China.js");
                    });
        }
    }
}
