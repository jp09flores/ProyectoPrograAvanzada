using ProyectoPrograAvanzada.Entidades;
using ProyectoPrograAvanzada.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Practica1.Controllers
{
    public class InicioController : Controller
    {
        UsuariosModel modelo = new UsuariosModel();
        // GET: Inicio

        [HttpGet]
        public ActionResult InicioSesion()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InicioSesion(Usuarios entidad)
        {
            var respuesta = modelo.InicioSesion(entidad);

            if (respuesta.Codigo == 0) { 
                Session["NombreUsuario"] = respuesta.Dato.nombre;
                Session["RolUsuario"] = respuesta.Dato.ID_rol;
                Session["NombreRol"] = respuesta.Dato.nombre_rol;

               
                return RedirectToAction("PaginaPrincipal", "Inicio");
            }
            else
            {
                ViewBag.MsjPantalla = respuesta.Detalle;
                return View();
            }
        }
        [FiltroSeguridad]
        public ActionResult PaginaPrincipal()
        {
            
            return View();
        }


        [HttpGet]
        public ActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registro(Usuarios entidad)
        {
            var respuesta = modelo.Registro(entidad);

            if (respuesta.Codigo == 0)
                return RedirectToAction("InicioSesion", "Inicio");
            else
            {
                ViewBag.MsjPantalla = respuesta.Detalle;
                return View();
            }

        }

    }
}