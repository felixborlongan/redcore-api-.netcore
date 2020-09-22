using RedCoreExam_API.Contracts;
using RedCoreExam_API.Models;
using RedCoreExam_API.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedCoreExam_API.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly RedCoreExamDBContext _context;
        public MovieRepository(RedCoreExamDBContext context)
        {
            _context = context;
        }

        public List<Movie> GetMovies()
        {
            return _context.Movie.Where(a => a.IsDeleted == null).ToList();
        }
        public bool Save(MovieVM movie)
        {
            if (movie.MovieId > 0)  // update
            {
                Movie movieToBeUpdated = _context.Movie.Find(movie.MovieId);
                movieToBeUpdated.MovieTitle = movie.MovieTitle;
                movieToBeUpdated.MovieDescription = movie.MovieDescription;
                movieToBeUpdated.IsRented = movie.IsRented;
                movieToBeUpdated.RentalDate = Convert.ToDateTime(movie.RentalDate);

                _context.Entry(movieToBeUpdated).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            else // create
            {
                _context.Movie.Add(new Movie()
                {
                    MovieTitle = movie.MovieTitle,
                    MovieDescription = movie.MovieDescription,
                    IsRented = movie.IsRented,
                    RentalDate = Convert.ToDateTime(movie.RentalDate),
                });
            }

            return _context.SaveChanges() > 0;
        }
        public bool Delete(int id)
        {
            Movie movie = _context.Movie.Find(id);
            movie.IsDeleted = true;

            _context.Entry(movie).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            return _context.SaveChanges() > 0;
        }
    }
}
