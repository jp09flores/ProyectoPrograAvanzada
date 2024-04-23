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
    [FiltroUsuario]
    public class OpinionesController : Controller
    {
        OpinionesModel modelo = new OpinionesModel();
        UHabitacionModel modeloU = new UHabitacionModel();
        ErrorModel modeloError = new ErrorModel();

        [HttpGet]
        public ActionResult MostrarOpiniones()
        {
            var respuesta = modelo.MostrarOpiniones();

            if (respuesta.Codigo == 0)
                return View(respuesta.Datos);
            else
            {
                Errores entidadError = new Errores();
                entidadError.descripcion = respuesta.Detalle;

                modeloError.RegistrarError(entidadError);

                ViewBag.MsjPantalla = respuesta.Detalle;
                return View(new List<Opiniones>());
            }
        }
        [HttpGet]
        public ActionResult RegistrarOpiniones()
        {
            CargarViewBagOpiniones();
            return View();
        }
        [HttpPost]
        public ActionResult RegistrarOpiniones(Opiniones entidad)
        {
            entidad.id_usuario = long.Parse(Session["idUsuario"].ToString());
            var respuesta = modelo.Registro(entidad);

            if (respuesta.Codigo == 0)
                return RedirectToAction("MostrarOpiniones", "Opiniones");
            else
            {
                Errores entidadError = new Errores();
                entidadError.descripcion = respuesta.Detalle;

                modeloError.RegistrarError(entidadError);

                ViewBag.MsjPantalla = respuesta.Detalle;
                return View();
            }
        }
        private void CargarViewBagOpiniones()
        {
            var respuesta = modeloU.Historial(long.Parse(Session["idUsuario"].ToString()));
            var Reserva = new List<SelectListItem>();

            if (respuesta.Datos != null)
            {
                Reserva.Add(new SelectListItem { Text = "Seleccione una Reserva", Value = "" });
                foreach (var item in respuesta.Datos)
                    Reserva.Add(new SelectListItem { Text = item.ID_reserva.ToString(), Value = item.ID_reserva.ToString() });
            }
            else
            {
                Errores entidadError = new Errores();
                entidadError.descripcion = respuesta.Detalle;

                modeloError.RegistrarError(entidadError);

                Reserva.Add(new SelectListItem { Text = "No hay datos", Value = "" });
            }
            ViewBag.Reserva = Reserva;
        }
    }
}