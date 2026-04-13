using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MovieApp.Data.Models
{
    public class Movie
    {
        public int MovieId {  get; set; }

        [Required(ErrorMessage ="Title is Required")]
        public string? Title { get; set; }

        public string? Genre {  get; set; }

        [DataType(DataType.Date)]
        public DateTime? ReleaseDate {  get; set; }

        [Range(1,int.MaxValue,ErrorMessage ="Duration must be Positive")]
        public int? Duration { get; set; }

        [Range(1, 10, ErrorMessage = "Rating must be between 1 and 10")]
        public double? Rating { get; set; }

        public string? Language {  get; set; }
    }
}
