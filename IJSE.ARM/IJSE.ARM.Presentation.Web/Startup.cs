using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IJSE.ARM.Presentation.Web.Startup))]
namespace IJSE.ARM.Presentation.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
