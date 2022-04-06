using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiSMRv4.Models
{
    public class Preguntas
    {
        [Key]
        public string PreguntaId { get; set; }
        public string Pregunta { get; set; }
        public string Subdimension { get; set; }
        [Required]
        public string tipoPregunta { get; set; }

    }
}
