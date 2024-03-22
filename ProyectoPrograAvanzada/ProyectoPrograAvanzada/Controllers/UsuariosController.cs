using ProyectoPrograAvanzada.Entidades;
using ProyectoPrograAvanzada.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoPrograAvanzada.Controllers
{
    //[FiltroSeguridad]
    //[FiltroAdmin]
    public class UsuariosController : Controller
    {
        UsuariosModel model = new UsuariosModel();

        [HttpGet]
        public ActionResult MostrarUsuarios()
        {
            return View();
        }
        [HttpGet]
        public ActionResult RegistroUsuarios()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegistroUsuarios(Usuarios entidad)
        {
            return View();
        }

        [HttpGet]
        public ActionResult ActualizarUsuarios()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ActualizarUsuarios(Usuarios entidad)
        {
            return View();
        }
        [HttpPost]
        public ActionResult EliminarUsuarios()
        {
            return View();
        }




    }
}