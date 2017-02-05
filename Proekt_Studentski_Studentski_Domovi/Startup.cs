using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Proekt_Studentski_Studentski_Domovi.Startup))]
namespace Proekt_Studentski_Studentski_Domovi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
