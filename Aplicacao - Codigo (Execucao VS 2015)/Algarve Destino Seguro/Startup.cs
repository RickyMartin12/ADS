using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Algarve_Destino_Seguro.Startup))]
namespace Algarve_Destino_Seguro
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
