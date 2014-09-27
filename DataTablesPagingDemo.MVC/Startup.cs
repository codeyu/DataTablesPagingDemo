using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DataTablesPagingDemo.MVC.Startup))]
namespace DataTablesPagingDemo.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
