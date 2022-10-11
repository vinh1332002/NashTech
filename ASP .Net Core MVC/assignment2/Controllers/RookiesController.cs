using Microsoft.AspNetCore.Mvc;
using assignment2.Models;
using System.Text.Json;

namespace assignment2.Controllers
{
    //[Route("[controller]")]
    public class RookiesController : Controller
    {
        private readonly ILogger<RookiesController> _logger;

        public RookiesController(ILogger<RookiesController> logger)
        {
            _logger = logger;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }

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

        public IActionResult Index()
        {
            return View(_person);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PersonCreateModel model)
        {
            if (ModelState.IsValid)
            {
                var person = new PersonModel
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Gender = model.Gender,
                    DateOfBirth = model.DateOfBirth,
                    BirthPlace = model.BirthPlace,
                    PhoneNumber = model.PhoneNumber,
                    IsGraduated = false
                };
                _person.Add(person);

                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int index)
        {
            if (index >= 0 && index < _person.Count)
            {
                var person = _person[index];
                var model = new PersonEditModel
                {
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    PhoneNumber = person.PhoneNumber,
                    BirthPlace = person.BirthPlace,
                };
                ViewData["Index"] = index;
                return View(model);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Update(int index, PersonEditModel model)
        {
            if (ModelState.IsValid)
            {
                if (index >= 0 && index < _person.Count)
                {
                    var person = _person[index];
                    person.FirstName = model.FirstName;
                    person.LastName = model.LastName;
                    person.PhoneNumber = model.PhoneNumber;
                    person.BirthPlace = model.BirthPlace;

                    _person[index] = person;
                }
                Console.WriteLine("Index=" + index);

                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int index)
        {
            if (index >= 0 && index < _person.Count)
            {
                _person.RemoveAt(index);
            }
            return RedirectToAction("Index");
        }
    }
}