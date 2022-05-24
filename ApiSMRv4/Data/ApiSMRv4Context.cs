using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApiSMRv4.Models;

namespace ApiSMRv4.Data
{
    public class ApiSMRv4Context : DbContext
    {
        public ApiSMRv4Context (DbContextOptions<ApiSMRv4Context> options)
            : base(options)
        {
        }

        public DbSet<ApiSMRv4.Models.Clientes> Clientes { get; set; }

        public DbSet<ApiSMRv4.Models.Elementos> Elementos { get; set; }

        public DbSet<ApiSMRv4.Models.Preguntas> Preguntas { get; set; }

        public DbSet<ApiSMRv4.Models.PreguntasTabla> PreguntasTabla { get; set; }

        public DbSet<ApiSMRv4.Models.Respuestas> Respuestas { get; set; }
        public DbSet<ApiSMRv4.Models.Subdimensiones> Subdimensiones { get; set; }
        public DbSet<ApiSMRv4.Models.Maturity_levels> Maturity_levels { get; set; }
    }
}
