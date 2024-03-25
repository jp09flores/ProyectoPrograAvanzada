using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http.Json;
using System.Net.Http;
using System.Web;

namespace ProyectoPrograAvanzada.Entidades
{
    public class UsuariosModel
    {

        public string url = ConfigurationManager.AppSettings["urlApi"];
        public Confirmacion Registro(Usuarios entidad)
        {
            using (var client = new HttpClient())
            {
                url += "Inicio/Registro";
                JsonContent jsonEntidad = JsonContent.Create(entidad);
                var respuesta = client.PostAsync(url, jsonEntidad).Result;

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<Confirmacion>().Result;
                else
                    return null;
            }
        }

        public ConfirmacionUsuarios InicioSesion(Usuarios entidad)
        {
            using (var client = new HttpClient())
            {
                url += "Inicio/InicioSesion";
                JsonContent jsonEntidad = JsonContent.Create(entidad);
                var respuesta = client.PostAsync(url, jsonEntidad).Result;

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<ConfirmacionUsuarios>().Result;
                else
                    return null;
            }
        }

    }
}