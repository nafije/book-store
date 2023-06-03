using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace e_Book.Models
{
    public class ApplicationUser:IdentityUser
    {
        public int Id { get; set; }

        [Display(Name ="Full Name")]
        public string FullNAme { get; set; }
    }
}
