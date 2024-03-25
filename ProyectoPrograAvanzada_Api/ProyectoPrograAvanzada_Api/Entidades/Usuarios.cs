using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoPrograAvanzada_Api.Entidades
{
    public class Usuarios
    {
        public long id_usuario { get; set; }
        public string nombre { get; set; }
        public string correo_electronico { get; set; }
        public string contrasena { get; set; }
        public long ID_rol { get; set; }
        public string nombre_rol { get; set; }
    }
    public class ConfirmacionUsuarios
    {
        public int Codigo { get; set; }
        public string Detalle { get; set; }
        public object Datos { get; set; }
        public object Dato { get; set; }
    }
}