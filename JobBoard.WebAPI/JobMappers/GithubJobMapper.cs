using System.Collections.Generic;
using System.Web.Helpers;
using JobBoard.WebAPI.Models;

namespace JobBoard.WebAPI.JobMappers
{
    public class GithubJobMapper
    {
        public static List<IJob> MapFromJson(string json)
        {
            List<IJob> result = new List<IJob>();

            dynamic jobs = Json.Decode(json);

            foreach (var job in jobs)
            {
                result.Add(new JobDto
                {
                    Id = job.id,
                    Title = job.title,
                    CompanyName = job.company,
                    JobUrl =job.url,
                    JobServiceName = "Github"
                });
            }

            return result;
        }
    }
}