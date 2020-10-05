using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace jogoEmprestado.Models
{
    public class AppDbContext : DbContext
    {
        public virtual DbSet<Jogo> Jogos { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

    }
}
