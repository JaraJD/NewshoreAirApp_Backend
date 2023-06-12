using MediatR;

namespace NewshoreAir.Application.Features.Routes.Queries.GetRoutesList
{
	public class GetRoutesListQuery : IRequest<List<RoutesVm>>
	{
		public string? _Origin { get; set; }

		public string? _Destination { get; set; }

		public GetRoutesListQuery(string origin, string destination)
		{
			_Origin= origin ?? throw new ArgumentNullException(nameof(origin));
			_Destination = destination ?? throw new ArgumentNullException(nameof(destination));
		}
 	}
}
