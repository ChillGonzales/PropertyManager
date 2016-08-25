using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PropertyManager.Domain.Entities;
using PropertyManager.Domain.Abstract;

namespace PropertyManager.WebUI.Controllers
{
    public class ResidentController : Controller
    {
        private IUserRepository repositoryUsers;
        private IWaitList repositoryWaitList;

        public ResidentController(IUserRepository userRepository, IWaitList repoWaitList)
        {
            this.repositoryUsers = userRepository;
            this.repositoryWaitList = repoWaitList;
        }
        
        // GET: Index
        public ActionResult Index()
        {
            return View();
        }

    }
}