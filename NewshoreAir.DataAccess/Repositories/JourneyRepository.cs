using NewshoreAir.Application.Contracts;
using NewshoreAir.Business.Entities;
using Newtonsoft.Json;

namespace NewshoreAir.DataAccess.Repositories
{
	public class JourneyRepository : IRouteRepository
	{
		private readonly HttpClient _httpClient;

		public JourneyRepository(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<IEnumerable<Route>> GetAllAsync()
		{
			var response = await _httpClient.GetAsync("https://recruiting-api.newshore.es/api/flights/1");

			if (!response.IsSuccessStatusCode)
			{
				// Manejo de error
			}

			var content = await response.Content.ReadAsStringAsync();
			var routesApiData = JsonConvert.DeserializeObject<IEnumerable<Route>>(content);

			return routesApiData;
		}
	}
}
