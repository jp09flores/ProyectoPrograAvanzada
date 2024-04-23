using ProyectoPrograAvanzada.Entidades;
using ProyectoPrograAvanzada.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;

namespace ProyectoPrograAvanzada.Controllers
{
    [FiltroSeguridad]
    
    public class ReservasController : Controller
    {
        ReservasModel modelo = new ReservasModel();
        HabitacionModel modelohabitaciones = new HabitacionModel();
        ErrorModel modeloError = new ErrorModel();
        [FiltroAdmin]
        [HttpGet]
        public ActionResult MostrarReservas()
        {

            var respuesta = modelo.ConsultarReservas(true);

            if (respuesta.Codigo == 0)
                return View(respuesta.Datos);
            else
            {
                Errores entidadError = new Errores();
                entidadError.descripcion = respuesta.Detalle;
                
                modeloError.RegistrarError(entidadError);


                ViewBag.MsjPantalla = respuesta.Detalle;
                return View(new List<Reservas>());
            }
        }
        [FiltroAdmin]
        [HttpGet]
        public ActionResult RegistroReservas()
        {
            CargarViewBagHabitaciones();
            CargarViewBagUsuarios();
            return View();
        }
        [FiltroAdmin]
        [HttpPost]
        public ActionResult RegistroReservas(Reservas entidad)
        {
            TimeSpan horaDeseadaEntrada = new TimeSpan(13, 0, 0);
            entidad.fecha_entrada += horaDeseadaEntrada;
            TimeSpan horaDeseadaSalida = new TimeSpan(11, 0, 0);
            entidad.fecha_salida += horaDeseadaSalida;
            var respuesta = modelo.RegistrarReservas(entidad);

            if (respuesta.Codigo == 0)
                return RedirectToAction("MostrarReservas", "Reservas");
            else
            {
                Errores entidadError = new Errores();
                entidadError.descripcion = respuesta.Detalle;
                
                modeloError.RegistrarError(entidadError);

                CargarViewBagHabitaciones();
                CargarViewBagUsuarios();
                ViewBag.MsjPantalla = respuesta.Detalle;
                return View();
            }
        }
        [FiltroAdmin]
        [HttpGet]
        public ActionResult ActualizarReservas(long id)
        {
            var resp = modelo.ConsultarReserva(id);
            if (resp.Codigo == -1)
            {
                Errores entidadError = new Errores();
                entidadError.descripcion = resp.Detalle;
               
                modeloError.RegistrarError(entidadError);
            }
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
                Errores entidadError = new Errores();
                entidadError.descripcion = respuesta.Detalle;
           
                modeloError.RegistrarError(entidadError);

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
                Errores entidadError = new Errores();
                entidadError.descripcion = respuesta.Detalle;
             
                modeloError.RegistrarError(entidadError);

                ViewBag.MsjPantalla = respuesta.Detalle;
                return View();
            }
        }
        [HttpGet]
        public ActionResult EliminarReservasTotal(long id)
        {
            var respuesta = modelo.EliminarReservasTotal(id);

            if (respuesta.Codigo == 0)
            {

                return RedirectToAction("MostrarReservas", "Reservas");
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
                Errores entidadError = new Errores();
                entidadError.descripcion = respuesta.Detalle;

                modeloError.RegistrarError(entidadError);

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
                Errores entidadError = new Errores();
                entidadError.descripcion = respuesta.Detalle;

                modeloError.RegistrarError(entidadError);

                habitaciones.Add(new SelectListItem { Text = "No hay datos", Value = "" });
            }
            ViewBag.Habitaciones = habitaciones;
        }
       

    }
}