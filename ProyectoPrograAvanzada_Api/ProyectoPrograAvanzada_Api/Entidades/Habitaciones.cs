using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoPrograAvanzada_Api.Entidades
{
    public class Habitaciones
    {
        public long ID_habitacion { get; set; }
        public string tipo_habitacion { get; set; }
        public int capacidad { get; set; }
        public decimal tarifa { get; set; }
        public bool disponibilidad { get; set; }
        public long ID_localidad { get; set; }
        public string nombre_localidad { get; set; }
    }
    public class ConfirmacionHabitaciones
    {
        public int Codigo { get; set; }
        public string Detalle { get; set; }
        public object Datos { get; set; }
        public object Dato { get; set; }
    }
}