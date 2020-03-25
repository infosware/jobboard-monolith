using System.Threading.Tasks;
using JobBoard.WebAPI.Caching;
using JobBoard.WebAPI.JobMappers;
using JobBoard.WebAPI.HttpServices;

namespace JobBoard.WebAPI.JobServices
{
    public class HHJobs : IJobService
    {
        const string BASE_URL = "https://api.hh.ru/vacancies?area=2&specialization=1"; // !Move to config

        public async Task<int> GetJobs()
        {
            JobHttpClient http = new JobHttpClient();
            string json = await http.GetAsync(BASE_URL);

            var jobs = HHJobMapper.MapFromJson(json);
            SingletonCache.Instance.AddJobsToCache(jobs);

            return jobs.Count;
        }
    }
}