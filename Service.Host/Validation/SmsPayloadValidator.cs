using System.Linq;
using FluentValidation;
using PhoneNumbers;
using Service.Contracts;

namespace Service.Host.Validation
{
    public class SmsPayloadValidator : AbstractValidator<SmsPayload>
    {
        public SmsPayloadValidator()
        {
            RuleFor(payload => payload.Provider)
                .Must(s => !string.IsNullOrEmpty(s))
                .WithMessage("Provider is required.");
            RuleFor(payload => payload.Numbers)
                .Must(list => list != null && list.Any())
                .WithMessage("Sms has no phone numbers specified.");
            RuleFor(payload => payload.Region)
                .Must(s => !string.IsNullOrEmpty(s))
                .WithMessage("Region is required.");
            RuleFor(payload => payload.Numbers)
                .Must((payload, list) => list.All(s => IsPossibleNumber(s, payload.Region)))
                .WithMessage("One or more of the phone numbers are invalid for the specified region.")
                .When(
                    payload => payload.Numbers != null && payload.Numbers.Any() && !string.IsNullOrEmpty(payload.Region));
        }

        private static bool IsPossibleNumber(string phoneNumber, string region)
        {
            var util = PhoneNumberUtil.GetInstance();

            try
            {
                var number = util.Parse(phoneNumber, region);
                return util.IsPossibleNumber(number);
            }
            catch (NumberParseException)
            {
                return false;
            }
        }
    }
}