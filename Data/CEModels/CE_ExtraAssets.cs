using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FGO_CE_Manager.Data.CEModels
{
    public class CE_ExtraAssets
    {
        [Key]
        public int ExtraAssetsID { get; set; }

        [JsonPropertyName("charaGraph")]
        public virtual ExtraAssets_CharaGraph CharaGraph { get; set; }

        [JsonPropertyName("faces")]
        public virtual ExtraAssets_Faces Faces { get; set; }

    }
}
