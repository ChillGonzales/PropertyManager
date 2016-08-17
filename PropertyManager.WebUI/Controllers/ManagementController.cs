using PropertyManager.Domain.Abstract;
using PropertyManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PropertyManager.Domain.Concrete;

namespace PropertyManager.WebUI.Controllers
{
    public class ManagementController : Controller
    {
        private IWaitList repository;

        public ManagementController(IWaitList repo)
        {
            this.repository = repo;
        }

        // GET: Management
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateUser()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddToWaitList()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddToWaitList(WaitListItem waiter)
        {
            if (waiter != null)
            {
                repository.Add(waiter);
            }
            return RedirectToAction("ViewWaitList", "Management");
        }

        public ActionResult ViewWaitList()
        {
            return View(repository.WaitList.OrderBy(x => x.SignUpTS));
        }

        public ActionResult CreateUser(User user)
        {
            if (user != null)
            {
                                
            }
            return View();
        }
    }
}