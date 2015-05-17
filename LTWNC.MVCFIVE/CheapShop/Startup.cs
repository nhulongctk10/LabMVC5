using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CheapShop.Startup))]
namespace CheapShop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
