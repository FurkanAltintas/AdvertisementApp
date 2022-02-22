using AdvertisementApp.Common;
using FluentValidation.Results;
using System.Collections.Generic;

namespace AdvertisementApp.Business.Extensions
{
    public static class ValidationResultExtension
    {
        public static List<CustomValidationError> ConvertCustomValidationError(this ValidationResult validationResult)
        {
            List<CustomValidationError> errors = new();
            foreach (var error in validationResult.Errors)
            {
                errors.Add(new()
                {
                    PropertyName = error.PropertyName,
                    ErrorMessage = error.ErrorMessage
                });
            }

            return errors;
        }
    }
}
