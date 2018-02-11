using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ascentic.WorkFlow.MVCClient.Startup))]
namespace Ascentic.WorkFlow.MVCClient
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
