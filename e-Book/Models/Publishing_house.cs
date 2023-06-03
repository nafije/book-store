using e_Book.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace e_Book.Models
{
    public class Publishing_house:IEntityBase
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Logo")]
        [Required(ErrorMessage = "Publishing House Logo is requred")]
        public string Logo { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Publishing House name is requred")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Publishing House description is requred")]
        public string Description { get; set; }
        public List<Books>? Books { get; set; }
    }
}
