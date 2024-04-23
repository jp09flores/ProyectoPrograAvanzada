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
    public class UserController : Controller
    {
        UsuariosModel modelo = new UsuariosModel();
        ErrorModel modeloError = new ErrorModel();


        [HttpGet]
        public ActionResult ActualizarPerfil()
        {
            long idUsuario = long.Parse(Session["idUsuario"].ToString());
            var resp = modelo.ConsultarUsuario(idUsuario);
            if (resp.Codigo == 0)
            {
                return View(resp.Dato);



            }
            else {
                Errores entidadError = new Errores();
                entidadError.descripcion = resp.Detalle;

                modeloError.RegistrarError(entidadError);
                return View(new List<Usuarios>());
            } 
            

            
        }


        [HttpPost]
        public ActionResult ActualizarPerfil(Usuarios entidad)
        {
           entidad.id_usuario = long.Parse(Session["idUsuario"].ToString());
            entidad.ID_rol = long.Parse(Session["RolUsuario"].ToString());
            entidad.estado = true;

            long idUsuario = long.Parse(Session["idUsuario"].ToString());

            var respuesta = modelo.ActualizarUsuario(entidad);

            if (respuesta.Codigo == 0)
            {
                var resp = modelo.ConsultarUsuario(long.Parse(Session["idUsuario"].ToString()));
                Session["idUsuario"] = idUsuario;
                Session["NombreUsuario"] = resp.Dato.nombre;
                Session["RolUsuario"] = resp.Dato.ID_rol;
                Session["NombreRol"] = resp.Dato.nombre_rol;
                Session["CorreoUsuario"] = resp.Dato.correo_electronico;
                return RedirectToAction("PaginaPrincipal", "Inicio");
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
        public ActionResult CerrarSesion()
        {
            Session.Clear();
            return RedirectToAction("InicioSesion", "Inicio");
        }




    }
}