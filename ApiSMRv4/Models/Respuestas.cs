using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiSMRv4.Models
{
    public class Respuestas

    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdRespuesta { get; set; }
        public string Ciudad { get; set; }
        public int Año { get; set; }
        [Required]
        [ForeignKey("Clientes")]
        public string Email { get; set; }
        [Required]
        [ForeignKey("Preguntas")]
        public string IdPregunta { get; set; }
        public int Respuesta { get; set; }

        //PROPIEDADES DE NAVEGACIÓN
        [System.Text.Json.Serialization.JsonIgnore]
        public Clientes Clientes { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public Preguntas Preguntas { get; set; }

    }
}
