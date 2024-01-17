using lista10.Data;
using lista10.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Xml;

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

        [HttpPost]
        public async Task<IActionResult> SaveTimetable(List<Lesson> timetable)
        {
            foreach (var lesson in timetable)
            {
                // Wykorzystaj metodę Create do obsługi pojedynczej lekcji
                var _lesson = new Lesson
                {
                    DayOfWeek = lesson.DayOfWeek,
                    Hour = lesson.Hour,
                    ClassId = lesson.ClassId,
                    TeacherName = lesson.TeacherName,
                    SubjectName = lesson.TeacherName,
                };
                _context.Lesson.Add(_lesson);


            }
            await _context.SaveChangesAsync();

            return View("SavedTimetableConfirmation", timetable);
        }


        [HttpPost]
        public IActionResult DisplayTimetable(string className)
        {
            var classSchedule = GetClassSchedule(className);
            return View(classSchedule);
        }

        private List<Lesson> GetClassSchedule(string className)
        {
            return _context.Lesson
                .Where(s => s.Class.ClassName == className)
                .ToList();
        }

        // GET: YourController/DeleteTimetable
        public IActionResult DeleteTimetable()
        {
            return View();
        }

        // POST: YourController/DeleteTimetable
        [HttpPost]
        public async Task<IActionResult> DeleteTimetable(string className)
        {
            if (className == null)
            {
                return NotFound();
            }

            var classToDelete = await _context.Class
                .FirstOrDefaultAsync(c => c.ClassName == className);

            if (classToDelete != null)
            {
                var lessonsToDelete = await _context.Lesson
                    .Where(l => l.Class.ClassId == classToDelete.ClassId)
                    .ToListAsync();

                _context.Lesson.RemoveRange(lessonsToDelete);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
