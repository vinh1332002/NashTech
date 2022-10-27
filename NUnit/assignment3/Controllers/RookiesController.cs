using Microsoft.AspNetCore.Mvc;
using assignment3.Models;
using assignment3.Services;

namespace assignment3.Controllers
{
    public class RookiesController : Controller
    {
        private readonly ILogger<RookiesController> _logger;
        private readonly IPersonService _personService;

        public RookiesController(ILogger<RookiesController> logger, IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }

        public IActionResult Index()
        {
            var models = _personService.GetAll();
            return View(models);
        }

        public IActionResult Details(int index)
        {
            var person = _personService.GetOne(index);
            if (person != null)
            {
                var model = new PersonModel
                {
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    Gender = person.Gender,
                    DateOfBirth = person.DateOfBirth,
                    PhoneNumber = person.PhoneNumber,
                    BirthPlace = person.BirthPlace,
                };
                ViewData["Index"] = index;
                return View(model);
            }
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PersonModel model)
        {
            if (ModelState.IsValid)
            {
                var person = new PersonModel
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Gender = model.Gender,
                    DateOfBirth = model.DateOfBirth,
                    PhoneNumber = model.PhoneNumber,
                    BirthPlace = model.BirthPlace,
                    IsGraduated = false
                };
                _personService.Create(person);

                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int index)
        {
            var person = _personService.GetOne(index);
            if (person != null)
            {
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
                var person = _personService.GetOne(index);
                if (person != null)
                {
                    person.FirstName = model.FirstName;
                    person.LastName = model.LastName;
                    person.PhoneNumber = model.PhoneNumber;
                    person.BirthPlace = model.BirthPlace;

                    _personService.Update(index, person);
                }

                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int index)
        {
            var result = _personService.Delete(index);
            if (result == null)
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteAndRedirected(int index)
        {
            var result = _personService.Delete(index);
            if (result == null) return NotFound();

            HttpContext.Session.SetString("DeletedPersonName", result.FullName);

            return RedirectToAction("DeleteResult");
        }

        public IActionResult DeleteResult()
        {
            return View();
        }
    }
}