﻿using ProyectoPrograAvanzada.Entidades;
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
        ReservasModel modeloReservas = new ReservasModel();
        HabitacionModel modelohabitaciones = new HabitacionModel();

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



            var resp = modelo.RegistroFinalUHabitacion(entidad);

            if (resp.Codigo == 0)
                return RedirectToAction("ConsultarReservaUsuario", "UHabitaciones");
            else
            {
                ViewBag.MsjPantalla = resp.Detalle;
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
                    ViewBag.MsjPantalla = respuesta.Detalle;
                    return View(entidad);
                }
               
            }
            else
            {
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
            return View(resp.Dato);
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