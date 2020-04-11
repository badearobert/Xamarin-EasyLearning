using Microsoft.Extensions.DependencyInjection;
using Shiny;

namespace EinfachDeutsch
{
    public class Startup : ShinyStartup
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            // register your shiny services here
            services.UseNotifications();
        }
    }
}
