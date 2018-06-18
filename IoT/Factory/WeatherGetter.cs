using System;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Net.Http;
using System.Xml.Linq;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace IoT.Factory
{
    public class WeatherGetter
    {
        public async static Task<RootObject> GetWeather()
        {
            var http = new HttpClient();
            var response = await http.GetAsync("http://api.openweathermap.org/data/2.5/weather?zip=12188&APPID=08abee0ce6c8a690f70489d8827cf3dd");
            var result = await response.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(RootObject));

            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (RootObject)serializer.ReadObject(ms);

            return data;
        }

    }
    



    [DataContract]
    public class Coord
    {
        [DataMember]
        public double lon { get; set; }
        [DataMember]
        public double lat { get; set; }
    }

    [DataContract]
    public class Weather
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string main { get; set; }
        [DataMember]
        public string description { get; set; }
        [DataMember]
        public string icon { get; set; }
    }

    [DataContract]
    public class Main
    {
        [DataMember]
        public double temp { get; set; }
        [DataMember]
        public int pressure { get; set; }
        [DataMember]
        public int humidity { get; set; }
        [DataMember]
        public double temp_min { get; set; }
        [DataMember]
        public double temp_max { get; set; }
    }

    [DataContract]
    public class Wind
    {
        [DataMember]
        public double speed { get; set; }
        [DataMember]
        public int deg { get; set; }
    }

    [DataContract]
    public class Clouds
    {
        [DataMember]
        public int all { get; set; }
    }


    [DataContract]
    public class Sys
    {
        [DataMember]
        public int type { get; set; }
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public double message { get; set; }
        [DataMember]
        public string country { get; set; }
        [DataMember]
        public int sunrise { get; set; }
        [DataMember]
        public int sunset { get; set; }
    }
    [DataContract]
    public class RootObject
    {
        [DataMember]
        public Coord coord { get; set; }
        [DataMember]
        public List<WeatherGetter> weather { get; set; }
        [DataMember]
        public string @base { get; set; }
        [DataMember]
        public Main main { get; set; }
        [DataMember]
        public int visibility { get; set; }
        [DataMember]
        public Wind wind { get; set; }
        [DataMember]
        public Clouds clouds { get; set; }
        [DataMember]
        public int dt { get; set; }
        [DataMember]
        public Sys sys { get; set; }
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public int cod { get; set; }
    }



}
