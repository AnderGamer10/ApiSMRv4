using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiSMRv4.Models
{
    public class Subdimensiones
    {
        public string Dimension { get; set; }
        [Key]
        [Required]
        public string Subdimension { get; set; }
    }
}
