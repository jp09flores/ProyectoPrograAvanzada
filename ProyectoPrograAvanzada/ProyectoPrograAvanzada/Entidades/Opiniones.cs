using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoPrograAvanzada.Entidades
{
    public class Opiniones
    {
        public long Id_opinon { get; set; }
        public long id_usuario { get; set; }

        public long ID_reserva { get; set; }

        public string opinion_texto { get; set; }

    }

    public class ConfirmacionOpiniones
    {
        public int Codigo { get; set; }
        public string Detalle { get; set; }
        public List<Opiniones> Datos{ get; set; }

    }
}