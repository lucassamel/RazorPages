using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazzorPages.Data;

namespace RazorPages.Pages.Movies
{
    public class IndexModel(MoviesContext moviesContext) : PageModel
    {
        public ICollection<Movie> Movies { get; private set; }

        public void OnGet()
        {
            Movies = moviesContext.Movies.ToList();
        }
    }
}
