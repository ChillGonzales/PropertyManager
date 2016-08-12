using PropertyManager.Domain.Abstract;
using PropertyManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PropertyManager.WebUI.Controllers
{
    public class ManagementController : Controller
    {
        private IUserRepository repository;

        public ManagementController(IUserRepository repo)
        {
            this.repository = repo;
        }

        // GET: Management
        public ActionResult Index()
        {
            return View();
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