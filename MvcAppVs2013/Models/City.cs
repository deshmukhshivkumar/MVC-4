using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MvcAppVs2013.Models
{
    public class City
    {
        public long Id { get; set; }
        //[IsCityAlreadyexist(ErrorMessage = "City Already Exists.")]
        [Display(Name = "City Name")]
       // [Required]
        [IsCityAlreadyexist(ErrorMessage = "City Already Exists.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Alphabets Please.")]
        public string Name { get; set; }
        public double Review { get; set; }
        public bool IsActive { get; set; }
       // public State state { get; set; }
    }

    public class State
    {
        public int Code { get; set; }
    }
    #region Data Annotations

    //[Required(ErrorMessage = "Hey, you missed the code.")]
    //[RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Alphabets Please.")]
     //[DisplayFormat(NullDisplayText = "Anonymous")]


    //[Display(Name = "City Name")]

    //[IsCityAlreadyexist(ErrorMessage = "City Already Exists.")]
    //[Range(1,999)]

    public class IsCityAlreadyexist : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value,ValidationContext validationContext)
        {
            var cityName = value;
            if (cityName.ToString().ToLower() != "")
            {
                var stubbedCityProvider = new StubbedCityProvider();
                if (stubbedCityProvider.InSessionCities.Any(a => a.Name.ToLower().Trim() == cityName.ToString().Trim().ToLower() ))
                {
                    return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
                }
                else
                {
                    return ValidationResult.Success;
                }
            }
            return ValidationResult.Success;
        }
    }
    #endregion
}