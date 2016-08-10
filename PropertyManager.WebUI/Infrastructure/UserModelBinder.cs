using PropertyManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PropertyManager.WebUI.Infrastructure
{
    public class UserModelBinder : IModelBinder
    {
        private const string sessionKey = "User";

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            // Get the user from the session
            User user = null;
            if (controllerContext.HttpContext.Session != null)
            {
                user = (User)controllerContext.HttpContext.Session[sessionKey];
            }

            return user;
        }
    }
}