using System;
using System.Collections.Generic;

namespace RedCoreExam_API.Models
{
    public partial class User
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
    }
}
