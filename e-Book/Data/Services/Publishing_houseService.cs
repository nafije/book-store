using e_Book.Data.Base;
using e_Book.Models;

namespace e_Book.Data.Services
{
    public class Publishing_houseService:EntityBaseRepository<Publishing_house>,IPublishing_houseService
    {
        public Publishing_houseService(AppDbContext contex):base(contex)
        {
            
        }
    }
}
