using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LMS_mastery.UI.Startup))]
namespace LMS_mastery.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
