using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace SolarMovie.Models
{
    public class MoviesContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Movie> Movies { get; set; }

        public MoviesContext()
            : base("SolarDatabase")
        {
        }
    }
}
