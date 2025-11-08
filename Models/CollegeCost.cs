using System.ComponentModel.DataAnnotations;

namespace TuitionCalculator_WebApp.Models
{
    public class CollegeCost
    {
        //class properties defining all data relevant for cost of going to college
        public int CollegeCostId { get; set; }

        [Required(ErrorMessage ="Cost per credit hour is a required field")]//provides validation that this field is required
        [IsValidUsd]
        public decimal CostPerCreditHour { get; set; }
        [Required(ErrorMessage = "Please make a selection from the drop-down list")]
        public string Timeframe { get; set; } = string.Empty;//initialize a default value of empty string to suppress compiler warnings and improve EF core integration
        [Required(ErrorMessage = "Credit hours per term is a required field")]
        public int CreditHoursPerTerm { get; set; }
        [Required(ErrorMessage = "Cost of housing is a required field")]
        public decimal CostOfHousing { get; set; }
        [Required(ErrorMessage = "Cost of books is a required field")]
        public decimal CostOfBooks { get; set; }
        [Required(ErrorMessage = "Years to graduate is a required field")]
        public int YearsToGraduate { get; set; }

        public int TotalCreditHours => CreditHoursPerTerm * Frequency * YearsToGraduate;
        public decimal AverageHousingPerYear => CostOfHousing * Frequency;
        public decimal AverageBooksPerYear => CostOfBooks * Frequency;
        public decimal AverageTuitionPerYear => CostPerCreditHour * Frequency * CreditHoursPerTerm;
        public decimal TotalCost => (AverageTuitionPerYear + AverageHousingPerYear + AverageBooksPerYear) * YearsToGraduate;
        public int Frequency =>
            Timeframe switch
            {
                "Quarter" => 4,
                "Semester" => 2,
                "Year" => 1,
                _ => 0
            };
    }
}
