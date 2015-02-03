using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SciFusion.Startup))]
namespace SciFusion
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
