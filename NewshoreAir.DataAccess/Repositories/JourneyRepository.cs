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

		public async Task<IReadOnlyList<Route>> GetAllAsync()
		{
			// Realizar la solicitud HTTP a la API de vuelos y obtener la respuesta
			var response = await _httpClient.GetAsync("https://recruiting-api.newshore.es/api/flights/0");

			if (!response.IsSuccessStatusCode)
			{
				// Manejar el error de acuerdo a los requisitos del sistema
			}

			var content = await response.Content.ReadAsStringAsync();
			var routesApiData = JsonConvert.DeserializeObject<IEnumerable<Route>>(content);
			return (IReadOnlyList<Route>)routesApiData;
		}
	}
}
