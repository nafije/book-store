using e_Book.Models;
using Microsoft.EntityFrameworkCore;

namespace e_Book.Data.Services
{
    public class OrdersService : IOrdersServices
    {

        private readonly AppDbContext _context;
        public OrdersService(AppDbContext context)
        {
            _context=context;
        }
        public async Task<List<Order>> GetOrderByUserIdAndRoleAsync(string userId,string userRole)
        {
            var orders= await _context.Orders.Include(n=>n.OrderItems).ThenInclude(n=>n.Books).Include(n=>n.User).ToListAsync();
            if (userRole!="Admin")
            {
                orders=orders.Where(n=>n.UserId==userId).ToList();
            }
            return orders;
        }

        public async Task StoreOrderAsync(List<ShopinCartItem> items, string userId, string userEmailAddress)
        {
            var order = new Order()
            {
                UserId = userId,
                Email = userEmailAddress
            };
            await _context.Orders.AddAsync(order);  
            await _context.SaveChangesAsync();
            foreach (var item in items)
            {
                var orderItem = new OrderItem()
                {
                    Amount = item.Amount,
                    BookId = item.Books.ID,
                    OrderId = order.Id,
                    Price = item.Books.Price

                };
                await _context.OrderItems.AddAsync(orderItem);
                await _context.SaveChangesAsync();
            }

        }
    }
}
