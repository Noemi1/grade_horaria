using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GradeHoraria_.Startup))]
namespace GradeHoraria_
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
