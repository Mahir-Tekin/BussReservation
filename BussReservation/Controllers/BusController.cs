using BussReservation.Data;
using BussReservation.Models;
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

        public IActionResult Ata(int Id)
        {
            ViewBag.Guzergah=Id;
            var objBusList = _context.Buses.ToList();
            return View(objBusList);
        }

        public IActionResult Tarih(int Id)
        {
            Bus atanacakOtobus = _context.Buses.Find(Id);
            return View(atanacakOtobus);
        }
        [HttpPost]
        public IActionResult Tarih(Bus obj)
        {
            //tarihin girileceği sayfayı yaparken bıraktın
            return View();
        }

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
    }
}
