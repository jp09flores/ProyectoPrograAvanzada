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
    [FiltroUsuario]
    public class UHabitacionesController : Controller
    {
        UHabitacionModel modelo = new UHabitacionModel();
        ReservasModel modeloReservas = new ReservasModel();
        HabitacionModel modelohabitaciones = new HabitacionModel();

        ErrorModel modeloError = new ErrorModel();

        [HttpGet]
        public ActionResult ConsultarUHabitaciones()
        {
            var respuesta = modelo.ConsultarHabitaciones(false);

            if (respuesta.Codigo == 0)
            {
                return View(respuesta.Datos);
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
            TimeSpan horaDeseadaEntrada = new TimeSpan(13, 0, 0);
            entidad.fecha_entrada += horaDeseadaEntrada;
            TimeSpan horaDeseadaSalida = new TimeSpan(11, 0, 0);
            entidad.fecha_salida += horaDeseadaSalida;
           
            var respuesta = modelo.ConsultarReservasUno(long.Parse(Session["idUsuario"].ToString()));

            if (respuesta.Codigo != 0)
            {
                entidad.id_usuario = long.Parse(Session["idUsuario"].ToString());
                var resp = modelo.RegistroFinalUHabitacion(entidad);
                if (resp.Codigo == 0)
                    return RedirectToAction("ConsultarReservaUsuario", "UHabitaciones");
                else
                {
                    Errores entidadError = new Errores();
                    entidadError.descripcion = resp.Detalle;
                    
                    modeloError.RegistrarError(entidadError);

                    ViewBag.MsjPantalla = resp.Detalle;
                    return View(entidad);

                }
            }
            else {
                Errores entidadError = new Errores();
                entidadError.descripcion = respuesta.Detalle;
                
                modeloError.RegistrarError(entidadError);

                ViewBag.MsjPantalla = "Ya tiene una reserva en el carrito";
                return View(entidad);
            }
            
        }
    
        [FiltroSeguridad]
        [HttpGet]
        public ActionResult Confirmacion()
        {
            return View();
        }
        [FiltroSeguridad]
        [HttpGet]
        public ActionResult ConsultarReservaUsuario()
        {
            var respuesta = modelo.ConsultarReservasUno(long.Parse(Session["idUsuario"].ToString()));

            if (respuesta.Codigo == 0)
            {
                return View(respuesta.Datos);
            }
            else
            {
                Errores entidadError = new Errores();
                entidadError.descripcion = respuesta.Detalle;
                
                modeloError.RegistrarError(entidadError);

                ViewBag.MsjPantalla = respuesta.Detalle;
                return View(new List<Reservas>());
            }
        }
        [FiltroSeguridad]
        [HttpGet]
        public ActionResult EnviarCorreo(long id)
        {

            Reservas entidad = new Reservas();
            var resp = modeloReservas.ConsultarReserva(id);

            entidad.ID_reserva= id;
            entidad.ID_habitacion = resp.Dato.ID_habitacion;
            entidad.fecha_entrada = resp.Dato.fecha_entrada;
            entidad.fecha_salida = resp.Dato.fecha_salida;
            entidad.servicios_adicionales = resp.Dato.servicios_adicionales;
            entidad.id_usuario = long.Parse(Session["idUsuario"].ToString());
            entidad.nombre_usuario = Session["NombreUsuario"].ToString();
            entidad.correo_usuario = Session["CorreoUsuario"].ToString();


            var respuesta = modelo.EnviarCorreo(entidad);

            if (respuesta.Codigo == 0) {
                var modifica = modeloReservas.EliminarReservas(id);
                if (modifica.Codigo == 0)
                {
                    return RedirectToAction("Confirmacion", "UHabitaciones");
                }
                else {
                    Errores entidadError = new Errores();
                    entidadError.descripcion = modifica.Detalle;
                   
                    modeloError.RegistrarError(entidadError);

                    ViewBag.MsjPantalla = respuesta.Detalle;
                    return View(entidad);
                }
               
            }
            else
            {
                Errores entidadError = new Errores();
                entidadError.descripcion = respuesta.Detalle;
                
                modeloError.RegistrarError(entidadError);

                ViewBag.MsjPantalla = resp.Detalle;
                return View(entidad);
            }
        }
        [HttpGet]
        public ActionResult ActualizarReservas(long id)
        {
            var resp = modeloReservas.ConsultarReserva(id);
            resp.Dato.ID_reserva = id;
            CargarViewBagHabitaciones();
            if (resp.Codigo == -1)
            {
                Errores entidadError = new Errores();
                entidadError.descripcion = resp.Detalle;
               
                modeloError.RegistrarError(entidadError);
            }
            return View(resp.Dato);
        }
        [FiltroSeguridad]
        [HttpGet]
        public ActionResult ConsultarReservaHistorial()
        {
            var respuesta = modelo.Historial(long.Parse(Session["idUsuario"].ToString()));

            if (respuesta.Codigo == 0)
            {
                return View(respuesta.Datos);
            }
            else
            {
                Errores entidadError = new Errores();
                entidadError.descripcion = respuesta.Detalle;
               
                modeloError.RegistrarError(entidadError);

                ViewBag.MsjPantalla = respuesta.Detalle;
                return View(new List<Reservas>());
            }
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