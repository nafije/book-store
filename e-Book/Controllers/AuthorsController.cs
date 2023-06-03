using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using e_Book.Data;
using e_Book.Data.Services;
using e_Book.Data.Static;
using e_Book.Models;
using System.Diagnostics.Eventing.Reader;

namespace Movie_Ticket.Controllers
{
    [Authorize(Roles = UserRole.Admin)]
    public class AuthorsController : Controller
    {
        private readonly IAuthorsService _service;
        public AuthorsController(IAuthorsService service)
        {
            _service = service;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }
        //Get:Actors/Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>Create([Bind("FullName,ProfilePicture,Bio")]Authors authors)
        {
            if(!ModelState.IsValid)
            {
                return View(authors);
            }
            else
            {
                await _service.AddAsync(authors);
                return RedirectToAction(nameof(Index));
            }
           

        }
        //Get:Actors/Details/ID
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var authorDetails = await _service.GetByIdAsync(id);
            if (authorDetails == null)
            {
                return View("NotFound");
            }
            else
            {
                return View(authorDetails);
            }
           
        }
        //Get:Actors/Edit
        public async Task<IActionResult> Edit(int id)
        { 
            var authorDetails = await _service.GetByIdAsync(id);
            if (authorDetails == null)
            {
                return View("NotFound");
            }
            else
            {
                return View(authorDetails);
            }
           
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id,[Bind("ID,FullName,ProfilePicture,Bio")] Authors authors)
        {
            if (!ModelState.IsValid)
            {
                return View(authors);
            }
            else
            {
                
                //authors.Actors_Movies = 0;
                await _service.UpdateAsync(id, authors);
                return RedirectToAction(nameof(Index));
            } 
            

        }
        //Get:Actors/Delete
        public async Task<IActionResult> Delete(int id)
        {
            var authorDetails = await _service.GetByIdAsync(id);
            if (authorDetails == null)
            {
                return View("NotFound");
            }
            else
            {
                return View(authorDetails);
            }
           
        }
        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var authorDetails = await _service.GetByIdAsync(id);
            if (authorDetails == null)
            {
                return View("NotFound");
            }
            else
            {
                await _service.DeleteAsync(id);
                return RedirectToAction(nameof(Index));
            }
            
        }
    }
}
