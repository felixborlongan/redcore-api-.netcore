using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedCoreExam_API.Models.ViewModels
{
    public class MovieVM
    {
        public int MovieId { get; set; }
        public string MovieTitle { get; set; }
        public string MovieDescription { get; set; }
        public bool? IsRented { get; set; }
        public string RentalDate { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
