using System;
using System.Threading.Tasks;
using FeedAggregator.BLL.Interfaces;
using Quartz;

namespace FeedAggregaror_API.TasksSheduler
{
    public class RefreshFeedJob : IJob
    {
        private readonly IFeedService feedService;

        public RefreshFeedJob(IFeedService dataAggregatorCore)
        {
            feedService = dataAggregatorCore;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            try
            {
               
                var timeSpan = TimeSpan.FromMinutes(1);
                //var deleteSource = false;
                Console.WriteLine("=============================================");
                Console.WriteLine("=============================================");
                Console.WriteLine("=============================================");
                Console.WriteLine("=============================================");
                Console.WriteLine("=============================================");
                Console.WriteLine("=============================================");
                await feedService.UpdateFeeds();
                // Run Aggregating CollectedData
                //await feedService.AggregatingData(sourceType, destinationType, timeSpan, deleteSource);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
