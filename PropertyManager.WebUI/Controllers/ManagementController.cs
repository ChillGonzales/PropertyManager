using PropertyManager.Domain.Abstract;
using PropertyManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PropertyManager.Domain.Abstract;
using PropertyManager.Domain.Entities;
using PropertyManager.Domain.Concrete;

namespace PropertyManager.WebUI.Controllers
{
    public class ManagementController : Controller
    {
<<<<<<< HEAD
        private IWaitList repository;

        public ManagementController(IWaitList repo)
        {
            this.repository = repo;
        }
=======
        private IUserRepository repository;

        public ManagementController(IUserRepository repo)
        {
            this.repository = repo;
        }

>>>>>>> origin/master
        // GET: Management
        public ActionResult Index()
        {
            return View();
        }

<<<<<<< HEAD
        public ActionResult CreateUser()
        {
            return View();
        }

        public ActionResult AddToWaitList(WaitListItem waiter)
        {
            if (waiter != null)
            {
                
            }
            return View();
        }

        public ViewResult ViewWaitList()
        {
            return View(repository.WaitList.OrderBy(x => x.SignUpTS));
        }

=======
        public ActionResult CreateUser(User user)
        {
            if (user != null)
            {
                                
            }
            return View();
        }
>>>>>>> origin/master
    }
}