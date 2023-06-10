using NewshoreAir.Business.Entities.Common;

namespace NewshoreAir.Business.Entities
{
	public class Flight : BaseDomainModel
	{
		public Transport? Transport { get; set; }
	}
}
