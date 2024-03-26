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

        [HttpGet]
        public ActionResult RegistroFinalUHabitacion(long id)
        {
            Reservas entidad = new Reservas();
            entidad.ID_habitacion = id;
            ViewBag.Ms = id;
            return View(entidad);
        }
    }
}