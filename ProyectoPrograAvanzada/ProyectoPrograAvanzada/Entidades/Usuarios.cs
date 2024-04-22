using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoPrograAvanzada.Entidades
{
    public class Usuarios
    {
        public long id_usuario { get; set; }
        public string nombre { get; set; }
        public string correo_electronico { get; set; }
        public string contrasena { get; set; }
        public bool estado { get; set; }
        public long ID_rol { get; set; }
        public string nombre_rol { get; set; }
        public string codigo { get; set; }
    }
    public class ConfirmacionUsuarios
    {
        public int Codigo { get; set; }
        public string Detalle { get; set; }
        public List<Usuarios> Datos { get; set; }
        public Usuarios Dato { get; set; }
    }
}