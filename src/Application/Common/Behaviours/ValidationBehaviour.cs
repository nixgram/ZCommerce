using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Exceptions;
using Domain.Common;
using FluentValidation;
using MediatR;

namespace Application.Common.Behaviours
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse> where TResponse : class
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            var context = new ValidationContext<TRequest>(request);
            var failures = _validators
                .Select(v => v.Validate(context))
                .SelectMany(result => result.Errors)
                .Where(f => f != null)
                .ToList();

            if (failures.Any())
            {
                IList<ErrorDescriptor> descriptors = failures.Select(validationFailure => new ErrorDescriptor
                {
                    ExceptionMessage = validationFailure.PropertyName, CauseOfError = validationFailure.ErrorMessage,
                    ExtraNoteForResolve = "Please make sure you full fil cause of error"
                }).ToList();

                throw new FluentValidationException(descriptors);
            }

            return next();
        }
    }
}