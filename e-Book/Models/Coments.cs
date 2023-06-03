using Microsoft.EntityFrameworkCore.Metadata;
using e_Book.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace e_Book.Models
{
    public class Coments
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "Comment")]
        [Required(ErrorMessage = "Comment can't be empty")]
        public string Comment { get; set; }
        public string FullName { get; set; }
        public DateTime CommentedOn { get; set; }
        public int BookID { get; set; }
        [ForeignKey("BookID")]
      //  public Poste Post { get; set; } 
        public Books Books { get; set; }

    }
}
