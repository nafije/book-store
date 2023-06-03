using e_Book.Controllers;
using e_Book.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using static System.Reflection.Metadata.BlobBuilder;
using BooksModel = e_Book.Models.Books;
namespace e_Book.Data.Cart
{
    public class ShopingCart
    {
        public AppDbContext _context { get; set; }
        public string ShopinCartID { get; set; }
        public List<ShopinCartItem> ShopinCartItems { get; set; }
        public ShopingCart(AppDbContext context)
        {
            _context = context;
        }
        public static ShopingCart GetShopingCart(IServiceProvider service)
        {
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = service.GetService<AppDbContext>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);
            return new ShopingCart(context) { ShopinCartID = cartId };
        }
        

        public void AddItemToCart(BooksModel books)
        {
            
            //var books = new BooksModel();

            var shoppingCartItem = _context.ShopinCartItems.FirstOrDefault(n => n.Books.ID== books.ID && n.ShopingCartId == ShopinCartID);
            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShopinCartItem()
                {
                    ShopingCartId = ShopinCartID,
                    Books = books,
                    Amount = 1
                };

                _context.ShopinCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            _context.SaveChanges();
        }
        public void RemoveItemFromCart(BooksModel books)
        {
            var shoppingCartItem = _context.ShopinCartItems.FirstOrDefault(n => n.Books.ID == books.ID && n.ShopingCartId == ShopinCartID);
            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                }
                else
                {
                    _context.ShopinCartItems.Remove(shoppingCartItem);
                }
            }
            _context.SaveChanges();
        }
        public List< ShopinCartItem>GetShopinCartItems()

        {
            return ShopinCartItems ?? (ShopinCartItems = _context.ShopinCartItems.Where(n => n.ShopingCartId == 
            ShopinCartID).Include(n => n.Books).ToList());
        }  
        public double GetShoppingCartTotal()=> _context.ShopinCartItems.Where(n => n.ShopingCartId == ShopinCartID).Select(n => n.Books.Price * n.Amount).Sum();
        
        public async Task clearShppinCartAsync()
        {
            var items =await _context.ShopinCartItems.Where(n => n.ShopingCartId ==
            ShopinCartID).ToListAsync();
            _context.ShopinCartItems.RemoveRange(items);
            await _context.SaveChangesAsync();
        }
    }
}
