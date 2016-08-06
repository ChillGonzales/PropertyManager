using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PropertyManager.Domain.Abstract;
using PropertyManager.Domain.Entities;
using PropertyManager.WebUI.Controllers;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace PropertyManager.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Can_Paginate()
        {
            //Arrange
            Mock<IUserRepository> mock = new Mock<IUserRepository>();
            mock.Setup(m => m.Users).Returns(new User[]{
                new User{FirstName="Tootie", LastName="Frootie"},
                new User{FirstName="James", LastName="Washington"},
                new User{FirstName="George", LastName="Washington"},
                new User{FirstName="James", LastName="Monroe"},
                new User{FirstName="Abraham", LastName="Lincoln"},
                new User{FirstName="George", LastName="Bush"},
                new User{FirstName="Barack", LastName="Obama"}
            });
            UserController controller = new UserController(mock.Object);
            controller.PageSize = 3;

            //Act
            IEnumerable<User> result = (IEnumerable<User>)controller.List(2).Mode 1;

        }
    }
}
