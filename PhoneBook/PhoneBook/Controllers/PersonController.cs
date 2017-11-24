using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Models;
using PhoneBook.Context;

namespace PhoneBook.Controllers
{
    public class PersonController : Controller
    {

        protected EFContext EFContext { get; }

        public PersonController(EFContext eFContext)
        {
            EFContext = eFContext;
        }

        public IActionResult Index()
        {
            IEnumerable<Person> people = EFContext.People.ToList();
            return View(people);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Person person)
        {
            if (ModelState.IsValid)
            {
                person.Created = DateTime.Now;
                EFContext.People.Add(person);
                EFContext.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "Model is not valid!";
                return View(person);
            }

        }

        [HttpGet]
        public IActionResult Edit(int id)

        {
            var person = EFContext.People.Single(x => x.ID == id);
            return View(person);

        }


        [HttpPost]
        public IActionResult Edit(Person person)

        {
            if (ModelState.IsValid)
            {
                person.Updated = DateTime.Now;
                EFContext.People.Update(person);
                EFContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(person);
        }

        [HttpGet]
        public IActionResult Remove(int id)
        {
            var person = EFContext.People.Single(x => x.ID == id);
            return View(person);
        }

        [HttpPost]
        public IActionResult ConfirmRemove(int id)
        {
            var person = EFContext.People.Single(x => x.ID == id);
            EFContext.Remove(person);
            EFContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Result(string query)
        {
            if (!String.IsNullOrWhiteSpace(query))
            {
                IEnumerable<Person> people = EFContext.People.Where(x => x.Firstname.Contains(query) ||
               x.Lastname.Contains(query) || x.Phone.Contains(query)).ToList();
                return View("Index",people);
            }

            
            return View("Index");
        }

    }
}
