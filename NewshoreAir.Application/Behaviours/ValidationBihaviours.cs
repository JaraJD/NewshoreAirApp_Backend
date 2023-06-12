using FluentValidation;
using MediatR;

namespace NewshoreAir.Application.Behaviours
{
	public class ValidationBihaviours<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
	{

		private readonly IEnumerable<IValidator<TRequest>> _validator;

		public ValidationBihaviours(IEnumerable<IValidator<TRequest>> validator)
		{
			_validator = validator;
		}

		public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
		{
			if(_validator.Any())
			{
				var context = new ValidationContext<TRequest>(request);

				var validationResults = await Task.WhenAll(_validator.Select(validator => validator.ValidateAsync(context, cancellationToken)));

				var errors = validationResults.SelectMany(r => r.Errors).Where(f => f !=null).ToList();

				if(errors.Count != 0)
				{
					throw new ValidationException(errors);
				}

			}

			return await next();
		}
	}
}
