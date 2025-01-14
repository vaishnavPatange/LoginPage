using LoginPage.Models;
using Microsoft.AspNetCore.Mvc;

namespace LoginPage.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public List<UserModel> PutValue()
        {
            var user = new List<UserModel>
            {
                new UserModel{Id = 1, username = "Vaishnav", password = "1234"},
                new UserModel{Id = 2, username = "Samarth", password = "5678"},
                new UserModel{Id = 3, username = "Naresh", password = "91011"},
                new UserModel{Id = 4, username = "Kartik", password = "1213"}
            };
                
            return user;

        }

        [HttpPost]
        public IActionResult Verify(UserModel usr)
        {
            var u = PutValue();

            var us = u.Where( u => u.username.Equals(usr.username) );

            var up = u.Where( u => u.password.Equals(usr.password) );

            if(us.Count() == 1)
            {
                ViewBag.message = "Login success";
                return View("LoginSuccess");
            }
            else
            {
                ViewBag.message = "Login failed";
                return View("LoginFailed");
            }
        }
    }
}
