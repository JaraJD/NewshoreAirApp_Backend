using MediatR;

namespace NewshoreAir.Application.Features.Routes.Queries.GetJourney
{
	public class GetJourneyQuery : IRequest<List<JourneyVm>>
	{
		public string? _Origin { get; set; }

		public string? _Destination { get; set; }

		public GetJourneyQuery(string origin, string destination)
		{
			_Origin = origin ?? throw new ArgumentNullException(nameof(origin));
			_Destination = destination ?? throw new ArgumentNullException(nameof(destination));
		}
	}
}
