using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiSMRv4.Models
{
    public class PreguntasTabla
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PreguntasTablaId { get; set; }
        [Required]
        [ForeignKey("Preguntas")]
        public string IdPregunta { get; set; }
        public string ElementoPregunta { get; set; }
        public int Valor { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public Preguntas Preguntas { get; set; }
    }
}
