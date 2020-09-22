using RedCoreExam_API.Models;
using RedCoreExam_API.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedCoreExam_API.Contracts
{
    public interface IMovieRepository
    {
        List<Movie> GetMovies();
        bool Save(MovieVM movie);
        bool Delete(int id);
    }
}
