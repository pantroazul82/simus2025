using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SM.Aplicacion.ServicioEstimulos;
using System.ServiceModel;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SM.LibreriaComun.DTO;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;


namespace SM.Aplicacion.Servinformacion
{
    public class ResultadoWebServices
    {
        public async Task<CoordenadasDTO> ObtenerCoordenadas(string direccion, string codigoMunicipio, string token, string url)
        {
            string accessToken = token;
            CoordenadasDTO coordenadas = new CoordenadasDTO();
            try
            {

                Uri theUri = new Uri(url);

                using (var Client = new HttpClient())
                {
                    Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    Client.DefaultRequestHeaders.Add("Authorization", "Token " + accessToken);
                    Client.DefaultRequestHeaders.Host = theUri.Host;

                    Encabezado objencabezado = new Encabezado();
                    objencabezado.address = direccion;
                    objencabezado.city = codigoMunicipio;
                    
                    DataContractJsonSerializer jsonSer = new DataContractJsonSerializer(typeof(Encabezado));

                    MemoryStream ms = new MemoryStream();
                    jsonSer.WriteObject(ms, objencabezado);
                    ms.Position = 0;

                    //use a Stream reader to construct the StringContent (Json) 
                    StreamReader sr = new StreamReader(ms);
                    StringContent theContent = new StringContent(sr.ReadToEnd(), System.Text.Encoding.UTF8, "application/json");

                    HttpResponseMessage aResponse = await Client.PostAsync(theUri, theContent);

                    if (aResponse.IsSuccessStatusCode)
                    {
                        dynamic content = JsonConvert.DeserializeObject(aResponse.Content.ReadAsStringAsync().Result);
                        var array = content.data;

                        //jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(array);
                        coordenadas.Longitud = array.longitude;
                        coordenadas.Latitud = array.latitude;

                    }
                    else
                    {
                        // show the response status code 
                        String failureMsg = "HTTP Status: " + aResponse.StatusCode.ToString() + " – Reason: " + aResponse.ReasonPhrase;
                    }

                    sr.Dispose();
                    aResponse.Dispose();
                    aResponse = null;
                    Client.Dispose();
                }

                return coordenadas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    [DataContract]
    public class Encabezado
    {

        [DataMember(Name = "address")]
        public string address { get; set; }

        [DataMember(Name = "city")]
        public string city { get; set; }
    }
}
