using AutoMapper;
using MediatR;
using NewshoreAir.Application.Contracts;
using NewshoreAir.Application.Features.Routes.Queries.GetRoutesList;

namespace NewshoreAir.Application.Features.Routes.Queries.GetJourney
{
	public class GetJourneyQueryHandler : IRequestHandler<GetJourneyQuery, List<JourneyVm>>
	{
		private readonly IRouteRepository _routesRepository;
		private readonly IMapper _mapper;

		public GetJourneyQueryHandler(IRouteRepository routeRepository, IMapper mapper)
		{
			_routesRepository = routeRepository;
			_mapper = mapper;
		}

		public async Task<List<JourneyVm>> Handle(GetJourneyQuery request, CancellationToken cancellationToken)
		{
			var routesList = await _routesRepository.GetAllAsync();

			return _mapper.Map<List<JourneyVm>>(routesList);
		}
	}
}
