﻿using ProyectoPrograAvanzada_Api.Entidades;
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

        [HttpGet]
        [Route("Usuarios/ConsultarUsuarios")]
        public ConfirmacionUsuarios ConsultarUsuarios()
        {
            var respuesta = new ConfirmacionUsuarios();

            try
            {
                using (var db = new ProyPrograAvanEntities())
                {
                    var datos = db.ConsultarUsuarios().ToList();

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
        [Route("Usuarios/ConsultarUsuarios")]
        public ConfirmacionUsuarios ConsultarUsuario(long id)
        {
            var respuesta = new ConfirmacionUsuarios();

            try
            {
                using (var db = new ProyPrograAvanEntities())
                {
                    var datos = db.ConsultarUsuario(id).FirstOrDefault();

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

        [HttpPut]
        [Route("Usuarios/ActualizarUsuario")]
        public Confirmacion ActualizarUsuario(Usuarios entidad)
        {
            var respuesta = new Confirmacion();

            try
            {
                using (var db = new ProyPrograAvanEntities())
                {
                    var resp = db.ActualizarUsuario(entidad.id_usuario,entidad.nombre,entidad.correo_electronico,entidad.contrasena,entidad.ID_rol,entidad.estado);

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
        [Route("Usuarios/EliminarUsuario")]
        public Confirmacion EliminarUsuario(long Consecutivo)
        {
            var respuesta = new Confirmacion();

            try
            {
                using (var db = new ProyPrograAvanEntities())
                {
                    var resp = db.EliminarUsuario(Consecutivo);

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
