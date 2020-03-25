using JobBoard.WebAPI.JobServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace JobBoard.WebAPI
{
    public class JobApisConfig
    {
        public static void StartJobsGathering()
        {
            var jobServices = from type in Assembly.GetExecutingAssembly().GetTypes()
                                where typeof(IJobService).IsAssignableFrom(type) && !type.IsInterface
                                select ((IJobService)Activator.CreateInstance(type));

            foreach (var jobService in jobServices)
            {
                Task.Run(async () =>
                {
                    while (true)
                    {
                        await jobService.GetJobs();
                        await Task.Delay(TimeSpan.FromSeconds(15));
                    }
                });
            }
        }
    }
}