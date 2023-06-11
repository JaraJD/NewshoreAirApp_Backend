using AutoMapper;
using NewshoreAir.Application.Features.Routes.Queries.GetJourney;
using NewshoreAir.Application.Features.Routes.Queries.GetRoutesList;
using NewshoreAir.Business.Entities;

namespace NewshoreAir.Application.Mappings
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Route, JourneyVm>();
			CreateMap<Route, RoutesVm>();
		}
	}
}
