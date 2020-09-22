using RedCoreExam_API.Contracts;
using RedCoreExam_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedCoreExam_API.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly RedCoreExamDBContext _context;
        public UserRepository(RedCoreExamDBContext context)
        {
            _context = context;
        }
        public User FindByEmailAddress(string emailAddress)
        {
            return _context.User.FirstOrDefault(a => a.EmailAddress.ToLower() == emailAddress.ToLower());
        }
    }
}
