using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewshoreAir.Application.Features.Routes.Queries.GetJourney;
using System.Net;

namespace NewshoreAir.API.Controllers
{
	[Route("api/")]
	[ApiController]
	public class JourneyController : ControllerBase
	{
		private readonly IMediator _mediator;

		public JourneyController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet("Journey/{origin}/{destination}/{limit}", Name = "GetJourney")]
		[ProducesResponseType(typeof(JourneyVm), (int)HttpStatusCode.OK)]
		public async Task<ActionResult<JourneyVm>> GetJourney(string origin, string destination, int limit)
		{
			var query = new GetJourneyQuery(origin, destination, limit);
			var journey = await _mediator.Send(query);
			return Ok(journey);
		}
	}
}
