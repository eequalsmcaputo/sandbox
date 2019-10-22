using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FacebookClone.Models.Data
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(255)]
        [Display(Name = "First Name")]
        [Required]
        public string NameFirst { get; set; }

        [MaxLength(255)]
        [Display(Name = "Last Name")]
        [Required]
        public string NameLast { get; set; }

        [MaxLength(255)]
        [Display(Name = "Email Address")]
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [MaxLength(100)]
        [Display(Name = "User")]
        [Required]
        public string Username { get; set; }

        [MaxLength(100)]
        [Required]
        public string Password { get; set; }

        [Column(TypeName = "image")]
        public byte[] ProfileImage { get; set; }

        public string NameFull
        {
            get
            {
                return NameFirst + " " + NameLast;
            }
        }

        public string UsernameImage
        {
            get
            {
                return "image/show/" + Id.ToString();
            }
        }
    }
}