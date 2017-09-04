using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CargoLogistic.WebUI.Models.CustomValidationAttributes
{
    public sealed class DateToGreaterThanDateFromAttribute : RequiredAttribute
    {
        private String PropertyName { get; set; }
        
        public DateToGreaterThanDateFromAttribute(string propertyName)
        {
            PropertyName = propertyName;
        }
        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            Object instance = context.ObjectInstance;
            Type type = instance.GetType();
            Object proprtyvalue = type.GetProperty(PropertyName).GetValue(instance, null);
            DateTime dateFrom;
            DateTime dateTo;
            
            if (value != null && PropertyName != null)
            {
                if ( (DateTime.TryParse(proprtyvalue.ToString(), out dateFrom)) 
                     && (DateTime.TryParse(value.ToString(), out dateTo)))
                {
                    if (dateTo >= dateFrom)
                    {
                        return ValidationResult.Success;
                    }
                    else
                    {
                        return new ValidationResult("DateTo must be greater than DateFrom");
                    }
               
                }
            }
            return new ValidationResult("value is null");
        }
        
    }
}