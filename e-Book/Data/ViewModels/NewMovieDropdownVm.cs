using e_Book.Models;

namespace e_Book.Data.ViewModels
{
    public class NewMovieDropdownVm
    {
        public NewMovieDropdownVm()
        {
            Publishing_House = new List<Publishing_house>();
            Authors = new List<Authors>();
        }
        public List<Publishing_house> Publishing_House { get; set; }
        public List<Authors> Authors { get; set; }
    }
}
