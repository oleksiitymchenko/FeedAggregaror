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
                await feedService.UpdateFeeds();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
