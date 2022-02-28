using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Books.Startup))]
namespace Books
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
