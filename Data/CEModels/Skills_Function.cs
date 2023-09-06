using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FGO_CE_Manager.Data.CEModels
{
    public class Skills_Function
    {
        [Key]
        public int FunctionID { get; set; }
        [JsonPropertyName("svals")]
        public virtual IEnumerable<Functions_Sval> Svals { get; set; }

    }
}
