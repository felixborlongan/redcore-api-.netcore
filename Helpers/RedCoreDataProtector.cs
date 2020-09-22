using Microsoft.AspNetCore.DataProtection;
using RedCoreExam_API.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedCoreExam_API.Helpers
{
    public class RedCoreDataProtector : IRedCoreDataProtector
    {
        private readonly IDataProtector _protector;
        public RedCoreDataProtector(IDataProtectionProvider dataProtectionProvider)
        {
            _protector = dataProtectionProvider.CreateProtector("RedCoreExam");
        }
        public string Protect(string input)
        {
            return _protector.Protect(input);
        }
        public string Unprotect(string input)
        {
            return _protector.Unprotect(input);
        }
    }
}
