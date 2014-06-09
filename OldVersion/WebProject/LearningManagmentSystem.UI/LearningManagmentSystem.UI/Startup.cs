using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LearningManagmentSystem.UI.Startup))]
namespace LearningManagmentSystem.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
