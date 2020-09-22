using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedCoreExam_API.Contracts
{
    public interface IRedCoreDataProtector
    {
        string Protect(string input);
        string Unprotect(string input);
    }
}
