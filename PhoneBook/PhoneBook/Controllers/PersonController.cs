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

        public EFContext EFContext { get; }

        public PersonController(EFContext eFContext)
        {
            EFContext = eFContext;
        }

        public IActionResult Index(EFContext context)
        {
            IEnumerable<Person> people = context.People.ToList();
            return View(people);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Person person, [FromServices] EFContext context)
        {
            if (ModelState.IsValid)
            {
                person.Created = DateTime.Now;
                context.People.Add(person);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "Model is not valid!";
                return View(person);
            }

        }

        [HttpGet]
        public IActionResult Edit(int id, [FromServices] EFContext context)

        {
            var person = context.People.Single(x => x.ID == id);
            context.SaveChanges();
            return View(person);

        }


        [HttpPost]
        public IActionResult Edit(Person person, [FromServices] EFContext context)

        {
            if (ModelState.IsValid)
            {
                person.Updated = DateTime.Now;
                context.Update(person);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(person);
        }

        [HttpGet]
        public IActionResult Remove(int id, [FromServices] EFContext context)
        {
            var person = context.People.Single(x => x.ID == id);
            context.SaveChanges();
            return View(person);
        }

        [HttpPost]
        public IActionResult ConfirmRemove(int id, [FromServices] EFContext context)
        {
            var person = context.People.Single(x => x.ID == id);
            context.Remove(person);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Result(string query, [FromServices] EFContext context)
        {
            if (!String.IsNullOrWhiteSpace(query))
            {
                IEnumerable<Person> people = context.People.Where(x => x.Firstname.Contains(query) ||
               x.Lastname.Contains(query) || x.Phone.Contains(query)).ToList();
                return View(people);
            }

            ViewBag.Message = "No results found.";
            return View();
        }

    }
}
