using System.ComponentModel.DataAnnotations;

namespace e_Book.Models
{
    public class ShopinCartItem
    {
        [Key]
        public int Id { get; set; }
        public Books Books { get; set; }
        public int Amount { get; set; }
        public string ShopingCartId { get; set; }
    }
}
