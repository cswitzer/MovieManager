using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieManager.Models
{
    public class Movie
    {
        public int ID { get; set; } // primary key
        public string Title { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)] // user is not forced to enter time info and the time is ommitted
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

    }
}
