using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FGO_CE_Manager.Data.CEModels
{
    public class CE
    {
        [Key] 
        public Guid Guid { get; set; }

        [JsonPropertyName("id")]
        public int ID { get; set; }

        [JsonPropertyName("collectionNo")]
        public int CollectionNo { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("extraAssets")]
        public virtual CE_ExtraAssets ExtraAssets { get; set; }

        [JsonPropertyName("skills")]
        public virtual IEnumerable<CE_Skill> Skills { get; set; }

    }
}
