using Microsoft.AspNetCore.Mvc;
using MVCProject.Models;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;

namespace MVCProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.DataBook = new DataBookContext().DataBook;
            return View();
        }

        [HttpGet]
        public IActionResult AddDataBook()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EditDataBook(int dataBookId)
        {
            var MyData = new DataBookContext();

            return View(MyData.DataBook.FirstOrDefault(d => d.Id == dataBookId));
        }

        [HttpPost]
        public IActionResult GetDataFromField(DataBook dataBook)
        {
            using (var db = new DataBookContext())
            {
                db.DataBook.Add(dataBook);
                db.SaveChanges();
            }
            return Redirect("~/");
        }

        [HttpGet]
        public IActionResult DeleteDataBook(int dataBookId)
        {
            var MyData = new DataBookContext();

            return View(MyData.DataBook.FirstOrDefault(d => d.Id == dataBookId));
        }

        [HttpPost]
        public IActionResult DeleteDataFromField(DataBook dataBook)
        {
            using (var db = new DataBookContext())
            {
                var dataBookToDelete = db.DataBook.FirstOrDefault(d => d.Id == dataBook.Id);
                if (dataBookToDelete != null)
                {
                    db.DataBook.Remove(dataBookToDelete);
                    db.SaveChanges();
                }                
            }
            return Redirect("~/");
        }

        [HttpPost]
        public IActionResult EditDataFromField(DataBook dataBook)
        {
            using (var db = new DataBookContext())
            {
                db.Entry(dataBook).State = EntityState.Modified;
                db.SaveChanges();
            }
            return Redirect("~/");
        }

        [HttpGet]
        public IActionResult GetDataBook(int dataBookId)
        {
            var MyData = new DataBookContext();

            return View(MyData.DataBook.FirstOrDefault(d => d.Id == dataBookId));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}