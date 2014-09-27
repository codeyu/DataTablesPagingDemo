using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DataTablesPagingDemo.WebForm.Startup))]
namespace DataTablesPagingDemo.WebForm
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
