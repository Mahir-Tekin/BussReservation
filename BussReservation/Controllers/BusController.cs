using BussReservation.Data;
using BussReservation.Migrations;
using BussReservation.Models;
using BussReservation.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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
        [Authorize(Roles = SD.Role_Admin)]
        public IActionResult BusList()
        {
            var objBusList = _context.Buses.ToList();
            return View(objBusList);
        }
        [Authorize(Roles = SD.Role_Admin)]
        public IActionResult Ata(int Id)
        {
            HttpContext.Session.SetInt32("Otobus", Id);
            var objGuzergahList = _context.guzergahlars.ToList();
            return View(objGuzergahList);
        }
        [Authorize(Roles = SD.Role_Admin)]
        public IActionResult Tarih(int Id)
        {
            Bus atanacakOtobus = _context.Buses.Find(HttpContext.Session.GetInt32("Otobus"));
            if(atanacakOtobus != null)
            {
                atanacakOtobus.GuzergahlarId = Id;
                _context.Buses.Update(atanacakOtobus);
                _context.SaveChanges();
            }
            return View();
        }
        [Authorize(Roles = SD.Role_Admin)]
        [HttpPost]
        public IActionResult Tarih(Tarih obj)
        {
            Bus atanacakOtobus = _context.Buses.Find(HttpContext.Session.GetInt32("Otobus"));
            if (atanacakOtobus != null)
            {
                atanacakOtobus.KalkisTarihi = obj.KalkisTarihi;
                atanacakOtobus.Fiyat=obj.Fiyat;
                _context.Buses.Update(atanacakOtobus);
                _context.SaveChanges();
            }
            return RedirectToAction("Index", "Home");

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
        [Authorize(Roles = SD.Role_Admin)]
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
                    koltuk.YolcuId = "*";
                    _context.Koltuks.Add(koltuk);
                }
                bus.KoltukAtandi = 1;
                _context.Buses.Update(bus);
                _context.SaveChanges();



                return RedirectToAction("BusList");
            }
            ViewBag.Koltuklar = new List<SelectListItem>
            {
                new SelectListItem { Value = "2+2", Text = "2+2" },
                new SelectListItem { Value = "2+1", Text = "2+1"  },
            };
            ViewBag.hata = "başarısız";
            return View();
        }
        [Authorize(Roles = SD.Role_Admin)]
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
        [Authorize(Roles = SD.Role_Admin + "," + SD.Role_Customer)]
        public IActionResult KoltukGetir(int id)
        {
            ViewBag.duzen=_context.Buses.Find(id).KoltukDuzeni;
            var koltuklar = _context.Koltuks.Where(x=>x.BusId == id).ToList();
            return View(koltuklar);
        }
        [Authorize(Roles = SD.Role_Admin + "," + SD.Role_Customer)]
        public IActionResult KoltukKaydet(int id)
        {
            Koltuk alinan=_context.Koltuks.Find(id);
            alinan.YolcuId = User.Identity.Name;
            _context.Koltuks.Update(alinan);
            _context.SaveChanges();
            TempData["durum"] = "Satın Alma Başarılı!";
            return RedirectToAction("KoltukGetir",new {id=alinan.BusId});
        }
        [Authorize(Roles = SD.Role_Admin + "," + SD.Role_Customer)]
        public IActionResult Biletlerim()
        {
            ViewBag.TumGuzergahlar = _context.guzergahlars.ToList();
            ViewBag.TumOtobusler=_context.Buses.ToList();
            var koltuklarim=_context.Koltuks.Where(x=>x.YolcuId==User.Identity.Name).ToList();
            return View(koltuklarim);
        }
        [Authorize(Roles = SD.Role_Admin + "," + SD.Role_Customer)]
        public IActionResult BiletSil(int id)
        {
            Koltuk silinecek = _context.Koltuks.Find(id);
            silinecek.YolcuId = "*";
            _context.Koltuks.Update(silinecek);
            _context.SaveChanges();
            return RedirectToAction("Biletlerim");
        }

        public List<Koltuk> BosKoltuklar()
        {
            List<Koltuk> koltuklar = _context.Koltuks.Where(x => x.YolcuId == "*").ToList();
            return koltuklar;
        }
    }
}
