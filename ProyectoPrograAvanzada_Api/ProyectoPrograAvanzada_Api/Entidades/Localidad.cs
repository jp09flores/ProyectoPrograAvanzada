using ProyectoPrograAvanzada_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoPrograAvanzada_Api.Entidades
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
        public List<ConsultarLocalidad_Result> Datos { get; set; }
        public ConsultarLocalidad_Result Dato { get; set; }
    }
}