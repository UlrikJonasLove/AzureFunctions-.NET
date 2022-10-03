using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using AzureFunctions.Models;

namespace AzureFunctions.Functions
{
    public static class Saver
    {
        [FunctionName("Saver")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            [Queue("CustomerQueue", Connection = "AzureWebJobsStorage")] IAsyncCollector<Customer> queue,
            ILogger log)
        {
            log.LogInformation("Customer request received by SaverFunction");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            Customer data = JsonConvert.DeserializeObject<Customer>(requestBody);

            await queue.AddAsync(data);

            string responseMessage = "Customer has been received for " + data.Name + " and has been added to the queue.";

            return new OkObjectResult(responseMessage);
        }
    }
}
