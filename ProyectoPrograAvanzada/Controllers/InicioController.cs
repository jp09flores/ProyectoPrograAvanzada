using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practica1.Controllers
{
    public class InicioController : Controller
    {
        // GET: Inicio

        public ActionResult InicioSesion()
        {
            return View();
        }
        public ActionResult PaginaPrincipal()
        {
            return View();
        }
        public ActionResult Registro()
        {
            return View();
        }

    }
}