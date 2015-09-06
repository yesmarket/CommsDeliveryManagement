using FluentValidation;
using Service.Contracts;

namespace Service.Validation
{
    public class NotificationValidator : AbstractValidator<Notification>
    {
        public NotificationValidator(IValidator<Payload> payloadValidator)
        {
            RuleFor(notification => notification.Payload)
                .NotNull()
                .WithMessage("Payload cannot be null.")
                .SetValidator(payloadValidator);
        }
    }
}
