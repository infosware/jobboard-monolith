using System.Collections.Generic;
using System.Web.Helpers;
using JobBoard.WebAPI.Models;

namespace JobBoard.WebAPI.JobMappers
{
    public class HHJobMapper
    {
        public static List<IJob> MapFromJson(string json)
        {
            List<IJob> result = new List<IJob>();

            dynamic jobs = Json.Decode(json);

            foreach (var job in jobs.items)
            {
                result.Add(new JobDto
                {
                    Id = job.id,
                    Title = job.name,
                    CompanyName = job.employer.name,
                    JobUrl = job.alternate_url,
                    JobServiceName = "HH"
                });
            }

            return result;
        }
    }
}