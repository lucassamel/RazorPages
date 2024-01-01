using Microsoft.EntityFrameworkCore;
using Slugify;

namespace RazzorPages.Data
{
    public class MoviesContext : DbContext
    {
        public MoviesContext()
        {
            this.Database.EnsureCreated();
        }

        public MoviesContext(DbContextOptions<MoviesContext> options) : base(options) 
        {
            this.Database.EnsureCreated();
        }

        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var slugfy = new SlugHelper();

            string[] names = [
                "O Poderoso Chefão",
                "007",
                "Duna",
                "Spiderman"
            ];

            int counter = 1;
            var movies = new List<Movie>();
            foreach(var name in names)
            {
                movies.Add(
                    new Movie
                    {
                        Id = counter,
                        Name = name,
                        Permalink = slugfy.GenerateSlug(name)
                    });
                counter++;
            }           

            modelBuilder
                .Entity<Movie>()
                .HasData(movies);
        }
    }
}
