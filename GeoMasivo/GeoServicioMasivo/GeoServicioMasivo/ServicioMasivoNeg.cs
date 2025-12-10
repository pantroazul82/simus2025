using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using ExtensionMethods;

namespace GeoServicioMasivo
{
    public class ServicioMasivoNeg
    {
        public async void ObtenerCoordenadas(string token, string url)
        {
            string accessToken = "57WZ1Y46AQ1ENB91PBLMXPS3R4ELBB";
            CoordenadasDTO coordenadas = new CoordenadasDTO();
            try
            {
                url = "https://sitidata-stdr.appspot.com/api/massive";

                Uri theUri = new Uri(url);

                using (var Client = new HttpClient())
                {
                    Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    Client.DefaultRequestHeaders.Add("Authorization", "Token " + accessToken);
                    Client.DefaultRequestHeaders.Host = theUri.Host;

                    ///consultar agrupaciones
                   // List<Encabezado> listResultado = GeoServicioMasivo.AgrupacionNeg.ConsultarAgrupaciones();

                    List<Encabezado> listResultado = GeoServicioMasivo.EscuelasNeg.ConsultarEscuelas();

                    var listadoDirecciones = new GetResultado { row = listResultado };

                    string jsonString = listadoDirecciones.ToJSON();
                    StringContent theContent = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json");
                    HttpResponseMessage aResponse = await Client.PostAsync(theUri, theContent);

                    if (aResponse.IsSuccessStatusCode)
                    {
                        dynamic content = JsonConvert.DeserializeObject(aResponse.Content.ReadAsStringAsync().Result);
                        var array = content.data;

                        int i = 0;
                        foreach (var datos in listResultado)
                        {
                            string Longitud = string.Empty;
                            string Latitud = string.Empty;
                            foreach (JProperty item in array.Properties())
                            {
                                if (item.Name == i.ToString())
                                {
                                    string value = item.Value.ToString();

                                    foreach (JObject singleProp in item)
                                    {
                                        foreach (JProperty p in singleProp.Properties())
                                        {
                                            if (p.Name == "longitude")
                                                Longitud = p.Value.ToString();

                                            if (p.Name == "latitude")
                                                Latitud = p.Value.ToString();
                                            
                                        }
                                    }

                                    if ((!string.IsNullOrEmpty(Latitud)) && (!string.IsNullOrEmpty(Longitud)))
                                    {
                                       // AgrupacionNeg.ActualizarAgrupacion(Convert.ToInt32(datos.identificador), Latitud, Longitud);
                                        //EscuelasNeg.ActualizarEscuelas(Convert.ToInt32(datos.identificador), Latitud, Longitud);
                                        break;
                                    }
                                }

                            }
                            i++;
                        }
                   
                    }
                    else
                    {
                        // show the response status code 
                        String failureMsg = "HTTP Status: " + aResponse.StatusCode.ToString() + " – Reason: " + aResponse.ReasonPhrase;
                    }

                    aResponse.Dispose();
                    aResponse = null;
                    Client.Dispose();
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static IEnumerable<JToken> AllChildren(JToken json)
        {
            foreach (var c in json.Children())
            {
                yield return c;
                foreach (var cc in AllChildren(c))
                {
                    yield return cc;
                }
            }
        }

        [DataContract]
        public class GetResultado
        {
            public List<Encabezado> row { get; set; }

        }

        [DataContract]
        public class Encabezado
        {
            [DataMember(Name = "identificador")]
            public string identificador { get; set; }


            [DataMember(Name = "ciudad")]
            public string ciudad { get; set; }

            [DataMember(Name = "direccion")]
            public string direccion { get; set; }

        }

        public class CoordenadasDTO
        {

            public string Latitud { get; set; }

            public string Longitud { get; set; }

            public string Barrio { get; set; }

            public string Localidad { get; set; }

            public string Direccion { get; set; }
            public string Ciudad { get; set; }


        }
    }
}
