using e_Book.Models;
using e_Book.Data.Base;
using e_Book.Data.ViewModels;


namespace e_Book.Data.Services
{
    public interface IbookService:IEntityBaseRepository<Books>
    {
        Task<Books> GetBookByIdAsync(int id);
        Task<Coments> GetAll_coments(int id);

        Task<NewMovieDropdownVm> GetNewBookDropdownValues();
        Task AddNewBookAsync(NewBookVM data);
        Task UpdateBookAsync(NewBookVM data);
        void DeleteComent(int id);
       // IEnumerable<Coments> GetAll_coments(int id);
        void AddComents(Coments coments);
    }
}
