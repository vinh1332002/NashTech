using assignment3.Controllers;
using assignment3.Models;
using assignment3.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace RookiesControllerTests;

public class Tests
{
    //No test for IAction update in nunit test
    //Test only able to run separately
    private Mock<ILogger<RookiesController>> _loggerMock;

    private Mock<IPersonService> _personService;

    static List<PersonModel> _people = new List<PersonModel>(){
        new PersonModel{
                FirstName = "Vinh",
                LastName = "Nguyen",
                Gender = "Male",
                DateOfBirth = new DateTime(2002, 3, 13),
                PhoneNumber = "0888888888",
                BirthPlace = "Ha noi",
                IsGraduated = false
            },
            new PersonModel{
                FirstName = "Duc",
                LastName = "Bui",
                Gender = "Male",
                DateOfBirth = new DateTime(2001, 3, 28),
                PhoneNumber = "0888888888",
                BirthPlace = "Thai Binh",
                IsGraduated = false
            },
            new PersonModel{
                FirstName = "Khong",
                LastName = "Tu",
                Gender = "Female",
                DateOfBirth = new DateTime(2000, 6, 12),
                PhoneNumber = "0811111188",
                BirthPlace = "Lang Son",
                IsGraduated = true
            },
    };

    [SetUp]
    public void Setup()
    {
        _personService = new Mock<IPersonService>();
        _loggerMock = new Mock<ILogger<RookiesController>>();
    }

    [Test]
    public void Index_ReturnViewResult_GetAllList()
    {
        _personService.Setup(p => p.GetAll()).Returns(_people);

        var controller = new RookiesController(_loggerMock.Object, _personService.Object);

        var result = controller.Index();

        var view = result as ViewResult;

        Assert.IsInstanceOf<ViewResult>(result, "Action must return a ViewResult");
        Assert.IsNotNull(result, "Action must return a ViewResult");

        var model = view?.ViewData.Model as List<PersonModel>;

        Assert.IsAssignableFrom<List<PersonModel>>(model, "Action must return a person model list");
        Assert.AreEqual(3, model?.Count, "Action must return a list of 2 people");
    }

    [Test]
    public void Details_ReturnsViewResult_GetOnePerson()
    {
        int index = 1;
        _personService.Setup(p => p.GetOne(index)).Returns(_people[1]);

        var controller = new RookiesController(_loggerMock.Object, _personService.Object);

        var result = controller.Details(1);

        var view = result as ViewResult;

        Assert.IsInstanceOf<ViewResult>(result, "Details must return a ViewResult");
        Assert.IsNotNull(result, "Details must return a ViewResult");

        var model = view?.ViewData.Model as PersonModel;

        Assert.IsAssignableFrom<PersonModel>(model, "Details must return a person model");
        Assert.AreEqual("Duc", model?.FirstName, "Details must return a person with index = 1 (second person)");
    }

    [Test]
    public void Create_ReturnsViewResult_CreateOnePerson()
    {
        PersonModel per = new PersonModel
        {
            FirstName = "Vu",
            LastName = "Ly",
            Gender = "Male",
            DateOfBirth = new DateTime(2000, 3, 28),
            PhoneNumber = "0223455489",
            BirthPlace = "Hanoi",
            IsGraduated = false
        };
        _personService.Setup(p => p.Create(per)).Callback<PersonModel>((PersonModel per) => _people.Add(per));

        var expected = _people.Count + 1;
        var controller = new RookiesController(_loggerMock.Object, _personService.Object);

        var result = controller.Create(per);
        var actual = _people.Count;

        Assert.IsInstanceOf<RedirectToActionResult>(result, "Add must return a RedirectToActionResult");
        Assert.IsNotNull(result, "Add must return a RedirectToActionResult");

        var view = result as RedirectToActionResult;

        Assert.AreEqual("Index", view?.ActionName, "Add must return a RedirectToActionResult to Index");
    }

    [Test]
    public void Delete_ReturnsViewResult_DeleteOnePerson()
    {
        int index = 2;
        _personService.Setup(p => p.Delete(index)).Callback(() =>
        {
            _people.Remove(_people[2]);
        }).Returns(_people[2]);

        var controller = new RookiesController(_loggerMock.Object, _personService.Object);
        var expected = _people.Count - 1;

        var result = controller.Delete(2);
        var actual = _people.Count;

        Assert.IsInstanceOf<RedirectToActionResult>(result, "Delete must return a RedirectToActionResult");
        Assert.IsNotNull(result, "Delete must return a RedirectToActionResult");
        Assert.AreEqual(expected, actual, "Delete must delete a person");
    }
}