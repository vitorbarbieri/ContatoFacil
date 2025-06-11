using AppContatoFacil.Models;

namespace AppContatoFacil.Repositories.Interfaces
{
    public interface IContatoRepository
    {
        List<Contato> GetAll();
        Contato Add(Contato contato);
    }
}