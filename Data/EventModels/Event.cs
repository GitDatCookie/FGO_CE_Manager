using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FGO_CE_Manager.Data.EventModels
{
    public class Event
    {
        [Key] 
        public int ID { get; set; }

        [JsonPropertyName("id")]
        public int EventID { get; set; }


        [JsonPropertyName("name")]
        public string Name { get; set; }

    }
}
