using Microsoft.EntityFrameworkCore;
using e_Book.Data.Base;
using e_Book.Models;

namespace e_Book.Data.Services
{
    public class AuthorsService :EntityBaseRepository<Authors>, IAuthorsService
    {
        private readonly AppDbContext _context;
        public AuthorsService(AppDbContext context):base(context) { }
 
       
    }
}
