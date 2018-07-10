using OtoTamir.Portal.CustomFilter;
using OtoTamir.Repository.Infrastructure;
using OtoTamir.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OtoTamir.Portal.Controllers
{
    public class AccountController : Controller
    {
       
        private IUserRepository _userRepository;

        public AccountController()
        {
            this._userRepository = new UserRepository(new Data.OtoTamirDBEntities());
        }

        public AccountController(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }
   
        
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string Email, string Password)
        {
            var User = _userRepository.IsHave(Email, Password);
            if (User != null)
            {
                if (User.Rol.Name == "Admin")
                {
                    Session["KullaniciAdi"] = User.AdSoyad;
                    return RedirectToAction("Index", "Home");
                }
                ViewBag.Mesaj = "Yetkisiz admin";
                return View();
            }
            ViewBag.Mesaj = "Admin bulunamadı";
            return View();
        }
    }
}