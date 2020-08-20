using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RTL_Bootstrap_Comprehensive_Test.DataAccess;
using RTL_Bootstrap_Comprehensive_Test.Models;
using RTL_Bootstrap_Comprehensive_Test.ViewModels;

namespace RTL_Bootstrap_Comprehensive_Test.Controllers
{
    public class PersonController : Controller
    {
        // GET: PersonController
        public ActionResult Index()
        {
            var personVMList = new List<PersonVM>();
            var personList = new PersonDA().GetPersons();
            foreach (var person in personList)
            {
                personVMList.Add(new PersonVM() { 
                    Id = person.Id, 
                    FirstName = person.FirstName, 
                    LastName=person.LastName,
                    EmailAddress=person.EmailAddress, 
                    CreatedOn=person.CreatedOn
                });
            }

            return View(personVMList);
        }

        // GET: PersonController/Details/5
        public ActionResult Details(int id)
        {
            var personModel = new PersonDA().GetPerson(id);
            if (personModel == null)
            {
                return RedirectToAction(nameof(Index));
            }
            PersonVM personVM = new PersonVM()
            {
                Id = personModel.Id,
                FirstName = personModel.FirstName,
                LastName = personModel.LastName,
                EmailAddress = personModel.EmailAddress,
                CreatedOn = personModel.CreatedOn
            };
            return View(personVM);
        }

        // GET: PersonController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] PersonVM submittedPerson)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var personModel = new PersonModel()
                    {
                        FirstName = submittedPerson.FirstName,
                        LastName = submittedPerson.LastName,
                        EmailAddress = submittedPerson.EmailAddress,
                    };
                    var res = new PersonDA().CreatePerson(personModel);
                    if (res == 1) //  means one row effected. which is created
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        return View();
                    }
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonController/Edit/5
        public ActionResult Edit(int id)
        {
            var personModel = new PersonDA().GetPerson(id);
            if (personModel == null)
            {
                return RedirectToAction(nameof(Index));
            }
            PersonVM personVM = new PersonVM()
            {
                Id = personModel.Id,
                FirstName = personModel.FirstName,
                LastName = personModel.LastName,
                EmailAddress = personModel.EmailAddress,
                CreatedOn = personModel.CreatedOn
            };
            return View(personVM);
        }

        // POST: PersonController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [FromForm] PersonVM submittedPerson)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var personModel = new PersonModel()
                    {
                        Id = id,
                        FirstName = submittedPerson.FirstName,
                        LastName = submittedPerson.LastName,
                        EmailAddress = submittedPerson.EmailAddress,
                    };
                    var res = new PersonDA().UpdatePerson(personModel);
                    if (res == 1) //  means one row effected. which is updated
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        return View();
                    }
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonController/Delete/5
        public ActionResult Delete(int id)
        {
            var personModel = new PersonDA().GetPerson(id);
            if (personModel == null)
            {
                return RedirectToAction(nameof(Index));
            }
            PersonVM personVM = new PersonVM()
            {
                Id = personModel.Id,
                FirstName = personModel.FirstName,
                LastName = personModel.LastName,
                EmailAddress = personModel.EmailAddress,
                CreatedOn = personModel.CreatedOn
            };
            return View(personVM);
        }

        // POST: PersonController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
