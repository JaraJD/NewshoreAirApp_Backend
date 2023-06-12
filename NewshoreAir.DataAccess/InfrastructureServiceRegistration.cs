using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NewshoreAir.Application.Contracts;
using NewshoreAir.Application.Features.Routes.Queries.GetJourney;
using NewshoreAir.Application.Features.Routes.Queries.GetRoutesList;
using NewshoreAir.DataAccess.Repositories;

namespace FinancialGoal.Infrastructure
{
	public static class InfrastructureServiceRegistration
	{
		public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
		{
			services.AddScoped<IRouteRepository, JourneyRepository>();

			services.AddTransient<IRequestHandler<GetRoutesListQuery, List<RoutesVm>>, GetRoutesListQueryHandler>();
			services.AddTransient<IRequestHandler<GetJourneyQuery, JourneyVm>, GetJourneyQueryHandler>();

			return services;
		}
	}
}
