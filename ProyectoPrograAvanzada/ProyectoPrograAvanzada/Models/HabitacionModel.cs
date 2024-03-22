using Newtonsoft.Json;
using ProyectoPrograAvanzada.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Web;

namespace ProyectoPrograAvanzada.Models
{
    public class HabitacionModel
    {
        public ConfirmacionHabitaciones ConsultarHabitaciones(bool MostrarTodos)
        {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlApi"] + "Habitaciones/ConsultarHabitaciones?MostrarTodos="+MostrarTodos;
                var respuesta = client.GetAsync(url).Result;

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<ConfirmacionHabitaciones>().Result;
                else
                    return null;
            }
        }
        public ConfirmacionLocalidad ConsultarLocalidad()
        {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlApi"] + "Habitaciones/ConsultarLocalidad";
                var respuesta = client.GetAsync(url).Result;

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<ConfirmacionLocalidad>().Result;
                else
                    return null;
            }
        }

        public ConfirmacionHabitaciones ConsultarHabitacion(long Consecutivo)
        {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlApi"] + "Habitaciones/ConsultarHabitacion?Consecutivo=" + Consecutivo;
                var respuesta = client.GetAsync(url).Result;

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<ConfirmacionHabitaciones>().Result;
                else
                    return null;
            }
        }

        public Confirmacion RegistrarHabitaciones(Habitaciones entidad)
        {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlApi"] + "Habitaciones/RegistrarHabitacion";
                JsonContent jsonEntidad = JsonContent.Create(entidad);
                var respuesta = client.PostAsync(url, jsonEntidad).Result;

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<Confirmacion>().Result;
                else
                    return null;
            }
        }



        public Confirmacion ActualizarHabitaciones(Habitaciones entidad)
        {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlApi"] + "Habitaciones/ActualizarHabitacion";
                JsonContent jsonEntidad = JsonContent.Create(entidad);
                var respuesta = client.PutAsync(url, jsonEntidad).Result;

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<Confirmacion>().Result;
                else
                    return null;
            }
        }

        public Confirmacion EliminarHabitaciones(long Consecutivo)
        {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlApi"] + "Habitaciones/EliminarHabitacion?Consecutivo=" + Consecutivo;
                var respuesta = client.DeleteAsync(url).Result;

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<Confirmacion>().Result;
                else
                    return null;
            }
        }
    }
}