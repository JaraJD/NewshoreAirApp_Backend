
using NewshoreAir.Business.Entities.Common;

namespace NewshoreAir.Application.Contracts.DataAccess
{
	public interface IAsyncRepository<T> where T : BaseDomainModel
	{
		Task<IReadOnlyList<T>> GetAllAsync();
	}
}
