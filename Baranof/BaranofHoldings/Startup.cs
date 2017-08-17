using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BaranofHoldings.Startup))]
namespace BaranofHoldings
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
