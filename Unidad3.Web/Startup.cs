using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Unidad3.Web.Startup))]
namespace Unidad3.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
