using System.Linq;
using System.Text.RegularExpressions;
using FluentValidation;
using Service.Contracts;

namespace Service.Host.Validation
{
    public class EmailPayloadValidator : AbstractValidator<EmailPayload>
    {
        public EmailPayloadValidator()
        {
            var regex = new Regex(@"^[a-z0-9!#$%&'*+/=?^_`{|}~.-]+@[a-z0-9-]+(\.[a-z0-9-]+)+$", RegexOptions.IgnoreCase);

            RuleFor(payload => payload.To)
                .Must(list => list != null && list.Any(s => !string.IsNullOrEmpty(s)))
                .WithMessage("Email has no valid recipients.")
                .When(payload => payload.To != null && payload.To.Any());
            RuleFor(payload => payload.To)
                .Must(list => list != null && list.Any())
                .WithMessage("Email has no recipients.")
                .When(payload => payload.To == null || !payload.To.Any());
            RuleFor(payload => payload.To)
                .Must(list => list.All(s => IsValidEmail(regex, s)))
                .WithMessage("One or more email recipients are invalid.")
                .When(payload => payload.To != null && payload.To.Any(s => !string.IsNullOrWhiteSpace(s)));
            RuleFor(payload => payload.Subject)
                .Must(s => !string.IsNullOrEmpty(s))
                .WithMessage("Email subject is invalid.");
            RuleFor(payload => payload.Bcc)
                .Must(list => list.All(s => IsValidEmail(regex, s)))
                .WithMessage("One or more Bcc addresses are invalid.")
                .When(payload => payload.Bcc != null && payload.Bcc.Any(s => !string.IsNullOrWhiteSpace(s)));
            RuleFor(payload => payload.CC)
                .Must(list => list.All(s => IsValidEmail(regex, s)))
                .WithMessage("One or more CC addresses are invalid.")
                .When(payload => payload.CC != null && payload.CC.Any(s => !string.IsNullOrWhiteSpace(s)));
            RuleFor(payload => payload.ReplyToList)
                .Must(list => list.All(s => IsValidEmail(regex, s)))
                .WithMessage("One or more reply-to addresses are invalid.")
                .When(payload => payload.ReplyToList != null && payload.ReplyToList.Any(s => !string.IsNullOrWhiteSpace(s)));
        }

        private static bool IsValidEmail(Regex regex, string s)
        {
            var match = regex.Match(s);
            return match.Success;
        }
    }
}