using lista10.Data;
using lista10.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lista10.Controllers
{
    public class ScheduleManagerController : Controller
    {
        private readonly MyDbContext _context;


        public ScheduleManagerController(MyDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
           
            return View();
        }

        [HttpPost]
        public IActionResult GenerateTimetable(string className)
        {
            Class givenClass = _context.Class.FirstOrDefault(c => c.ClassName == className);

            var timetableGenerator = new TimetableGenerator();
            var timetable = timetableGenerator.GenerateTimetable(givenClass, _context);
            ViewBag.ClassName = className; 
            ViewBag.Timetable = timetable;   

            return View("Timetable", timetable);
        }

        private List<SelectListItem> GetAvailableClasses()
        {
            // Pobierz listę klas z bazy danych
            var classes = _context.Class.Select(c => new SelectListItem
            {
                Value = c.ClassId.ToString(),
                Text = c.ClassName
            }).ToList();

            return classes;
        }

    }
}
