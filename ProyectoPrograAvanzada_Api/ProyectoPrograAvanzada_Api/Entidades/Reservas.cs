﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoPrograAvanzada_Api.Entidades
{
    public class Reservas
    {
        public long ID_reserva { get; set; }
        public long id_usuario { get; set; }
        public long ID_habitacion { get; set; }
        public string tipo_habitacion { get; set; }
        public DateTime fecha_entrada { get; set; }
        public DateTime fecha_salida { get; set; }
        public string servicios_adicionales { get; set; }
        public bool estado { get; set; }
        public string nombre_usuario { get; set; }
        public string correo_usuario { get; set; }
    }
    public class ConfirmacionReservas
    {
        public int Codigo { get; set; }
        public string Detalle { get; set; }
        public object Datos { get; set; }
        public object Dato { get; set; }
    }
}