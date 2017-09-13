using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CargoLogistic.WebUI.Models.CustomValidationAttributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = true)]
    public sealed class PositiveNumberAttribute : ValidationAttribute, IClientValidatable
    {
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var mvr = new ModelClientValidationRule
            {
                ErrorMessage = "This field require a positive number CLIENT",
                ValidationType = "positivenumber"
            };
            return new[] {mvr};
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                long number;
                if (long.TryParse(value.ToString(), out number))
                {
                    if(number > 0) return ValidationResult.Success;
                    else return new ValidationResult(ErrorMessage);
                }
            }
            return new ValidationResult("value is null");
        }
    }
}