using e_Book.Models;
using e_Book.Data.Base;
using e_Book.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace e_Book.Models
{
    public class Books:IEntityBase
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Price")]
        public double Price { get; set; }

        [Display(Name = "Book Image")]
        public string ImageURL { get; set; }
        
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public BookCategory BookCategory { get; set; }
        //Reltionships
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public List<Author_Book> Author_Book { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        //cinema
        public int Publishing_HouseId { get; set; }

        //private ForeignKey[("CinemaId")]
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Publishing_house Publishing_House { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

      

        public List<Coments> Coments { get; set; }

        public static implicit operator Books(Controllers.Books v)
        {
            throw new NotImplementedException();
        }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }
}
