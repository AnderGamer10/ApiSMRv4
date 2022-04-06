using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiSMRv4.Models
{
    public class Clientes
    {
        [Key]
        public string Email { get; set; }
        public string ProfesionalRole { get; set; }
        public int YearsOfExperience { get; set; }
        public string mainChallenges { get; set; }

    }
}
