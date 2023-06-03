using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using e_Book.Data;
using e_Book.Data.Services;
using e_Book.Data.Static;
using e_Book.Models;

namespace Movie_Ticket.Controllers
{
    [Authorize(Roles = UserRole.Admin)]
    public class Publishing_houseController : Controller
    {
        private readonly IPublishing_houseService _service;
        public Publishing_houseController(IPublishing_houseService service)
        {
            _service = service;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allCinemas = await _service.GetAllAsync();
            return View(allCinemas);
        }
        //Get:Cinema/Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Logo,Name,Description")]Publishing_house Publishing_house)
        {
            if(!ModelState.IsValid)
            {
                return View(Publishing_house);
            }
            else
            {
                await _service.AddAsync(Publishing_house);
                return RedirectToAction(nameof(Index));
            }
        }
        //Get:Cinema/Details.id
        [AllowAnonymous]
        public async Task<IActionResult>Details(int id)
        {
            var cinemaDetails = await _service.GetByIdAsync(id);
            if (cinemaDetails == null)
            {
                return View("NotFound");
            }
            else
            {
                return View(cinemaDetails);
            }
        }
        //Get: Cinema/Edit/id
        public async Task<IActionResult> Edit(int id)
        {
            var pHouseDetails = await _service.GetByIdAsync(id);
            if (pHouseDetails == null)
            {
                return View("NotFound");
            }
            else
            {
                return View(pHouseDetails);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id,[Bind("ID,Logo,Name,Description")] Publishing_house Publishing_house)
        {
            if (!ModelState.IsValid)
            {
                return View(Publishing_house);
            }
            else
            {
                await _service.UpdateAsync(id, Publishing_house);
                return RedirectToAction(nameof(Index));
            }
        }
        //Get: Cinema/Delete/id
        public async Task<IActionResult> Delete(int id)
        {
            var cinemaDetails = await _service.GetByIdAsync(id);
            if (cinemaDetails == null)
            {
                return View("NotFound");
            }
            else
            {
                return View(cinemaDetails);
            }
        }
        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
