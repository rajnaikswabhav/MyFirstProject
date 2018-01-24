using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Master_Page_App.Models.ViewModel
{
    public class UserVM
    {
        [Required(ErrorMessage ="Enter a Username")]
        public string Username { get; set; }

        [Required(ErrorMessage ="Enter a Password")]
        public string Password { get; set; }
    }
}