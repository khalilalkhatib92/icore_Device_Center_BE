using iCoreAPI.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace iCoreAPI.Entities
{
    public class Genre //: IValidatableObject
    {
        /**
         * example: Best Case Senario for Model Validation. 
         * {
            "id":"3",
            "name":"khalil",
            "age":"30",
            "creditCard":"4263982640269299",
            "url":"http://www.google.com"
            }
         * 
         */
        public int Id { get; set; }

        [Required(ErrorMessage ="The field with name {0} is Required")]
        [StringLength(10)]
        [FirstLetterUppercase]
        public string Name { get; set; }

        //[Range(18,120)]
        //public int Age { get; set; }
        //[CreditCard]
        //public string CreditCard { get; set; }
        //[Url]
        //public string Url { get; set; }

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    if (!string.IsNullOrEmpty(Name))
        //    {
        //        var firstLetter = Name[0].ToString();
        //        if(firstLetter != firstLetter.ToUpper())
        //        {
        //            yield return new ValidationResult("First Letter should be Uppercase", new string[] {nameof(Name) });
        //        }
        //    }
        //}
    }
}
