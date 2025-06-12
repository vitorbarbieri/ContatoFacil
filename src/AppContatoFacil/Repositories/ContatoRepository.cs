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

        public Contato GetById(int id)
        {
            return _context.Contatos.FirstOrDefault(c => c.Id == id);
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

        public Contato Update(Contato contato)
        {
            _context.Contatos.Update(contato);
            _context.SaveChanges();
            return contato;
        }

        public void Delete(int id)
        {
            Contato contato = GetById(id);
            if (contato == null)
            {
                throw new ArgumentException("Contato não encontrado", nameof(id));
            }

            _context.Contatos.Remove(contato);
            _context.SaveChanges();
        }
    }
}