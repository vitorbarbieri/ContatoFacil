using AppContatoFacil.Models;
using Microsoft.EntityFrameworkCore;

namespace AppContatoFacil.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Contato> Contatos { get; set; }
    }
}