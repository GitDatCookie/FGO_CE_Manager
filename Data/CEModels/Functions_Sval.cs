using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FGO_CE_Manager.Data.CEModels
{
    public class Functions_Sval
    {
        [Key]
        public int SvalID { get; set; }
        [JsonPropertyName("EventId")]
        public int? EventID { get; set; }

    }
}
