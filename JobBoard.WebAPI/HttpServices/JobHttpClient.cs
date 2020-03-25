using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace JobBoard.WebAPI.HttpServices
{
    public class JobHttpClient
    {
        public async Task<string> GetAsync(string apiUrl)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.UserAgent.ParseAdd("C# JobBoard");
                var responseMessage = await client.GetAsync(apiUrl);

                if (responseMessage.IsSuccessStatusCode)
                {
                    string json = await responseMessage.Content.ReadAsStringAsync();
                    return json;
                }
            }

            return string.Empty;
        }
    }
}