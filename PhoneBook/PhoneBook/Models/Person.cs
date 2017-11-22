using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Models
{
    public class Person
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string Firstname { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string Lastname { get; set; }
        [Required]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "Entered phone format is not valid!")]
        public string Phone { get; set; }
        [Required]
        [Display(Name = "Email Address")]
        [EmailAddress]
        public string Email { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}
