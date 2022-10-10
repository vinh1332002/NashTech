using Microsoft.AspNetCore.Mvc;
using assignment1.Models;
using System.Globalization;
using CsvHelper;

namespace assignment1.Controllers
{
    public class RookiesController : Controller
    {
        private static List<PersonModel> _person = new List<PersonModel>
        {
            new PersonModel()
            {
                FirstName = "Vinh",
                LastName = "Nguyen",
                Gender = "Male",
                DateOfBirth = new DateTime(2002, 3, 13),
                PhoneNumber = "0964083300",
                BirthPlace = "Ha Noi",
                IsGraduated = false
            },
            new PersonModel()
            {
                FirstName = "Duc",
                LastName = "Bui",
                Gender = "Female",
                DateOfBirth = new DateTime(2002, 9, 30),
                PhoneNumber = "0985483300",
                BirthPlace = "ha noi",
                IsGraduated = false
            },
            new PersonModel()
            {
                FirstName = "Ngai",
                LastName = "Nguyen",
                Gender = "Male",
                DateOfBirth = new DateTime(1999, 5, 30),
                PhoneNumber = "0875463300",
                BirthPlace = "Thai Binh",
                IsGraduated = true
            },
            new PersonModel()
            {
                FirstName = "Chuoi",
                LastName = "Le",
                Gender = "Female",
                DateOfBirth = new DateTime(2001, 4, 24),
                PhoneNumber = "0185683001",
                BirthPlace = "Quang Ngai",
                IsGraduated = true
            },
            new PersonModel()
            {
                FirstName = "Than",
                LastName = "Dang",
                Gender = "Female",
                DateOfBirth = new DateTime(2000, 10, 10),
                PhoneNumber = "0285483780",
                BirthPlace = "Thai Nguyen",
                IsGraduated = true
            }
        };

        [Route("/NashTech/Rookies/GetList")]

        public IActionResult GetList()
        {
            return Json(_person);
        }

        [Route("/NashTech/Rookies/GetListMale")]

        public IActionResult GetListMale()
        {
            var maleStudent = _person.Where(s => s.Gender == "Male");

            return Json(maleStudent);
        }

        [Route("/NashTech/Rookies/GetOldestStudent")]

        public IActionResult GetOldestStudent()
        {
            var maxAge = _person.Max(p => p.Age);
            var data = _person.FirstOrDefault(p => p.Age == maxAge);

            return Json(data);
        }

        [Route("/NashTech/Rookies/GetStudentFullName")]

        public IActionResult GetStudentFullName()
        {
            var listFullName = from person in _person select person.FullName;

            return Json(listFullName);
        }

        #region 1

        public IActionResult GetStudentByDateOfBirth(int year, string compareType)
        {
            switch (compareType)
            {
                case "equals":
                    return Json(_person.Where(p => p.DateOfBirth.Year == year));
                case "greater":
                    return Json(_person.Where(p => p.DateOfBirth.Year > year));
                case "less":
                    return Json(_person.Where(p => p.DateOfBirth.Year < year));
                default:
                    return Json(null);
            }
        }

        [Route("/NashTech/Rookies/GetStudentBornIn2000")]

        public IActionResult GetStudentBornIn2000()
        {
            return RedirectToAction("GetStudentByDateOfBirth", new { year = 2000, compareType = "equals" });
        }

        [Route("/NashTech/Rookies/GetStudentBornAfter2000")]

        public IActionResult GetStudentBornAfter2000()
        {
            return RedirectToAction("GetStudentByDateOfBirth", new { year = 2000, compareType = "greater" });
        }

        [Route("/NashTech/Rookies/GetStudentBornBefore2000")]

        public IActionResult GetStudentBornBefore2000()
        {
            return RedirectToAction("GetStudentByDateOfBirth", new { year = 2000, compareType = "less" });
        }

        #endregion

        #region 2

        [Route("/NashTech/Rookies/ExportData")]

        public FileStreamResult ExportData()
        {
            var result = WriteCsvToMemory(_person);
            var memoryStream = new MemoryStream(result);

            return new FileStreamResult(memoryStream, "text/csv") { FileDownloadName = "export.csv" };
        }

        public byte[] WriteCsvToMemory(IEnumerable<PersonModel> records)
        {
            using (var memoryStream = new MemoryStream())
            using (var streamWriter = new StreamWriter(memoryStream))
            using (var csvWriter = new CsvWriter(streamWriter, CultureInfo.CurrentCulture))
            {
                csvWriter.WriteRecords(records);
                streamWriter.Flush();

                return memoryStream.ToArray();
            }
        }

        #endregion
    }
}