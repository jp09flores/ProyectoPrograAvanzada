using ProyectoPrograAvanzada.Entidades;
using ProyectoPrograAvanzada.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;
using static System.Collections.Specialized.BitVector32;

namespace ProyectoPrograAvanzada.Controllers
{
    [FiltroSeguridad]
    [FiltroAdmin]
    public class UsuariosController : Controller
    {
        UsuariosModel modelo = new UsuariosModel();
        ErrorModel modeloError = new ErrorModel();
        

        [HttpGet]
        public ActionResult MostrarUsuarios()
        {

            var respuesta = modelo.ConsultarUsuarios();

            if (respuesta.Codigo == 0)
                return View(respuesta.Datos);
            else
            {
                Errores entidadError = new Errores();
                entidadError.descripcion = respuesta.Detalle;
               
                modeloError.RegistrarError(entidadError);
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
                Errores entidadError= new Errores();
                entidadError.descripcion = respuesta.Detalle;
               
                modeloError.RegistrarError(entidadError);
                ViewBag.MsjPantalla = respuesta.Detalle;
                return View();
            }
        }

        [HttpGet]
        public ActionResult ActualizarUsuarios(long id)
        {
            var resp = modelo.ConsultarUsuario(id);
            resp.Dato.id_usuario = id;
            if (resp.Codigo == -1) {
                Errores entidadError = new Errores();
                entidadError.descripcion = resp.Detalle;
           
                modeloError.RegistrarError(entidadError);
            }
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
                Errores entidadError = new Errores();
                entidadError.descripcion = respuesta.Detalle;
                
                modeloError.RegistrarError(entidadError);
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
                Errores entidadError = new Errores();
                entidadError.descripcion = respuesta.Detalle;
         
                modeloError.RegistrarError(entidadError);
                ViewBag.MsjPantalla = respuesta.Detalle;
                return View();
            }
        }




    }
}