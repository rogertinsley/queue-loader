using System;
using System.Threading.Tasks;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Queue;

namespace queue_loader
{
    class Program
    {
        static async Task Main(string[] args)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                Environment.GetEnvironmentVariable("QUEUE_CONNECTION_STRING ")
            );
            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();

            CloudQueue queue = queueClient.GetQueueReference("queue");
            for(int x=0;x<10000;x++)
            {
                await queue.AddMessageAsync(new CloudQueueMessage("Hello KEDA"));
            }
        }
    }
}
