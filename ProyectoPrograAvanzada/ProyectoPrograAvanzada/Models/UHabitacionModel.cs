using ProyectoPrograAvanzada.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Policy;
using System.Web;

namespace ProyectoPrograAvanzada.Models
{
    public class UHabitacionModel
    {
        public ConfirmacionHabitaciones ConsultarHabitaciones(bool MostrarTodos)
        {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlApi"] + "Habitaciones/ConsultarHabitaciones?MostrarTodos=" + MostrarTodos;
                var respuesta = client.GetAsync(url).Result;

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<ConfirmacionHabitaciones>().Result;
                else
                    return null;
            }
        }

        public Confirmacion RegistroFinalUHabitacion(Reservas entidad)
        {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlApi"];

                url += "UHabitaciones/RegistroFinal";
                JsonContent jsonEntidad = JsonContent.Create(entidad);
                var respuesta = client.PostAsync(url, jsonEntidad).Result;

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<Confirmacion>().Result;
                else
                    return null;
            }
        }

        public ConfirmacionReservas ConsultarUltimo()
        {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlApi"] + "UHabitaciones/UltimaReserva";
                var respuesta = client.GetAsync(url).Result;

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<ConfirmacionReservas>().Result;
                else
                    return null;
            }
        }
        public ConfirmacionReservas ConsultarReservasUno(long id)
        {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlApi"] + "UHabitaciones/ConsultarReservaUno?id_usuario="+id;
                var respuesta = client.GetAsync(url).Result;

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<ConfirmacionReservas>().Result;
                else
                    return null;
            }
        }
        public Confirmacion EnviarCorreo(Reservas entidad)
        {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlApi"];

                url += "UHabitaciones/EnviarCorreo";
                JsonContent jsonEntidad = JsonContent.Create(entidad);
                var respuesta = client.PostAsync(url, jsonEntidad).Result;

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<Confirmacion>().Result;
                else
                    return null;
            }
        }
        public ConfirmacionReservas Historial(long id)
        {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlApi"] + "UHabitaciones/ConsultarHistorial?id_usuario=" + id;
                var respuesta = client.GetAsync(url).Result;

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<ConfirmacionReservas>().Result;
                else
                    return null;
            }
        }
    }
}