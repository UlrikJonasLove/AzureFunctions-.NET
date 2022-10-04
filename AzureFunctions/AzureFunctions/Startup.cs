using AzureFunctions;
using AzureFunctions.Data;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: WebJobsStartup(typeof(Startup))]
namespace AzureFunctions
{
    public class Startup : IWebJobsStartup
    {

        public void Configure(IWebJobsBuilder builder)
        {
            string connectionString = Environment.GetEnvironmentVariable("AzureSqlDataBase");
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));


        }
    }
}
