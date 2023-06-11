using AutoMapper;
using MediatR;
using NewshoreAir.Application.Contracts;
using NewshoreAir.Application.Features.Routes.Queries.GetRoutesList;
using NewshoreAir.Business.Entities;

namespace NewshoreAir.Application.Features.Routes.Queries.GetJourney
{
	public class GetJourneyQueryHandler : IRequestHandler<GetJourneyQuery, JourneyVm>
	{
		private readonly IRouteRepository _routesRepository;
		private readonly IMapper _mapper;

		public GetJourneyQueryHandler(IRouteRepository routeRepository, IMapper mapper)
		{
			_routesRepository = routeRepository;
			_mapper = mapper;
		}

		public async Task<JourneyVm> Handle(GetJourneyQuery request, CancellationToken cancellationToken)
		{
			var routesList = await _routesRepository.GetAllAsync();

			JourneyVm CalculateJourney(string origin, string destination)
			{
				Queue<Journey> queue = new Queue<Journey>();
				HashSet<string> visited = new HashSet<string>();

				// Inicializa la cola con la ruta de origen
				Journey initialJourney = new Journey
				{
					Origin = origin,
					Destination = origin,
					Price = 0,
					Flights = new List<Flight>()
				};

				queue.Enqueue(initialJourney);

				while (queue.Count > 0)
				{
					Journey currentJourney = queue.Dequeue();

					if (currentJourney.Destination == destination)
					{
						// Si encuentra la ruta al destino
						return _mapper.Map<JourneyVm>(currentJourney);
					}

					string currentDestination = currentJourney.Destination;

					// Busca los vuelos desde el destino actual
					foreach (Route flight in routesList)
					{
						if (flight.DepartureStation == currentDestination && !visited.Contains(flight.ArrivalStation))
						{
							Journey newJourney = new Journey
							{
								Origin = currentJourney.Origin,
								Destination = flight.ArrivalStation,
								Price = currentJourney.Price + flight.Price,
								Flights = new List<Flight>(currentJourney.Flights)
							};

							Flight flightDetail = new Flight
							{
								Origin = flight.DepartureStation,
								Destination = flight.ArrivalStation,
								Price = flight.Price,
								Transport = new Transport
								{
									FlightCarrier = flight.FlightCarrier,
									FlightNumber = flight.FlightNumber
								}
							};

							newJourney.Flights.Add(flightDetail);
							queue.Enqueue(newJourney);
							visited.Add(flight.ArrivalStation);
						}
					}
				}

				// Si no hay una ruta ruta válida al destino retorna null
				return null;
			}

			var result = CalculateJourney(request._Origin, request._Destination);

			if(result == null)
			{
				throw new ArgumentNullException("No available routes found");
			}

			return result;
		}
	}
}
