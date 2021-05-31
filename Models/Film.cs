using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CentrulMultimedia.Models
{
    public class Film
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public int LengthInMinutes { get; set; }
        public int YearOfRelease { get; set; }
        public string Director { get; set; }
        public DateTime DateAdded { get; set; }
        public int Rating { get; set; }
        public Boolean Watched { get; set; }

    }
}
