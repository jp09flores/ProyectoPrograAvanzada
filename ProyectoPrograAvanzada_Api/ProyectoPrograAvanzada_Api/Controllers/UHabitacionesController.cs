using ProyectoPrograAvanzada_Api.Entidades;
using ProyectoPrograAvanzada_Api.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProyectoPrograAvanzada_Api.Controllers
{
    public class UHabitacionesController : ApiController
    {
        CorreosModel model = new CorreosModel();

        [HttpPost]
        [Route("UHabitaciones/RegistroFinal")]
        public Confirmacion RegistroFinal(Reservas entidad)
        {
            var respuesta = new Confirmacion();

            try
            {
                using (var db = new ProyPrograAvanEntities())
                {
                    string ruta = AppDomain.CurrentDomain.BaseDirectory + "Confirmacion.html";
                    string contenido = File.ReadAllText(ruta);
                    contenido = contenido.Replace("@@Nombre", entidad.nombre_usuario);
                    contenido = contenido.Replace("@@NumeroReserva", entidad.ID_reserva.ToString());
                    contenido = contenido.Replace("@@NumeroHabitacion", entidad.ID_habitacion.ToString());
                    contenido = contenido.Replace("@@FechaEntrada", entidad.fecha_entrada.ToString("yyyy-MM-dd"));
                    contenido = contenido.Replace("@@FechaSalida", entidad.fecha_salida.ToString("yyyy-MM-dd"));
                    contenido = contenido.Replace("@@Detalle", entidad.servicios_adicionales);
                    try
                    {
                        model.EnviarCorreo(entidad.correo_usuario, "Confirmación de Reserva", contenido);
                        var resp = db.RegistrarReserva(entidad.id_usuario, entidad.ID_habitacion, entidad.fecha_entrada, entidad.fecha_salida, entidad.servicios_adicionales);

                        if (resp > 0)
                        {
                            respuesta.Codigo = 0;
                            respuesta.Detalle = string.Empty;
                        }
                        else
                        {
                            respuesta.Codigo = -1;
                            respuesta.Detalle = "La información de la habitación o del usuario es errónea";
                        }
                    }
                    catch (Exception)
                    {
                        respuesta.Codigo = -1;
                        respuesta.Detalle = "Correo no Válido";
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
        [Route("UHabitaciones/UltimaReserva")]
        public ConfirmacionReservas UltimaReserva()
        {
            var respuesta = new ConfirmacionReservas();

            try
            {
                using (var db = new ProyPrograAvanEntities())
                {
                    var datos = db.GetUltimaReserva().FirstOrDefault();

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
    }
}
