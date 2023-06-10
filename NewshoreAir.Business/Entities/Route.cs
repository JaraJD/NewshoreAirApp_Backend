
using NewshoreAir.Business.Entities.Common;

namespace NewshoreAir.Business.Entities
{
	public class Route : BaseDomainModel
	{
		public string? FlightCarrier { get; set; }

		public string? FlightNumber { get; set; }
	}
}
