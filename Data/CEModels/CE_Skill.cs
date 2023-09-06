using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FGO_CE_Manager.Data.CEModels
{
    public class CE_Skill
    {
        [Key]
        public int SkillID { get; set; }

        [JsonPropertyName("functions")]
        public virtual IEnumerable<Skills_Function> Functions { get; set; }
    }
}
