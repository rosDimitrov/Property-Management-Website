using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Property_Management.Startup))]
namespace Property_Management
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
