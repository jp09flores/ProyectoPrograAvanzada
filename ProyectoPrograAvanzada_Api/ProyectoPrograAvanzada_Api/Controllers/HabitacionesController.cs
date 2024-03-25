using ProyectoPrograAvanzada_Api.Entidades;
using ProyectoPrograAvanzada_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProyectoPrograAvanzada_Api.Controllers
{
    public class HabitacionesController : ApiController
    {
        [HttpGet]
        [Route("Habitaciones/ConsultarHabitaciones")]
        public ConfirmacionHabitaciones ConsultarHabitaciones(bool MostrarTodos)
        {
            var respuesta = new ConfirmacionHabitaciones();

            try
            {
                using (var db = new ProyPrograAvanEntities())
                {
                    var datos = db.ConsultarHabitaciones(MostrarTodos).ToList();

                    if (datos.Count > 0)
                    {
                        respuesta.Codigo = 0;
                        respuesta.Detalle = string.Empty;
                        respuesta.Datos = datos;
                    }
                    else
                    {
                        respuesta.Codigo = -1;
                        respuesta.Detalle = "No se encontraron resultados";
                    }
                }
            }
            catch (Exception)
            {
                respuesta.Codigo = -1;
                respuesta.Detalle = "Se presentó un error en el sistema";
            }

            return respuesta;
        }
        [HttpGet]
        [Route("Habitaciones/ConsultarLocalidad")]
        public ConfirmacionLocalidad ConsultarLocalidad()
        {
            var respuesta = new ConfirmacionLocalidad();

            try
            {
                using (var db = new ProyPrograAvanEntities())
                {
                    var datos = db.ConsultarLocalidad().ToList();

                    if (datos.Count > 0)
                    {
                        respuesta.Codigo = 0;
                        respuesta.Detalle = string.Empty;
                        respuesta.Datos = datos;
                    }
                    else
                    {
                        respuesta.Codigo = -1;
                        respuesta.Detalle = "No se encontraron resultados";
                    }
                }
            }
            catch (Exception)
            {
                respuesta.Codigo = -1;
                respuesta.Detalle = "Se presentó un error en el sistema";
            }

            return respuesta;
        }

        [HttpGet]
        [Route("Habitaciones/ConsultarHabitacion")]
        public ConfirmacionHabitaciones ConsultarHabitacion(long Consecutivo)
        {
            var respuesta = new ConfirmacionHabitaciones();

            try
            {
                using (var db = new ProyPrograAvanEntities())
                {
                    var datos = db.ConsultarHabitacion(Consecutivo).FirstOrDefault();

                    if (datos != null)
                    {
                        respuesta.Codigo = 0;
                        respuesta.Detalle = string.Empty;
                        respuesta.Dato = datos;
                    }
                    else
                    {
                        respuesta.Codigo = -1;
                        respuesta.Detalle = "No se encontraron resultados";
                    }
                }
            }
            catch (Exception)
            {
                respuesta.Codigo = -1;
                respuesta.Detalle = "Se presentó un error en el sistema";
            }

            return respuesta;
        }

        [HttpPost]
        [Route("Habitaciones/RegistrarHabitacion")]
        public Confirmacion RegistrarHabitaciones(Habitaciones entidad)
        {
            var respuesta = new Confirmacion();

            try
            {
                using (var db = new ProyPrograAvanEntities())
                {
                    var resp = db.RegistrarHabitacion(entidad.tipo_habitacion, entidad.capacidad, entidad.tarifa, entidad.ID_localidad);

                    if (resp > 0)
                    {
                        respuesta.Codigo = 0;
                        respuesta.Detalle = string.Empty;
                    }
                    else
                    {
                        respuesta.Codigo = -1;
                        respuesta.Detalle = "Su información ya se encuentra registrada";
                    }
                }
            }
            catch (Exception)
            {
                respuesta.Codigo = -1;
                respuesta.Detalle = "Se presentó un error en el sistema";
            }

            return respuesta;
        }



        [HttpPut]
        [Route("Habitaciones/ActualizarHabitacion")]
        public Confirmacion ActualizarHabitacion(Habitaciones entidad)
        {
            var respuesta = new Confirmacion();

            try
            {
                using (var db = new ProyPrograAvanEntities())
                {
                    var resp = db.ActualizarHabitacion(entidad.ID_habitacion, entidad.tipo_habitacion, entidad.capacidad, entidad.tarifa, entidad.disponibilidad, entidad.ID_localidad);

                    if (resp > 0)
                    {
                        respuesta.Codigo = 0;
                        respuesta.Detalle = string.Empty;
                    }
                    else
                    {
                        respuesta.Codigo = -1;
                        respuesta.Detalle = "El producto no se pudo actualizar";
                    }
                }
            }
            catch (Exception)
            {
                respuesta.Codigo = -1;
                respuesta.Detalle = "Se presentó un error en el sistema";
            }

            return respuesta;
        }

        [HttpDelete]
        [Route("Habitaciones/EliminarHabitacion")]
        public Confirmacion EliminarHabitaciones(long Consecutivo)
        {
            var respuesta = new Confirmacion();

            try
            {
                using (var db = new ProyPrograAvanEntities())
                {
                    var resp = db.EliminarHabitacion(Consecutivo);

                    if (resp > 0)
                    {
                        respuesta.Codigo = 0;
                        respuesta.Detalle = string.Empty;
                    }
                    else
                    {
                        respuesta.Codigo = -1;
                        respuesta.Detalle = "El producto no se pudo eliminar";
                    }
                }
            }
            catch (Exception)
            {
                respuesta.Codigo = -1;
                respuesta.Detalle = "Se presentó un error en el sistema";
            }

            return respuesta;
        }
    }
}
