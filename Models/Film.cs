using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace CentrulMultimedia.Models
{
    public enum FilmType {
        Action,
        Comedy, 
        Horror, 
        Thriller 
    };
    public class Film
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [MinLength(10)]
        public string Description { get; set; }

        public String Genre { get; set; }

        public FilmType FilmType { get; set; }
        public int LengthInMinutes { get; set; }
        public int YearOfRelease { get; set; }

        public string Director { get; set; }
        
        public DateTime DateTime { get; set; }

        [Range(1,10)]
        public int Rating { get; set; }

        public Boolean Watched { get; set; }

        public List<Comment> Comments { get; set; }

    }
}
