using Infrastructure.Services.Abstract;
using System.Net.Http.Json;

namespace Infrastructure.Services
{
    public class AccidentService : IAccidentService
    {
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly string _remoteServiceBaseUrl = "https://localhost:6001/";

		public AccidentService(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<int> GetAccidentsCountByDate(DateTime date)
		{
			int count = 0;
			var path = "api/accidents" + "/" + date.ToString("MM-dd-yyyy");

			string? uri = _remoteServiceBaseUrl + path;

			//using (var client = new HttpClient())
			//{
			//	client.BaseAddress = new Uri("https://localhost:6001/");
			//	client.DefaultRequestHeaders.Accept.Clear();
			//	client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

			//	var path = "api/accidents" + "/" + date.ToString("MM-dd-yyyy");

			//	// HTTP GET
			//	HttpResponseMessage response = await client.GetAsync(path);
			//	if (response.IsSuccessStatusCode)
			//	{
			//		count = await response.Content.ReadFromJsonAsync<int>();
			//	}
			//}

			var httpRequestMessage = new HttpRequestMessage(
			    HttpMethod.Get,
				uri)
			{
			    //Headers =
			    //{
			    //    { HeaderNames.Accept, "application/vnd.github.v3+json" },
			    //    { HeaderNames.UserAgent, "HttpRequestsSample" }
			    //}
			};

			var httpClient = _httpClientFactory.CreateClient();
			var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

			if (httpResponseMessage.IsSuccessStatusCode)
			{
				count = await httpResponseMessage.Content.ReadFromJsonAsync<int>();
			}

			return count;
		}
	}
}
