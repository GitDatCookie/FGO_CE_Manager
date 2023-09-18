using FGO_CE_Manager.Data.CEModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FGO_CE_Manager.Data.EventModels
{
    public class FGOEvent
    {
        [JsonPropertyName("id")]
        public int id { get; set; }

        [Key] 
        public Guid FGOEventID { get; set; }


        [JsonPropertyName("name")]
        public string Name { get; set; }


    }
}
