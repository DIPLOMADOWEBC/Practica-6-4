using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using P_6__1_Diplomado_MVC_UASD_Login.Models;

namespace Proyecto7_MVC_CRUD_DiplomadoUASD.Web.Controllers
{
    public class HomeController : Controller
    {
        SessionData session = new SessionData();

        public ActionResult Index()
        {
            return View();
            //return RedirectToAction("Login");
        }

        public ActionResult Login()
        {
            return View();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Usuario(Userlogin datos)
        {
            if (ModelState.IsValid)
            {
                if (datos.login() == true)
                {
                    session.setSession("userName", datos.Username);
                    FormsAuthentication.SetAuthCookie(datos.Username, true);
                    ViewBag.User = session.getSession("userName");
                    return RedirectToAction("Users", "User");
                }
                else
                {
                    ViewBag.Message = "Error";
                    return View("Index");
                }
            }
            else
            {
                return View("Index");
            }
        }
        [AllowAnonymous]
        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> SignIn(SignIn datos)
        {
            if (ModelState.IsValid)
            {
                if (datos.Signin() == false)
                {
                    ViewBag.Message = "El Usuario o Email Ya estan Registrado";
                    return View("SignIn", datos);
                }
                else
                {
                    return RedirectToAction("Login", "Home");
                }
            }
            else
            {
                return View("SignIn");
            }
        }

    }
}