using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieManager.Data;
using MovieManager.Models;

namespace MovieManager.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly MovieManagerContext _context;

        public IndexModel(MovieManagerContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Genres { get; set; }
        [BindProperty(SupportsGet = true)]
        public string MovieGenre { get; set; }

        public async Task OnGetAsync()
        {
            // retrieves all genres in the database
            IQueryable<string> genreQuery = from m in _context.Movie
                                            orderby m.Genre
                                            select m.Genre;

            // retrieve all movies from the database
            var movies = from m in _context.Movie
                         select m;

            if (!string.IsNullOrEmpty(SearchString)) movies = movies.Where(s => s.Title.Contains(SearchString));
            if (!string.IsNullOrEmpty(MovieGenre)) movies = movies.Where(x => x.Genre == MovieGenre);

            Movie = await movies.ToListAsync();
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
        }
    }
}
