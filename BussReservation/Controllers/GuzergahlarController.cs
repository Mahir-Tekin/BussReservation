using BussReservation.Data;
using BussReservation.Models;
using Microsoft.AspNetCore.Mvc;

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

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
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
