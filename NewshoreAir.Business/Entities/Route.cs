
using NewshoreAir.Business.Entities.Common;

namespace NewshoreAir.Business.Entities
{
	public class Route 
	{
		public string? DepartureStation { get; set; }

		public string? ArrivalStation { get; set; }

		public string? FlightCarrier { get; set; }

		public string? FlightNumber { get; set; }

		public decimal Price { get; set; }
	}
}
