using RedCoreExam_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedCoreExam_API.Contracts
{
    public interface IUserRepository
    {
        User FindByEmailAddress(string emailAddress);
    }
}
