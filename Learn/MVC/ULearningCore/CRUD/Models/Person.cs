using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD.Models
{
    public class Person
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter first name.")]
        [Display(Name = "First Name")]
        //[MaxLength(255)]
        public string NameFirst { get; set; }

        [Required(ErrorMessage = "Please enter last name.")]
        [Display(Name = "Last Name")]
        //[MaxLength(255)]
        public string NameLast { get; set; }

        [Required(ErrorMessage = "Please enter email.")]
        [RegularExpression(".+@.+", 
            ErrorMessage = "Please enter a valid e-mail address.")]
        //[MaxLength(255)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter age.")]
        public int Age { get; set; }

        public bool Subscribed { get; set; }

    }
}
