using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MarsRover.Startup))]
namespace MarsRover
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
