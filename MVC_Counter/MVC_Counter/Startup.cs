using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_Counter.Startup))]
namespace MVC_Counter
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
