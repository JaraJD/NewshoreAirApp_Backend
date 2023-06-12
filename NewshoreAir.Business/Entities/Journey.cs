
using NewshoreAir.Business.Entities.Common;

namespace NewshoreAir.Business.Entities
{
	public class Journey : BaseDomainModel
	{
		public List<Flight>? Flights { get; set; }
	}
}
