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
    //[FiltroSeguridad]
    //[FiltroAdmin]
    public class ReservasController : Controller
    {
        ReservasModel modelo = new ReservasModel();
        HabitacionModel modelohabitaciones = new HabitacionModel();

        [HttpGet]
        public ActionResult MostrarReservas()
        {

            var respuesta = modelo.ConsultarReservas(true);

            if (respuesta.Codigo == 0)
                return View(respuesta.Datos);
            else
            {
                ViewBag.MsjPantalla = respuesta.Detalle;
                return View(new List<Reservas>());
            }
        }
        [HttpGet]
        public ActionResult RegistroReservas()
        {
            CargarViewBagHabitaciones();
            CargarViewBagUsuarios();
            return View();
        }
        [HttpPost]
        public ActionResult RegistroReservas(Reservas entidad)
        {
            var respuesta = modelo.RegistrarReservas(entidad);

            if (respuesta.Codigo == 0)
                return RedirectToAction("MostrarReservas", "Reservas");
            else
            {
                ViewBag.MsjPantalla = respuesta.Detalle;
                return View();
            }
        }

        [HttpGet]
        public ActionResult ActualizarReservas(long id)
        {
            var resp = modelo.ConsultarReserva(id);
            CargarViewBagHabitaciones();
            CargarViewBagUsuarios();
            resp.Dato.ID_reserva = id;
            return View(resp.Dato);
        }
        [HttpPost]
        public ActionResult ActualizarReservas(Reservas entidad)
        {
            var respuesta = modelo.ActualizarReservas(entidad);

            if (respuesta.Codigo == 0)
            {

                return RedirectToAction("MostrarReservas", "Reservas");
            }
            else
            {
                CargarViewBagHabitaciones();
                CargarViewBagUsuarios();
                ViewBag.MsjPantalla = respuesta.Detalle;
                return View();
            }
        }
        [HttpGet]
        public ActionResult EliminarReservas(long id)
        {
            var respuesta = modelo.EliminarReservas(id);

            if (respuesta.Codigo == 0)
            {

                return RedirectToAction("MostrarReservas", "Reservas");
            }
            else
            {
                ViewBag.MsjPantalla = respuesta.Detalle;
                return View();
            }
        }

        private void CargarViewBagUsuarios()
        {
            var respuesta = modelo.ConsultarUsuarios();
            var usuarios = new List<SelectListItem>();

           
            if (respuesta.Datos != null)
            {
                usuarios.Add(new SelectListItem { Text = "Seleccione un usuario", Value = "" });
                foreach (var item in respuesta.Datos)
                    usuarios.Add(new SelectListItem { Text = item.nombre, Value = item.id_usuario.ToString() });
            }
            else {
                usuarios.Add(new SelectListItem { Text = "No hay datos", Value = "" });
            }

            ViewBag.Usuarios = usuarios;
        }
        private void CargarViewBagHabitaciones()
        {
            var respuesta = modelohabitaciones.ConsultarHabitaciones(false);
            var habitaciones = new List<SelectListItem>();

            
            
            if (respuesta.Datos != null)
            {
                habitaciones.Add(new SelectListItem { Text = "Seleccione una habitacion", Value = "" });
                foreach (var item in respuesta.Datos)
                    habitaciones.Add(new SelectListItem { Text = item.tipo_habitacion, Value = item.ID_habitacion.ToString() });
            }
            else
            {
                habitaciones.Add(new SelectListItem { Text = "No hay datos", Value = "" });
            }
            ViewBag.Habitaciones = habitaciones;
        }


    }
}