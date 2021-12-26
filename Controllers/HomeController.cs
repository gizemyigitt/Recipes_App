using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebSite.Data;
using WebSite.Models;
using WebSite.Models.ViewModels;

namespace WebSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
           
            var model = new HomeViewModel();
            model.Tatli = _context.Tatli.ToList();
            model.Malzeme = _context.Malzeme.ToList();
            model.Kategori = _context.Kategori.ToList();
            model.TatliMalzeme = _context.TatliMalzeme.ToList();
            return View(model);

        }
        public IActionResult TatliIndex()
        {
            var model = new HomeViewModel();
            model.Tatli = _context.Tatli.ToList();
            model.Malzeme = _context.Malzeme.ToList();
            model.Kategori = _context.Kategori.ToList();
            model.TatliMalzeme = _context.TatliMalzeme.ToList();
            return View(model);
        }
       
        public IActionResult TatliDetay(int id)
        {
            HomeViewModel HomeVm = new HomeViewModel()
            {

                Tatli = _context.Tatli.Where(x => x.Id == id).ToList()
            };

            return View(HomeVm);
           
        }

        private IActionResult HttpNotFound()
        {
            throw new NotImplementedException();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Blog()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
        public IActionResult KategoriTatli()
        {
            return View();
        }


        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
