using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using e_Book.Data;
using e_Book.Data.Services;
using e_Book.Models;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using e_Book.Data.Static;
using e_Book.Models;

namespace e_Book.Controllers
{
    [Authorize(Roles = UserRole.Admin)]
    public class Books : Controller
    {
        private readonly IbookService _service ;
        internal int id;

        public Books(IbookService service)
        {
            _service = service;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            
            var allBook = await _service.GetAllAsync(n=>n.Publishing_House);
            return View(allBook);
        }
        [AllowAnonymous]
        public async Task<IActionResult> Filter(string searchString)
        {
            var allBook = await _service.GetAllAsync(n => n.Publishing_House);
            if(!string.IsNullOrEmpty(searchString))
            {
                var filterResult= allBook.Where(n=>n.Name.Contains(searchString) || n.Description.Contains(searchString)).ToList();
                return View("Index", filterResult);
            }
            else
            {
                return View("Index", allBook);
            }
            
        }
        //Get: Movies/Details/id
        [AllowAnonymous]
        public async Task<IActionResult>Details(int id)
        {
            //var comments = await _service.GetAll_coments.Where(c => c.MovieId == movieId).ToListAsync();
           
            var movieDetail = await _service.GetBookByIdAsync(id);
            //var commentdata = await _service.GetAll_coments(id);
            return View(movieDetail);
        }
        //Get: Movies/Create
        public async Task< IActionResult> Create() 
        {
            var movieDropdownData = await _service.GetNewBookDropdownValues();
            ViewBag.Publishing_House = new SelectList(movieDropdownData.Publishing_House, "ID", "Name");
            ViewBag.Actors = new SelectList(movieDropdownData.Authors, "ID", "FullName");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(NewBookVM book)
        {
            if (!ModelState.IsValid) 
            {
                var movieDropdownData = await _service.GetNewBookDropdownValues();
                ViewBag.Publishing_House = new SelectList(movieDropdownData.Publishing_House, "ID", "Name");
                ViewBag.Actors = new SelectList(movieDropdownData.Authors, "ID", "FullName");

                return View(book);
            }
            else
            {
                await _service.AddNewBookAsync(book);
                return RedirectToAction("Index");
            }
        }
        //Get: Poste/Details/AddComent
        //public IActionResult AddComet()
        //{
        //    return View();
        //}
        [HttpPost]
        public IActionResult AddComet(Coments coments)
        {
            if (string.IsNullOrEmpty(coments.Comment))
            {
                TempData["Error"] = "This email addres is alredy in use.";
                return View("Not_empty");
            }
            else
            {
                //Add CommentedOn
                coments.CommentedOn = DateTime.Now;
                coments.FullName = User.Identity.Name; ;
                _service.AddComents(coments);
                return RedirectToAction(nameof(Index));
            }
        }
        //Delte comment
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            _service.DeleteComent(id);
            return RedirectToAction("Index", "Books");
        }
        //Get: Movie/Edit/id
        public async Task<IActionResult> Edit(int id)
        {
            var movieDetail = await _service.GetBookByIdAsync(id);
            if(movieDetail == null)
            {
                return View("NotFound");
            }
            else
            {
                var response = new NewBookVM()
                {
                    ID = movieDetail.ID,
                    Name = movieDetail.Name,
                    Description = movieDetail.Description,
                    Price = movieDetail.Price,
                    StartDate=movieDetail.StartDate,
                    EndDate=movieDetail.EndDate,
                    ImageURL = movieDetail.ImageURL,
                    BookCategory = movieDetail.BookCategory,
                    Publishing_houseID = movieDetail.Publishing_HouseId,
                    AuthorIDs = movieDetail.Author_Book.Select(n => n.AuthorID).ToList(),

                };
                var movieDropdownData = await _service.GetNewBookDropdownValues();
                ViewBag.Publishing_House = new SelectList(movieDropdownData.Publishing_House, "ID", "Name");
                ViewBag.Actors = new SelectList(movieDropdownData.Authors, "ID", "FullName");
                return View(response);
            }

        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewBookVM book)
        {
            if (id!= book.ID)
            {
                return View("NotFound");
            }
            if (!ModelState.IsValid)
            {
                var movieDropdownData = await _service.GetNewBookDropdownValues();
                ViewBag.Publishing_House = new SelectList(movieDropdownData.Publishing_House, "ID", "Name");
                ViewBag.Actors = new SelectList(movieDropdownData.Authors, "ID", "FullName");

                return View(book);
            }
            else
            {
                await _service.UpdateBookAsync(book);
                return RedirectToAction("Index");
            }
        }
    }
}
