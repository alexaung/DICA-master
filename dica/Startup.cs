using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(dica.Startup))]
namespace dica
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
