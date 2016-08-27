using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PropertyManager.Domain.Entities;
using PropertyManager.Domain.Abstract;
using System.Threading.Tasks;
using PropertyManager.Domain.Helpers;
using CryptSharp;
using System.Text;

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

        //GET: CreateAccount
        public ActionResult CreateAccount()
        {
            return View();
        }

        //POST: CreateAccount
        public async Task<ActionResult> CreateAccount(User user, FormCollection form)
        {
            var saltyBytes = await DBHelpers.CreateNewSalt();
            user.PasswordSalt = Encoding.ASCII.GetString(saltyBytes);
            var pwdBytes = Encoding.ASCII.GetBytes(form["pwd"]);
            byte[] hashed = null;
            await Task.Run(new Func<byte[]>(() => {
                CryptSharp.Utility.SCrypt.ComputeKey(pwdBytes, saltyBytes, 262144, 8, 1, null, hashed);
                return hashed;
            }));
            return View();
        }

    }
}