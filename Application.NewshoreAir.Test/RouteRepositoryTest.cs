using AutoMapper;
using Moq;
using NewshoreAir.Application.Contracts;
using NewshoreAir.Application.Features.Routes.Queries.GetJourney;
using NewshoreAir.Business.Entities;

namespace Application.NewshoreAir.Test
{
	public class RouteRepositoryTest
	{
		private Mock<IRouteRepository> _routeRepositoryMock;
		private Mock<IMapper> _mapperMock;
		private GetJourneyQueryHandler _handler;

		public RouteRepositoryTest()
		{
			_routeRepositoryMock = new Mock<IRouteRepository>();
			_mapperMock = new Mock<IMapper>();
			_handler = new GetJourneyQueryHandler(_routeRepositoryMock.Object, _mapperMock.Object);
		}

		[Fact]
		public async Task Handle_WithValidRoute_ReturnsJourneyVm()
		{
			// Arrange
			var origin = "MZL";
			var destination = "BCN";
			var routesList = new List<Route>
			{
				new Route
				{
					DepartureStation = "MZL",
					ArrivalStation = "MDE",
					FlightCarrier = "CO",
					FlightNumber = "8001",
					Price = 200
				},
				new Route
				{
					DepartureStation = "MZL",
					ArrivalStation = "CTG",
					FlightCarrier = "CO",
					FlightNumber = "8002",
					Price = 200
				},
				new Route
				{
					DepartureStation = "PEI",
					ArrivalStation = "BOG",
					FlightCarrier = "CO",
					FlightNumber = "8003",
					Price = 200
				},
				new Route
				{
					DepartureStation = "MDE",
					ArrivalStation = "BCN",
					FlightCarrier = "CO",
					FlightNumber = "8004",
					Price = 500
				}
			};

			var expectedJourney = new JourneyVm 
			{
				Origin = "MZL",
				Destination = "BCN",
				Price = 700,
				Flights = new List<Flight>
					{
						new Flight
						{
							Origin = "MZL",
							Destination = "MDE",
							Price = 200,
							Transport = new Transport
							{
								FlightCarrier = "CO",
								FlightNumber = "8001"
							}
						},
						new Flight
						{
							Origin = "MDE",
							Destination = "BCN",
							Price = 500,
							Transport = new Transport
							{
								FlightCarrier = "CO",
								FlightNumber = "8004"
							}
						}
					}
			};

			_routeRepositoryMock.Setup(r => r.GetAllAsync()).ReturnsAsync(routesList);
			_mapperMock.Setup(m => m.Map<JourneyVm>(It.IsAny<Journey>())).Returns(expectedJourney);

			var query = new GetJourneyQuery(origin, destination);

			// Act
			var result = await _handler.Handle(query, CancellationToken.None);

			// Assert
			Assert.StrictEqual(expectedJourney, result);
			Assert.NotNull(result);
			Assert.Equal("MZL", result.Origin);
			Assert.Equal("BCN", result.Destination);
			Assert.Equal(700, result.Price);
			Assert.Equal(2, result.Flights.Count);

			Assert.Equal("MZL", result.Flights[0].Origin);
			Assert.Equal("MDE", result.Flights[0].Destination);
			Assert.Equal(200, result.Flights[0].Price);
			Assert.Equal("CO", result.Flights[0].Transport.FlightCarrier);
			Assert.Equal("8001", result.Flights[0].Transport.FlightNumber);

			Assert.Equal("MDE", result.Flights[1].Origin);
			Assert.Equal("BCN", result.Flights[1].Destination);
			Assert.Equal(500, result.Flights[1].Price);
			Assert.Equal("CO", result.Flights[1].Transport.FlightCarrier);
			Assert.Equal("8004", result.Flights[1].Transport.FlightNumber);
		}

		[Fact]
		public async Task Handle_WithNoAvailableRoutes_ThrowsArgumentNullException()
		{
			// Arrange
			var origin = "Origin";
			var destination = "Destination";
			var routesList = new List<Route>(); // Empty route list

			_routeRepositoryMock.Setup(r => r.GetAllAsync()).ReturnsAsync(routesList);

			var query = new GetJourneyQuery(origin, destination);

			// Act & Assert
			await Assert.ThrowsAsync<ArgumentNullException>(() => _handler.Handle(query, CancellationToken.None));
		}

	}
}
