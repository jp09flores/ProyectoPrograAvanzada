using ProyectoPrograAvanzada.Entidades;
using ProyectoPrograAvanzada.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace ProyectoPrograAvanzada.Controllers
{
    [FiltroSeguridad]
    [FiltroAdmin]
    public class UsuariosController : Controller
    {
        UsuariosModel modelo = new UsuariosModel();

        [HttpGet]
        public ActionResult MostrarUsuarios()
        {
            var respuesta = modelo.ConsultarUsuarios();

            if (respuesta.Codigo == 0)
                return View(respuesta.Datos);
            else
            {
                ViewBag.MsjPantalla = respuesta.Detalle;
                return View(new List<Habitaciones>());
            }
        }
        [HttpGet]
        public ActionResult RegistroUsuarios()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegistroUsuarios(Usuarios entidad)
        {
            var respuesta = modelo.Registro(entidad);

            if (respuesta.Codigo == 0)
                return RedirectToAction("MostrarUsuarios", "Usuarios");
            else
            {
                ViewBag.MsjPantalla = respuesta.Detalle;
                return View();
            }
        }

        [HttpGet]
        public ActionResult ActualizarUsuarios(long id)
        {
            var resp = modelo.ConsultarUsuario(id);
            resp.Dato.id_usuario = id;
            return View(resp.Dato);
        }
        [HttpPost]
        public ActionResult ActualizarUsuarios(Usuarios entidad)
        {
            var respuesta = modelo.ActualizarUsuario(entidad);

            if (respuesta.Codigo == 0)
            {

                return RedirectToAction("MostrarUsuarios", "Usuarios");
            }
            else
            {
                
                ViewBag.MsjPantalla = respuesta.Detalle;
                return View();
            }
        }
        [HttpGet]
        public ActionResult EliminarUsuarios(long id)
        {
            var respuesta = modelo.EliminarUsuarios(id);

            if (respuesta.Codigo == 0)
            {
                return RedirectToAction("MostrarUsuarios", "Usuarios");
            }
            else
            {
                ViewBag.MsjPantalla = respuesta.Detalle;
                return View();
            }
        }




    }
}