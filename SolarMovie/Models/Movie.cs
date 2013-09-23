using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace SolarMovie.Models
{
    public class Movie
    {
        [Key, StringLength(50)]
        public int MovieId { get; set; }

        [Required, StringLength(50)]
        public int ParentId { get; set; }

        [Required, StringLength(500)]
        public string Title { get; set; }
        public string Content { get; set; }
        public string Link { get; set; }


        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
