using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name="Title")]
        public string Name { get; set; }

        public Genre Genre { get; set; }

        [Required]
        [Display(Name="Genre")]
        public short GenreId { get; set; }

        [Required]
        [Display(Name="Release Date")]
        [Column(TypeName = "date")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Date Added")]
        [Column(TypeName = "date")]
        public DateTime DateAdded { get; set; }

        [Required]
        [Display(Name="Number in Stock")]
        [Range(1, 20)]
        public byte NumberInStock { get; set; }

        [Required]
        [Display(Name = "Number Available")]
        public byte NumberAvailable { get; set; }

    }
}