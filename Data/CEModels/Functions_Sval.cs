using FGO_CE_Manager.Data.EventModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace FGO_CE_Manager.Data.CEModels
{
    public class Functions_Sval
    {
        [Key]
        public int SvalID { get; set; }

        [JsonPropertyName("EventId")]
        public int? EventID { get; set; }

        public virtual FGOEvent? FGOEvent{ get; set; }

    }
}
