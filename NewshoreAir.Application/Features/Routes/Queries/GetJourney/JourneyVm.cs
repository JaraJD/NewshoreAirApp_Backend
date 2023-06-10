
using NewshoreAir.Business.Entities;

namespace NewshoreAir.Application.Features.Routes.Queries.GetJourney
{
	public class JourneyVm
	{
		public List<Flight>? Flights { get; set; }

		public string? Origin { get; set; }

		public string? Destination { get; set; }

		public decimal Price { get; set; }
	}
}
