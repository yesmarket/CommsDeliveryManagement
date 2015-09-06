using System;
using System.Collections.Generic;
using FluentValidation;
using FluentValidation.Results;

namespace Service.Validation
{
    public class PolymorphicValidator<TPayload> : AbstractValidator<TPayload> where TPayload : class
    {
        private readonly IDictionary<Type, IValidator> _validatorMap = new Dictionary<Type, IValidator>();

        public PolymorphicValidator<TPayload> RegisterDerived<TDerivedPayload>(IValidator<TDerivedPayload> validator)
            where TDerivedPayload : TPayload
        {
            _validatorMap.Add(typeof(TDerivedPayload), validator);
            return this;
        }

        public override ValidationResult Validate(ValidationContext<TPayload> context)
        {
            var instance = context.InstanceToValidate;
            var actualType = instance == null ? typeof(TPayload) : instance.GetType();
            IValidator validator;
            if (_validatorMap.TryGetValue(actualType, out validator))
                return validator.Validate(context);
            throw new NotSupportedException(string.Format("Attempted to validate unsupported type '{0}'.", actualType));
        }
    }
}