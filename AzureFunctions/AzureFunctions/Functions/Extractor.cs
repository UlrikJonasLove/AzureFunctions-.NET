using System;
using AzureFunctions.Data;
using AzureFunctions.Models;
using Microsoft.Azure.WebJobs;
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
    }
}
