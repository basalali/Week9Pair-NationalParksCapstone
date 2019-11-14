using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class Survey
    {
        [MinLength(3, ErrorMessage = "Please enter at least three characters")]
        [Required]
        public string ParkCode { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }

        [MinLength(2, ErrorMessage = "Please enter at least two characters")]
        [Required]
        public string State { get; set; }

        [Required]
        public string ActivityLevel { get; set; }

        public string Results { get; set; }
    }
}
