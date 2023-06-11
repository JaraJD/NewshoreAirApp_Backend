using MediatR;

namespace NewshoreAir.Application.Features.Routes.Queries.GetJourney
{
	public class GetJourneyQuery : IRequest<JourneyVm>
	{
		public string? _Origin { get; set; }

		public string? _Destination { get; set; }

		public int _NumberRoutes { get; set; }

		public GetJourneyQuery(string origin, string destination, int numberRoutes)
		{
			_Origin = origin ?? throw new ArgumentNullException(nameof(origin));
			_Destination = destination ?? throw new ArgumentNullException(nameof(destination));
			_NumberRoutes = numberRoutes;
		}
	}
}
