using e_Book.Models;
using Microsoft.EntityFrameworkCore;
using e_Book.Data.Base;
using e_Book.Data.ViewModels;

namespace e_Book.Data.Services
{
    public class BookService : EntityBaseRepository<Books>, IbookService
    {
        private readonly AppDbContext _context;
        public BookService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public void AddComents(Coments coments)
        {
            _context.Coments.Add(coments);
            _context.SaveChanges();
        }

        public async Task AddNewBookAsync(NewBookVM data)
        {
            var newBook = new Books()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                ImageURL = data.ImageURL,
                Publishing_HouseId = data.Publishing_houseID,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                BookCategory = data.BookCategory,
            };
            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();
            //Add Movie Actors
            foreach (var authorid in data.AuthorIDs)
            {
                var newAuthorMovie = new Author_Book()
                {
                    BookId = newBook.ID,
                    AuthorID = authorid
                };
                await _context.Author_Book.AddAsync(newAuthorMovie);
            }
            await _context.SaveChangesAsync();
        }

        public void DeleteComent(int id)
        {
            var result = _context.Coments.FirstOrDefault(n => n.ID == id);
            _context.Coments.Remove(result);
            _context.SaveChanges();
        }

        public Task<Coments> GetAll_coments(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Books> GetBookByIdAsync(int id)
        {
           // var commentdata = await _context.Coments;
            var movieDetails = await _context.Books
                .Include(c => c.Publishing_House)
                .Include(am => am.Author_Book).ThenInclude(a => a.Authors)
                .Include(cm => cm.Coments)
                .FirstOrDefaultAsync(n => n.ID == id);
            return movieDetails;
        }

        public async Task<NewMovieDropdownVm> GetNewBookDropdownValues()
        {
            var response = new NewMovieDropdownVm()
            {
                Authors = await _context.Authors.OrderBy(c => c.FullName).ToListAsync(),
                Publishing_House = await _context.Publishing_house.OrderBy(c => c.Name).ToListAsync(),
            };
            return response;
        }

        public async Task UpdateBookAsync(NewBookVM data)
        {
            var dbBook = await _context.Books.FirstOrDefaultAsync(n => n.ID == data.ID);
            if (dbBook != null)
            {
                //var newMovie = new Movie()

                dbBook.Name = data.Name;
                dbBook.Description = data.Description;
                dbBook.Price = data.Price;
                dbBook.ImageURL = data.ImageURL;
                dbBook.Publishing_HouseId = data.Publishing_houseID;
                dbBook.StartDate = data.StartDate;
                dbBook.EndDate = data.EndDate;
                dbBook.BookCategory = data.BookCategory;
                await _context.SaveChangesAsync();
            }
                //Remove
                var existingAuthotDb = _context.Author_Book.Where(n => n.BookId == data.ID).ToList();
                _context.Author_Book.RemoveRange(existingAuthotDb);
                await _context.SaveChangesAsync();

                //add Movie Author
                foreach (var authorid in data.AuthorIDs)
                {
                    var newAuthorMovie = new Author_Book()
                    {
                        BookId = data.ID,
                        AuthorID = authorid
                    };
                    await _context.Author_Book.AddAsync(newAuthorMovie);
                }
            await _context.SaveChangesAsync();

        }

    }
}
