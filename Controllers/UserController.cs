using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RedCoreExam_API.Contracts;
using RedCoreExam_API.Models.ViewModels;

namespace RedCoreExam_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRedCoreDataProtector _redCoreDataProtector;
        private readonly IUserRepository _userRepository;
        private readonly IMovieRepository _movieRepository;
        public UserController(IRedCoreDataProtector redCoreDataProtector, IUserRepository userRepository, IMovieRepository movieRepository)
        {
            _redCoreDataProtector = redCoreDataProtector;
            _userRepository = userRepository;
            _movieRepository = movieRepository;
        }
        [HttpGet("Authenticate")]
        public IActionResult Authenticate([FromQuery] string emailAddress, [FromQuery] string password)
        {
            RedCoreExam_API.Models.User user = _userRepository.FindByEmailAddress(emailAddress);

            if (user != null && _redCoreDataProtector.Unprotect(user.Password) == password)
            {

                return Ok(new APIResponseVM()
                {
                    Status = true,
                    Message = "Success Logged In.",
                    Value = JsonConvert.SerializeObject(_movieRepository.GetMovies())
                });
            }
            else
            {
                return Ok(new APIResponseVM()
                {
                    Status = false,
                    Message = "Wrong Credentials"
                });
            }          
        }
    }
}