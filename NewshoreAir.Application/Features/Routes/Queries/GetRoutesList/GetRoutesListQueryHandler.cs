
using AutoMapper;
using MediatR;
using NewshoreAir.Application.Contracts;

namespace NewshoreAir.Application.Features.Routes.Queries.GetRoutesList
{
	public class GetRoutesListQueryHandler : IRequestHandler<GetRoutesListQuery, List<RoutesVm>>
	{
		private readonly IRouteRepository _routesRepository;
		private readonly IMapper _mapper;

		public GetRoutesListQueryHandler(IRouteRepository routeRepository, IMapper mapper)
		{
			_routesRepository = routeRepository;
			_mapper = mapper;
		}

		public async Task<List<RoutesVm>> Handle(GetRoutesListQuery request, CancellationToken cancellationToken)
		{
			var routesList = await _routesRepository.GetAllAsync();

			return _mapper.Map<List<RoutesVm>>(routesList);
		}
	}
}
