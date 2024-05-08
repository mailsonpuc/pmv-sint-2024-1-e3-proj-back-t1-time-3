using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using projeto.Models;

namespace projeto.Data
{
    public class projetoContext : DbContext
    {
        public projetoContext (DbContextOptions<projetoContext> options)
            : base(options)
        {
        }

        public DbSet<projeto.Models.Professor> Professor { get; set; } = default!;
        public DbSet<projeto.Models.Aluno> Aluno { get; set; } = default!;
        public DbSet<projeto.Models.MarcarAula> MarcarAula { get; set; } = default!;
    }
}
