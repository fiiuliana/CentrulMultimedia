using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CentrulMultimedia.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime DateTime { get; set; }
        public int Stars { get; set; }
        public Film Film { get; set; } 

    }
}
