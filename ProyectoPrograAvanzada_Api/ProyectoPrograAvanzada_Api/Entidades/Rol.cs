using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoPrograAvanzada_Api.Entidades
{
    public class Rol
    {
        public long ID_rol { get; set; }
        public string nombre_rol { get; set; }
    }
    public class ConfirmacionRol
    {
        public int Codigo { get; set; }
        public string Detalle { get; set; }
        public object Datos { get; set; }
        public object Dato { get; set; }
    }
}