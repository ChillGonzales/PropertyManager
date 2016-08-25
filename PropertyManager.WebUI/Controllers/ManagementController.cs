using PropertyManager.Domain.Abstract;
using PropertyManager.Domain.Entities;
using PropertyManager.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PropertyManager.Domain.Concrete;
using System.Threading.Tasks;

namespace PropertyManager.WebUI.Controllers
{
    public class ManagementController : Controller
    {
        private IWaitList repositoryWaitList;
        private IPreUserRepository repositoryUsers;

        public ManagementController(IWaitList repo, IPreUserRepository preUserRepo)
        {
            this.repositoryWaitList = repo;
            this.repositoryUsers = preUserRepo;
        }

        // GET: Management
        public ActionResult Index()
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
                repositoryWaitList.Add(waiter);
            }
            return RedirectToAction("ViewWaitList", "Management");
        }

        public ActionResult ViewWaitList()
        {
            return View(repositoryWaitList.WaitList.OrderBy(x => x.SignUpTS));
        }

        [HttpGet]
        public ActionResult AddAUser()
        {
            return View();
        }

        public async Task<ActionResult> AddAUser(PreUser user)
        {
            if (user != null)
            {
                var val = await DBHelpers.CheckUser(repositoryUsers, user);
                if (val == Domain.ResponseCode.Success) { repositoryUsers.Add(user); }
                else { ViewBag.ResponseCode = val; }
                return View();
            }
            return RedirectToAction("ViewUsers","Management");
        }

        public ActionResult ViewUsers()
        {
            return View(repositoryUsers.PreUsers.OrderBy(x => x.AccountCreationTS));
        }
    }
}