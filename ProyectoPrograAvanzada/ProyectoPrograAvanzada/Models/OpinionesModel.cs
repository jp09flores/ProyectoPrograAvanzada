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
    public class OpinionesModel
    {
        public string url = ConfigurationManager.AppSettings["urlApi"];
        public Confirmacion Registro(Opiniones entidad)
        {
            using (var client = new HttpClient())
            {
                url += "Opiniones/RegistrarOpiniones";
                JsonContent jsonEntidad = JsonContent.Create(entidad);
                var respuesta = client.PostAsync(url, jsonEntidad).Result;

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<Confirmacion>().Result;
                else
                    return null;
            }
        }
        public ConfirmacionOpiniones MostrarOpiniones()
        {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlApi"] + "Opiniones/MostrarOpiniones";
                var respuesta = client.GetAsync(url).Result;

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<ConfirmacionOpiniones>().Result;
                else
                    return null;
            }
        }


    }
}
