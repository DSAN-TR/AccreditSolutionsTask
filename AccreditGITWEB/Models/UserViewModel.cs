using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccreditGITWEB.Models
{
    public class UserViewModel
    {
        [Required]
        public string username { get; set; }
    }
}
