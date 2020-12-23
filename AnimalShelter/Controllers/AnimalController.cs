using Microsoft.AspNetCore.Mvc;
using AnimalShelter.Models;
using System.Collections.Generic;
using System.Linq;

namespace AnimalShelter.Controllers
{
    public class AnimalController : Controller
    {
      private readonly AnimalShelterContext _db;

      public AnimalController(AnimalShelterContext db)
      {
        _db = db;
      }

      public ActionResult Index()
      {
        List<Animal> model = _db.Animal.ToList();
        return View(model);
      }

      public ActionResult Create()
      {
        return View();
      }

      [HttpPost]
      public ActionResult Create(Animal animal)
      {
        _db.Animal.Add(animal);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }

      /*public ActionResult Results(string searchTerm)
      {
        List<Animal> model = _db.Animal.ToList();
        // model.Search(searchTerm);
        List<Animal> finalList = new List<Animal> {};
        for (int i = 0; i < model.Count; i++)
        {
          if (model[i].Type == searchTerm)
          {
            finalList.Add(model[i]);
          }
        }
        return View(finalList);
      }*/

      public ActionResult Details(int id)
      {
        Animal thisAnimal = _db.Animal.FirstOrDefault(animals => animals.Id == id);
        return View(thisAnimal);
      }
    }
}