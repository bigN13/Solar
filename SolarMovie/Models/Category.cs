using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace SolarMovie.Models
{
    public class Category
    {
        
        public int CategoryId { get; set; }
        public string Name { get; set; }

        public virtual List<Movie> Movies { get; set; }
    }
}
