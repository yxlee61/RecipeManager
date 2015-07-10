using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RecipeManager.Startup))]
namespace RecipeManager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
