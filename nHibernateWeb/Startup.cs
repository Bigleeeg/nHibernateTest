using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(nHibernateWeb.Startup))]
namespace nHibernateWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
