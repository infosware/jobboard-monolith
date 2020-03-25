using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using JobBoard.WebAPI.Caching;
using JobBoard.WebAPI.JobMappers;
using JobBoard.WebAPI.HttpServices;

namespace JobBoard.WebAPI.JobServices
{
    public class GithubJobs : IJobService
    {
        const string BASE_URL = "https://jobs.github.com/positions.json"; // !Move to config

        public async Task<int> GetJobs()
        {
            JobHttpClient http = new JobHttpClient();
            string json = await http.GetAsync(BASE_URL);

            var jobs = GithubJobMapper.MapFromJson(json);
            SingletonCache.Instance.AddJobsToCache(jobs);

            return jobs.Count;
        }
    }
}