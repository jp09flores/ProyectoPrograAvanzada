//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoPrograAvanzada_Api.Models
{
    using System;
    
    public partial class ConsultarReservas_Result
    {
        public long ID_reserva { get; set; }
        public Nullable<long> id_usuario { get; set; }
        public Nullable<long> ID_habitacion { get; set; }
        public string tipo_habitacion { get; set; }
        public Nullable<System.DateTime> fecha_entrada { get; set; }
        public Nullable<System.DateTime> fecha_salida { get; set; }
        public string servicios_adicionales { get; set; }
        public Nullable<bool> estado { get; set; }
        public string nombre_usuario { get; set; }
    }
}
