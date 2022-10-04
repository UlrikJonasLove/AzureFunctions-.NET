using System;
using System.Linq;
using System.Threading.Tasks;
using AzureFunctions.Data;
using AzureFunctions.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace AzureFunctions.Functions
{
    public class Extractor
    {
        private readonly AppDbContext context;
        public Extractor(AppDbContext context)
        {
            this.context = context;
        }

        [FunctionName("Extractor")]
        public void Run([QueueTrigger("CustomerQueue", Connection = "AzureWebJobsStorage")] Customer customerQueueItem,
            ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {customerQueueItem}");

            context.Customers.Add(customerQueueItem);
            context.SaveChanges();
        }

        [FunctionName("GetCustomer")]
        public IActionResult GetCustomer([HttpTrigger(AuthorizationLevel.Function, "get", Route = "GetCustomer")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Getting customer list");

            return new OkObjectResult(context.Customers.ToList());
        }
    }
}
