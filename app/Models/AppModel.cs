using Microsoft.Extensions.Configuration;

namespace app.Models
{
    public class AppModel
    {
        protected IConfiguration Configuration { get; }
        protected AppModel(IConfiguration configuration)
        {
            Configuration = configuration;
        }
    }
}