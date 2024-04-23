using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoPrograAvanzada_Api.Entidades
{
    public class Opiniones
    {
        public long ID_opinion { get; set; }
        public long id_usuario { get; set; }

        public long ID_reserva { get; set; }

        public string opinion_texto { get; set; }

    }

    public class ConfirmacionOpiniones
    {
        public int Codigo { get; set; }
        public string Detalle { get; set; }
        public object Datos { get; set; }

    }
}