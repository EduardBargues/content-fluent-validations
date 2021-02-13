
using FluentValidation;

using FluentValidations.API.Requests;

namespace FluentValidations.API
{
    internal class RequestToValidateValidator : AbstractValidator<RequestToValidate>
    {
        public RequestToValidateValidator()
        {
            // BODY VALIDATIONS
            RuleFor(request => request.Body)
                .NotNull()
                .OverridePropertyName(nameof(RequestToValidate.Body))
                .WithMessage("The body must be informed");
            When(request => request.Body != null, () =>
            {
                RuleFor(request => request.Body.PastDate)
                    .Must(date => date >= 1)
                    .OverridePropertyName($"body.{nameof(RequestToValidate.RequestBody.PastDate)}")
                    .WithMessage($"{nameof(RequestToValidate.Body.PastDate)} must be larger or equal to 1.");
                RuleFor(request => request.Body)
                    .Must(body => body.FutureDate - body.PastDate >= 0)
                    .OverridePropertyName($"body.{nameof(RequestToValidate.RequestBody.PastDate)}")
                    .WithMessage($"{nameof(RequestToValidate.Body.FutureDate)} must be after {nameof(RequestToValidate.Body.PastDate)}");
            });

            // HEADER VALIDATIONS
            RuleFor(request => request.PropertyFromHeader)
                .NotNull()
                .OverridePropertyName(ApiConstants.HeaderName)
                .WithMessage($"{ApiConstants.HeaderName} must be informed as a header");
            RuleFor(request => request.PropertyFromHeader)
                .NotEmpty()
                .When(request => request.PropertyFromHeader != null)
                .OverridePropertyName(nameof(RequestToValidate.PropertyFromHeader))
                .WithMessage($"{ApiConstants.HeaderName} can not be empty");

            // QUERY VALIDATIONS
            RuleFor(request => request.PropertyFromQuery)
                .NotNull()
                .OverridePropertyName(ApiConstants.QueryPropertyName)
                .WithMessage($"{ApiConstants.QueryPropertyName} must be informed as a query parameter");
            RuleFor(request => request.PropertyFromQuery)
                .GreaterThanOrEqualTo(0)
                .When(request => request.PropertyFromQuery != null)
                .OverridePropertyName(ApiConstants.QueryPropertyName)
                .WithMessage($"{ApiConstants.QueryPropertyName} must be larger or equal to zero");
        }
    }

}
