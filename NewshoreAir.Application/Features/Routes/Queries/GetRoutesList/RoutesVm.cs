
namespace NewshoreAir.Application.Features.Routes.Queries.GetRoutesList
{
	public class RoutesVm
	{

		public string? Origin { get; set; }

		public string? Destination { get; set; }

		public decimal Price { get; set; }

		public string? FlightCarrier { get; set; }

		public string? FlightNumber { get; set; }
	}
}
