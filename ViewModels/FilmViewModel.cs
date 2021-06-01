using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CentrulMultimedia.ViewModels
{
    public class FilmViewModel
    {
        public int Id { get; set; }       
        public string Title { get; set; }        
        public string Description { get; set; }
        public String Genre { get; set; }
        public int LengthInMinutes { get; set; }
        public int YearOfRelease { get; set; }
        public string Director { get; set; }
        public DateTime DateTime { get; set; }      
        public int Rating { get; set; }
        public Boolean Watched { get; set; }
    }
}
