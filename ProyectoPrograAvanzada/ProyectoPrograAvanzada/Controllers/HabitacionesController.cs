using ProyectoPrograAvanzada.Entidades;
using ProyectoPrograAvanzada.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace ProyectoPrograAvanzada.Controllers
{
    [FiltroSeguridad]
    [FiltroAdmin]
    public class HabitacionesController : Controller
    {
        HabitacionModel modelo = new HabitacionModel();

        [HttpGet]
        public ActionResult MostrarHabitaciones()
        {
            var respuesta = modelo.ConsultarHabitaciones(true);

            if (respuesta.Codigo == 0)
                return View(respuesta.Datos);
            else
            {
                ViewBag.MsjPantalla = respuesta.Detalle;
                return View(new List<Habitaciones>());
            }
        }
        [HttpGet]
        public ActionResult RegistroHabitaciones()
        {
            CargarViewBagLocalidad();
            return View();
        }
        [HttpPost]
        public ActionResult RegistroHabitaciones(Habitaciones entidad)
        {
            var respuesta = modelo.RegistrarHabitaciones(entidad);

            if (respuesta.Codigo == 0)
                return RedirectToAction("MostrarHabitaciones", "Habitaciones");
            else
            {
                ViewBag.MsjPantalla = respuesta.Detalle;
                return View();
            }
        }

        [HttpGet]
        public ActionResult ActualizarHabitaciones(long id)
        {
            var resp = modelo.ConsultarHabitacion(id);
            CargarViewBagLocalidad();
             resp.Dato.ID_habitacion =id;
            return View(resp.Dato);
        }


        [HttpPost]
        public ActionResult ActualizarHabitaciones(Habitaciones entidad)
        {
            var respuesta = modelo.ActualizarHabitaciones(entidad);

            if (respuesta.Codigo == 0)
            {
                
                return RedirectToAction("MostrarHabitaciones", "Habitaciones");
            }
            else
            {
                CargarViewBagLocalidad();
                ViewBag.MsjPantalla = respuesta.Detalle;
                return View();
            }
        }
        [HttpGet]
        public ActionResult EliminarHabitaciones(long id)
        {
            var respuesta = modelo.EliminarHabitaciones(id);

            if (respuesta.Codigo == 0)
            {
                return RedirectToAction("MostrarHabitaciones", "Habitaciones");
            }
            else
            {
                ViewBag.MsjPantalla = respuesta.Detalle;
                return View();
            }
        }
        private void CargarViewBagLocalidad()
        {
            var respuesta = modelo.ConsultarLocalidad();
            var localidad = new List<SelectListItem>();

            localidad.Add(new SelectListItem { Text = "Seleccione una categoría", Value = "" });
            foreach (var item in respuesta.Datos)
                localidad.Add(new SelectListItem { Text = item.nombre_localidad, Value = item.ID_Localidad.ToString() });

            ViewBag.Localidad = localidad;
        }



    }
}