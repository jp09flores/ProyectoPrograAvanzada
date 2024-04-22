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
    public class UHabitacionesController : Controller
    {
        UHabitacionModel modelo = new UHabitacionModel();

        [HttpGet]
        public ActionResult ConsultarUHabitaciones()
        {
            var respuesta = modelo.ConsultarHabitaciones(true);

            if (respuesta.Codigo == 0)
            {
                return View(respuesta.Datos);
            }
            else
            {
                ViewBag.MsjPantalla = respuesta.Detalle;
                return View();
            }
        }

        [FiltroSeguridad]
        [HttpGet]
        public ActionResult RegistroFinalUHabitacion(long id)
        {
            Reservas entidad = new Reservas();
            entidad.ID_habitacion = id;
            ViewBag.Ms = id;
            return View(entidad);
        }

        [FiltroSeguridad]
        [HttpPost]
        public ActionResult RegistroFinalUHabitacion(Reservas entidad)
        {
            entidad.id_usuario = long.Parse(Session["idUsuario"].ToString());
            entidad.nombre_usuario = Session["NombreUsuario"].ToString();
            entidad.correo_usuario = Session["CorreoUsuario"].ToString();

            var respuesta = modelo.ConsultarUltimo();
            entidad.ID_reserva = respuesta.Dato.ID_reserva + 1;

            var resp = modelo.RegistroFinalUHabitacion(entidad);

            if (resp.Codigo == 0)
                return RedirectToAction("Confirmacion", "UHabitaciones");
            else
            {
                ViewBag.MsjPantalla = resp.Detalle;
                return View(entidad);
            }
        }

        [HttpGet]
        public ActionResult Confirmacion()
        {
            return View();
        }
    }
}