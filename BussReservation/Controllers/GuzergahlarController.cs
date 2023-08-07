using BussReservation.Data;
using BussReservation.Models;
using BussReservation.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace BussReservation.Controllers
{
    public class GuzergahlarController : Controller
    {
        private readonly ApplicationDbContext _context;
        public GuzergahlarController(ApplicationDbContext context)
        {
            _context = context; 
        }
        public IActionResult Index()
        {
            var objGuzergahlarList = _context.guzergahlars.ToList();
            return View(objGuzergahlarList);
        }
        [Authorize(Roles = SD.Role_Admin)]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = SD.Role_Admin)]
        public IActionResult Create(Guzergahlar obj)
        {
            if(ModelState.IsValid)
            {
                _context.guzergahlars.Add(obj);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
