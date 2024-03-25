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
    public class UsuariosController : ApiController
    {

        [HttpPost]
        [Route("Usuarios/InicioSesion")]
        public ConfirmacionUsuarios IniciarSesionUsuario(Usuarios entidad)
        {
            var respuesta = new ConfirmacionUsuarios();

            try
            {
                using (var db = new ProyPrograAvanEntities())
                {
                    var datos = db.IniciarSesionUsuario(entidad.correo_electronico, entidad.contrasena).FirstOrDefault();

                    if (datos != null)
                    {
                      
                            respuesta.Codigo = 0;
                            respuesta.Detalle = string.Empty;
                            respuesta.Dato = datos;
                        
                    }
                    else
                    {
                        respuesta.Codigo = -1;
                        respuesta.Detalle = "No se pudo validar su información";
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
        [Route("Usuarios/RegistrarUsuarios")]
        public Confirmacion RegistrarUsuarios(Usuarios entidad)
        {
            var respuesta = new Confirmacion();

            try
            {
                using (var db = new ProyPrograAvanEntities())
                {
                    var resp = db.RegistrarUsuario(entidad.nombre, entidad.correo_electronico, entidad.contrasena);

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


    }
}
