using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoPrograAvanzada.Entidades
{
    public class Localidad
    {
        public long ID_Localidad { get; set; }
        public string nombre_localidad { get; set; }
    }
    public class ConfirmacionLocalidad
    {
        public int Codigo { get; set; }
        public string Detalle { get; set; }
        public List<Localidad> Datos { get; set; }
        public Localidad Dato { get; set; }
    }
}