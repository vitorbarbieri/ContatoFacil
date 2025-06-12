using AppContatoFacil.Models;

namespace AppContatoFacil.Repositories.Interfaces
{
    public interface IContatoRepository
    {
        Contato GetById(int id);
        List<Contato> GetAll();
        Contato Add(Contato contato);
        Contato Update(Contato contato);
        void Delete(int id);
    }
}