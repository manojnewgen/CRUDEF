using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDEF.Models
{
    public class Eemployee
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name="Email Address")]
        public string EmailID { get; set; }

        [Required]
        public int Mobile { get; set; }



    }
}
