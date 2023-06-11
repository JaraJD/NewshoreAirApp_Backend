using NewshoreAir.Application.Contracts.DataAccess;
using NewshoreAir.Business.Entities;

namespace NewshoreAir.Application.Contracts
{
	public interface IRouteRepository
	{
		Task<IReadOnlyList<Route>> GetAllAsync();
	}
}
