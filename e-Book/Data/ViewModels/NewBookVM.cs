using e_Book.Data.Base;
using e_Book.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace e_Book.Models
{
    public class NewBookVM
    {
        public int ID { get; set; }
        [Display(Name = "Book name")]
        [Required(ErrorMessage ="Name is required")]
        public string Name { get; set; }

        [Display(Name = "Book description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Display(Name = "Price in $")]
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }

        [Display(Name = "Book Image")]
        [Required(ErrorMessage = "Book image is required")]
        public string ImageURL { get; set; }

        [Display(Name = "Start date")]
        [Required(ErrorMessage = "start date is required")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End date")]
        [Required(ErrorMessage = "End date is required")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Select category")]
        [Required(ErrorMessage = "Book category is required")]
        public BookCategory BookCategory { get; set; }
        //Reltionships
        [Display(Name = "Select author(s)")]
        [Required(ErrorMessage = "Book author(s) is required")]
        public List<int > AuthorIDs { get; set; }
        [Display(Name = "Select publishing house")]
        [Required(ErrorMessage = "Book publishing house is required")]
        public int Publishing_houseID { get; set; }
       
    }
}
