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
    }
}