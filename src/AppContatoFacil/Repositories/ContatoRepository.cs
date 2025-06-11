using AppContatoFacil.Data;
using AppContatoFacil.Models;
using AppContatoFacil.Repositories.Interfaces;

namespace AppContatoFacil.Repositories
{
    public class ContatoRepository : IContatoRepository
    {
        private readonly ApplicationDbContext _context;

        public ContatoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Contato> GetAll()
        {
            return _context.Contatos.OrderBy(c => c.Nome).ToList();
        }

        public Contato Add(Contato contato)
        {
            _context.Contatos.Add(contato);
            _context.SaveChanges();
            return contato;
        }
    }
}