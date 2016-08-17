using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PropertyManager.Domain.Entities;
using PropertyManager.Domain.Abstract;

namespace PropertyManager.WebUI.Controllers
{
    public class UserController : Controller
    {
        private IUserRepository repository;
        public int PageSize = 4;

        public UserController(IUserRepository userRepository)
        {
            this.repository = userRepository;
        }
        
        // GET: User
        public ActionResult List(int page = 1)
        {
            return View(repository.Users
                .OrderBy(p => p.ID)
                .Skip((page - 1) * PageSize)
                .Take(PageSize));
        }

    }
}