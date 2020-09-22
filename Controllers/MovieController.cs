using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RedCoreExam_API.Contracts;
using RedCoreExam_API.Models;
using RedCoreExam_API.Models.ViewModels;

namespace RedCoreExam_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieRepository _movieRepository;
        public MovieController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        [HttpPost("Save")]
        public IActionResult Save([FromBody] MovieVM movie)
        {
            return Ok(new APIResponseVM()
            {
                Status = _movieRepository.Save(movie),
                Message = "Success"
            });
        }
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            return Ok(new APIResponseVM()
            {
                Status = _movieRepository.Delete(id),
                Message = "Success"
            });
        }
    }
}