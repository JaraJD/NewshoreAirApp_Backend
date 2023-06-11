using NewshoreAir.Business.Entities;

namespace NewshoreAir.Application.Contracts
{
	public interface IRouteRepository
	{
		Task<IEnumerable<Route>> GetAllAsync();
	}
}
