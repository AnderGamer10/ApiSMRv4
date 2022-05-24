using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiSMRv4.Models
{
    public class Maturity_levels
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string NombreLevel { get; set; }
        public string Subdimension { get; set; }
        public int MaxPregunta { get; set; }
        public int valor { get; set; }
        public string ciudad { get; set; }
    }
}
