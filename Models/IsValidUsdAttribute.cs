/****************************************************************************************
 * Class defining validation logic to determine if a value is a valid USD dollar amount *
 ***************************************************************************************/

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace TuitionCalculator_WebApp.Models
{
    public class IsValidUsdAttribute : ValidationAttribute, IClientModelValidator
    {
        //provide server-side validation by overriding the base class's IsValid method with one that validates for a valid USD dollar amount
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            //check if the value is a decimal
            if (value is decimal)
            {
                //cast value to decimal
                decimal valueToCheck = (decimal)value;

                //check that the casted value is >= 0 and has no more than 2 decimal places
                //if true, return a success result to represent the value is a valid USD
                if (valueToCheck >= 0 && decimal.Round(valueToCheck, 2) == valueToCheck)
                    return ValidationResult.Success;
            }

            //otherwise, build an error message string and return the resulting message to indicate the value was NOT a valid USD dollar amount
            string errorMessage = base.ErrorMessage ??//first check if error message of base class is null. If so no default message is set
                $"{validationContext.DisplayName} is not a valid USD dollar amount";
            return new ValidationResult(errorMessage);
        }

        //enable client-side validation by adding data-val attributes to generated html so Jquery validation can be performed
        public void AddValidation(ClientModelValidationContext ctx)
        {
            if (!ctx.Attributes.ContainsKey("data-val"))//only add data-val attributes if they don't already exists
                ctx.Attributes.Add("data-val", "true");

            //add custom error message
            ctx.Attributes.Add("data-val-validusd", GetErrorMessage());
        }

        //method to return an error message indicating a value isn't a valid usd dollar amount
        private string GetErrorMessage() => " Please enter a valid USD dollar amount (ex: 123.45)";
    }
    
}
