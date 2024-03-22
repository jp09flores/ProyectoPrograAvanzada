using ProyectoPrograAvanzada_Api.Entidades;
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
        //[HttpGet]
        //[Route("Usuarios/ConsultarUsuarios")]
        //public ConfirmacionUsuarios ConsultarUsuarios(bool MostrarTodos)
        //{
        //    var respuesta = new ConfirmacionUsuarios();

        //    try
        //    {
        //        using (var db = new martes_dbEntities())
        //        {
        //            var datos = db.ConsultarProductos(MostrarTodos).ToList();

        //            if (datos.Count > 0)
        //            {
        //                respuesta.Codigo = 0;
        //                respuesta.Detalle = string.Empty;
        //                respuesta.Datos = datos;
        //            }
        //            else
        //            {
        //                respuesta.Codigo = -1;
        //                respuesta.Detalle = "No se encontraron resultados";
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        respuesta.Codigo = -1;
        //        respuesta.Detalle = "Se presentó un error en el sistema";
        //    }

        //    return respuesta;
        //}

        //[HttpGet]
        //[Route("HabiUsuariostaciones/ConsultarUsuarios")]
        //public ConfirmacionUsuarios ConsultarUsuarios(long Consecutivo)
        //{
        //    var respuesta = new ConfirmacionUsuarios();

        //    try
        //    {
        //        using (var db = new martes_dbEntities())
        //        {
        //            var datos = db.ConsultarProducto(Consecutivo).FirstOrDefault();

        //            if (datos != null)
        //            {
        //                respuesta.Codigo = 0;
        //                respuesta.Detalle = string.Empty;
        //                respuesta.Dato = datos;
        //            }
        //            else
        //            {
        //                respuesta.Codigo = -1;
        //                respuesta.Detalle = "No se encontraron resultados";
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        respuesta.Codigo = -1;
        //        respuesta.Detalle = "Se presentó un error en el sistema";
        //    }

        //    return respuesta;
        //}

        //[HttpPost]
        //[Route("Usuarios/RegistrarUsuarios")]
        //public Confirmacion RegistrarUsuarios(Usuarios entidad)
        //{
        //    var respuesta = new Confirmacion();

        //    try
        //    {
        //        using (var db = new martes_dbEntities())
        //        {
        //            var resp = db.RegistrarProducto(entidad.NombreProducto, entidad.Precio, entidad.Inventario, entidad.IdCategoria).FirstOrDefault();

        //            if (resp > 0)
        //            {
        //                respuesta.Codigo = 0;
        //                respuesta.Detalle = string.Empty;
        //            }
        //            else
        //            {
        //                respuesta.Codigo = -1;
        //                respuesta.Detalle = "Su información ya se encuentra registrada";
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        respuesta.Codigo = -1;
        //        respuesta.Detalle = "Se presentó un error en el sistema";
        //    }

        //    return respuesta;
        //}



        //[HttpPut]
        //[Route("Usuarios/ActualizarUsuarios")]
        //public Confirmacion ActualizarUsuarios(Usuarios entidad)
        //{
        //    var respuesta = new Confirmacion();

        //    try
        //    {
        //        using (var db = new martes_dbEntities())
        //        {
        //            var resp = db.ActualizarProducto(entidad.Consecutivo, entidad.NombreProducto, entidad.Precio, entidad.Inventario, entidad.IdCategoria);

        //            if (resp > 0)
        //            {
        //                respuesta.Codigo = 0;
        //                respuesta.Detalle = string.Empty;
        //            }
        //            else
        //            {
        //                respuesta.Codigo = -1;
        //                respuesta.Detalle = "El producto no se pudo actualizar";
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        respuesta.Codigo = -1;
        //        respuesta.Detalle = "Se presentó un error en el sistema";
        //    }

        //    return respuesta;
        //}

        //[HttpDelete]
        //[Route("Usuarios/EliminarUsuarios")]
        //public Confirmacion EliminarUsuarios(long Consecutivo)
        //{
        //    var respuesta = new Confirmacion();

        //    try
        //    {
        //        using (var db = new martes_dbEntities())
        //        {
        //            var resp = db.EliminarProducto(Consecutivo);

        //            if (resp > 0)
        //            {
        //                respuesta.Codigo = 0;
        //                respuesta.Detalle = string.Empty;
        //            }
        //            else
        //            {
        //                respuesta.Codigo = -1;
        //                respuesta.Detalle = "El producto no se pudo eliminar";
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        respuesta.Codigo = -1;
        //        respuesta.Detalle = "Se presentó un error en el sistema";
        //    }

        //    return respuesta;
        //}
    }
}
