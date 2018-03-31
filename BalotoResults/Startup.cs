using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BalotoResults.Models;

namespace BalotoResults
{
    public class Startup
    {       
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ResultsContext>(opt => opt.UseInMemoryDatabase("Results"));
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc();
        }
    }
}