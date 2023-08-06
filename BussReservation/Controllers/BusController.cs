using BussReservation.Data;
using BussReservation.Models;
using BussReservation.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BussReservation.Controllers
{
    public class BusController : Controller
    {
        private readonly ApplicationDbContext _context;
        public BusController(ApplicationDbContext context)
        {      
            _context = context;
        }
        public IActionResult Index(int Id)
        {
            var objBusList=_context.Buses.Where(p=>p.GuzergahlarId==Id).ToList();
            return View(objBusList);
        }

        public IActionResult BusList()
        {
            var objBusList = _context.Buses.ToList();
            return View(objBusList);
        }

        public IActionResult Ata(int Id)
        {
            HttpContext.Session.SetInt32("Otobus", Id);
            var objGuzergahList = _context.guzergahlars.ToList();
            return View(objGuzergahList);
        }

        public IActionResult Tarih(int Id)
        {
            HttpContext.Session.SetInt32("Guzergah", Id);
            Bus atanacakOtobus = _context.Buses.Find(HttpContext.Session.GetInt32("Otobus"));
            return View(atanacakOtobus);
        }
        [HttpPost]
        public IActionResult Tarih(Bus obj)
        {
            obj.GuzergahlarId = (int)HttpContext.Session.GetInt32("Guzergah");
            _context.Buses.Update(obj);
            _context.SaveChanges();
            return RedirectToAction("Index","Guzergahlar");
        }
        [Authorize(Roles =SD.Role_Admin)]
        public IActionResult Create()
        {
            ViewBag.Koltuklar= new List<SelectListItem>
        {
            new SelectListItem { Value = "2+2", Text = "2+2" },
            new SelectListItem { Value = "2+1", Text = "2+1"  },
        };
            return View();
        }
        [HttpPost]
        public IActionResult Create(Bus obj)
        {
            if (ModelState.IsValid)
            {
                _context.Buses.Add(obj);
                _context.SaveChanges();
                Bus bus = _context.Buses.First(p => p.KoltukAtandi == 0);
                for (int i = 0; i < obj.Koltuk; i++)
                {
                    Koltuk koltuk=new Koltuk();
                    koltuk.KoltukNo = i;
                    koltuk.BusId = bus.Id;
                    _context.Koltuks.Add(koltuk);
                }
                bus.KoltukAtandi = 1;
                _context.Buses.Update(bus);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            var koltuklar = _context.Koltuks.Where(x => x.BusId == id);
            foreach(var koltuk in koltuklar)
            {
                _context.Koltuks.Remove(koltuk);
            }
            Bus bus = _context.Buses.First(x=>x.Id==id);
            _context.Buses.Remove(bus);
            _context.SaveChanges();
            return RedirectToAction("BusList");
        }
    }
}
