using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewshoreAir.Application.Features.Routes.Queries.GetJourney;
using System.Net;

namespace NewshoreAir.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class JourneyController : ControllerBase
	{
		private readonly IMediator _mediator;

		public JourneyController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet("Journey/{origin}/{destination}", Name = "GetJourney")]
		[ProducesResponseType(typeof(JourneyVm), (int)HttpStatusCode.OK)]
		public async Task<ActionResult<JourneyVm>> GetJourney(string origin, string destination)
		{
			var query = new GetJourneyQuery(origin, destination);
			var journey = await _mediator.Send(query);
			return Ok(journey);
		}
	}
}
