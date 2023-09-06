using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FGO_CE_Manager.Data.CEModels
{
    public class ExtraAssets_Faces
    {
        [Key]
        public int FacesID { get; set; }
        [JsonPropertyName("equip"), NotMapped]
        public Dictionary<string, object> Equip { get; set; }
        public string ImageUri { get; set; } = string.Empty;
    }
}
