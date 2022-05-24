using System;
using System.ComponentModel.DataAnnotations;

namespace MovieManager.Models
{
    public class Movie
    {
        public int ID { get; set; } // primary key
        public string Title { get; set; }

        [DataType(DataType.Date)] // user is not forced to enter time info and the time is ommitted
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }

    }
}
