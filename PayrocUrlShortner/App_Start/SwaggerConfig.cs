using System.Web.Http;
using WebActivatorEx;
using PayrocUrlShortner;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace PayrocUrlShortner
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "PayrocUrlShortner");
                    })
                .EnableSwaggerUi(c => { });
        }
    }
}
