using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedCoreExam_API.Models.ViewModels
{
    public class APIResponseVM
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public object Value { get; set; }

    }
}
