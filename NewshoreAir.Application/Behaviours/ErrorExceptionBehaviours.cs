

using MediatR;
using Microsoft.Extensions.Logging;

namespace NewshoreAir.Application.Behaviours
{
	public class ErrorExceptionBehaviours<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
	{
		private readonly ILogger<TRequest> _logger;
		public ErrorExceptionBehaviours(ILogger<TRequest> logger)
		{
			_logger = logger;
		}

		public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
		{
			try
			{
				return await next();
			}
			catch (Exception ex)
			{
				var requestName = typeof(TRequest).Name;
				_logger.LogError(ex, "Application Request: An exception occurred {Name} {@Request}", requestName, request);
				throw;
			}
		}
	}
}
