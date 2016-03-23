using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Queue;
using Windows.Foundation;
namespace SpheroFrontend
{
    class AzureHelper
    {
       static CloudStorageAccount storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;" +
                         "AccountName=spherogps;" +
                         "AccountKey=eBCvODvDf+qg0CJSmmMjGE4bVn59nIFzTmcIbdRxUB7vRrxjxrMJUaz4HSs5fHHzPKW53/f0y7mNOWJozRRKXA==");

       public static async void sendMessageToQueue( Point data)
        {
            

            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();
            CloudQueue queue = queueClient.GetQueueReference("spherocommands");
            await queue.CreateIfNotExistsAsync();

            CloudQueueMessage message = new CloudQueueMessage(data.X.ToString() + "," + data.Y.ToString());
            await queue.AddMessageAsync(message);
         
           
        }
       public static List<Point> PointData = new List<Point>();
        public static async Task<List<Point>> getQueueData()
       {
           List<Point> points = new List<Point>();
           CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();
           CloudQueue queue = queueClient.GetQueueReference("spherotracking");
           await queue.CreateIfNotExistsAsync();
           var messages = await queue.GetMessagesAsync(5);
          foreach(var message in messages)
          {
              if (message.AsString != "")
                  points.Add(pointFromString(message.AsString));
              await queue.DeleteMessageAsync(message);
          }
          PointData.AddRange(points);
          return points;
       }
        static Point pointFromString(string data)
        {
            string[] split = data.Split(',');
            return new Point(double.Parse(split[0]), double.Parse(split[1]));
        }
    }
}