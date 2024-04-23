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
    public class UsuariosController : ApiController
    {
       CorreosModel model = new CorreosModel();

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
                        if (datos.Temporal && DateTime.Now > datos.Vencimiento)
                        {
                            respuesta.Codigo = -1;
                            respuesta.Detalle = "Su contraseña temporal ha caducado";
                        }
                        else
                        {
                            respuesta.Codigo = 0;
                            respuesta.Detalle = string.Empty;
                            respuesta.Dato = datos;
                        }
                    }
                    else
                    {
                        respuesta.Codigo = -1;
                        respuesta.Detalle = "No se pudo validar su información en el inicio sesion";
                    }
                }
            }
            catch (Exception)
            {
                respuesta.Codigo = -1;
                respuesta.Detalle = "Se presentó un error en el sistema,InicioSesion";
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
                    var resp = db.RegistrarUsuario(entidad.contrasena,entidad.nombre, entidad.correo_electronico);

                    if (resp > 0)
                    {
                        respuesta.Codigo = 0;
                        respuesta.Detalle = string.Empty;
                    }
                    else
                    {
                        respuesta.Codigo = -1;
                        respuesta.Detalle = "Su información ya se encuentra registrada, por favor registre otra";
                    }
                }
            }
            catch (Exception)
            {
                respuesta.Codigo = -1;
                respuesta.Detalle = "Se presentó un error en el sistema,Registro";
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
                        respuesta.Detalle = "No se encontraron resultados para los usuarios";
                    }
                }
            }
            catch (Exception)
            {
                respuesta.Codigo = -1;
                respuesta.Detalle = "Se presentó un error en el sistema,ConsultaUsuarios";
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
                        respuesta.Detalle = "No se encontraron resultados para este usuario";
                    }
                }
            }
            catch (Exception)
            {
                respuesta.Codigo = -1;
                respuesta.Detalle = "Se presentó un error en el sistema,ConsultarUsuario";
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
                        respuesta.Detalle = "El usuario no se pudo actualizar";
                    }
                }
            }
            catch (Exception)
            {
                respuesta.Codigo = -1;
                respuesta.Detalle = "Se presentó un error en el sistema,actualizarUsuario";
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
                        respuesta.Detalle = "El usuario no se pudo eliminar";
                    }
                }
            }
            catch (Exception)
            {
                respuesta.Codigo = -1;
                respuesta.Detalle = "Se presentó un error en el sistema,EliminarUsuario";
            }

            return respuesta;
        }

        [HttpPost]
        [Route("Usuarios/RecuperarAccesoUsuario")]
        public Confirmacion RecuperarAccesoUsuario(Usuarios entidad)
        {

            var respuesta = new Confirmacion();

            try
            {
                using (var db = new ProyPrograAvanEntities())
                {
                    var datos = db.RecuperarAccesoUsuario(entidad.correo_electronico).FirstOrDefault();

                    if (datos != null)
                    {
                        string ruta = AppDomain.CurrentDomain.BaseDirectory + "Password.html";
                        string contenido = File.ReadAllText(ruta);
                        contenido = contenido.Replace("@@Nombre", datos.nombre);
                        contenido = contenido.Replace("@@Contrasenna", datos.contrasena);
                        contenido = contenido.Replace("@@Vencimiento", datos.Vencimiento.ToString("dd/MM/yyyy hh:mm:ss tt"));
                        try
                        {
                            model.EnviarCorreo(datos.correo_electronico, "Acceso Temporal", contenido);
                            respuesta.Codigo = 0;
                            respuesta.Detalle = string.Empty;
                        }
                        catch (Exception)
                        {
                            respuesta.Codigo = -1;
                            respuesta.Detalle = "Correo no valido para recuperar Acesso";
                        }


                    }
                    else
                    {
                        respuesta.Codigo = -1;
                        respuesta.Detalle = "Datos no validos para recupera acceso";
                    }
                }
            }
            catch (Exception)
            {
                respuesta.Codigo = -1;
                respuesta.Detalle = "Se presentó un error en el sistema,RecuperarAccesoUsuario";
            }

            return respuesta;
        }
        [HttpPost]
        [Route("Usuarios/CambiarContrasena")]
        public ConfirmacionUsuarios CambiarContrasena(Usuarios entidad)
        {
            var respuesta = new ConfirmacionUsuarios();

            try
            {
                using (var db = new ProyPrograAvanEntities())
                {
                    var resp = db.CambiarContrasena(entidad.correo_electronico, entidad.codigo, entidad.contrasena);

                    if (resp >0)
                    {
                       
                       
                            respuesta.Codigo = 0;
                            respuesta.Detalle = string.Empty;
                        
                    }
                    else
                    {
                        respuesta.Codigo = -1;
                        respuesta.Detalle = "El contraseña temporal no esta vigente para cambiar contraseña, vuelva a recuperar acceso";
                    }
                }
            }
            catch (Exception)
            {
                respuesta.Codigo = -1;
                respuesta.Detalle = "Se presentó un error en el sistema,CambiarContrasena";
            }

            return respuesta;
        }

    }
}

