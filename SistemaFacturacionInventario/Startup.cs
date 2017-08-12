using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SistemaFacturacionInventario.Startup))]
namespace SistemaFacturacionInventario
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
