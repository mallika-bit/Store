using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Store.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name="Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name="Date Added")]
        public DateTime DateAdded { get; set; }

        [Required]
        [Range(1,20)]
        [Display(Name="Stock")]
        public int NumbersInStock { get; set; }

        public Genres Genres { get; set; }

        [Required]
        public int  GenresId { get; set; }


    }
}