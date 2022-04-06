using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiSMRv4.Models
{
    public class Elementos
    {
        [Required]
        [ForeignKey("Preguntas")]
        public string IdPregunta { get; set; }
        public string tipoPregunta { get; set; }
        [Key]
        public string Elemento { get; set; }
        public int Valor { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public Preguntas Preguntas { get; set; }

    }
}
