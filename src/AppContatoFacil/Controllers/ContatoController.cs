using AppContatoFacil.Models;
using AppContatoFacil.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AppContatoFacil.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepository _contatoRepository;

        public ContatoController(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }

        public IActionResult Index()
        {
            List<Contato> contatos = _contatoRepository.GetAll();
            return View(contatos);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Contato contato)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _contatoRepository.Add(contato);
                    TempData["Sucesso"] = "Contato adicionado com sucesso!";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception erro)
                {
                    TempData["Erro"] = "Erro ao adicionar contato: " + erro.Message;
                }
            }
            return View(contato);
        }

        public IActionResult Edit(int id)
        {
            Contato contato = _contatoRepository.GetById(id);
            if (contato == null)
            {
                return NotFound();
            }

            return View(contato);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Contato contato)
        {
            if (id != contato.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _contatoRepository.Update(contato);
                    TempData["Sucesso"] = "Contato atualizado com sucesso!";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception erro)
                {
                    TempData["Erro"] = "Erro ao atualizar contato: " + erro.Message;
                }
            }
            return View(contato);
        }

        public IActionResult Delete(int id)
        {
            Contato contato = _contatoRepository.GetById(id);
            if (contato == null)
            {
                return NotFound();
            }

            return View(contato);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                Contato contato = _contatoRepository.GetById(id);
                if (contato == null)
                {
                    return NotFound();
                }

                _contatoRepository.Delete(id);
                TempData["Sucesso"] = "Contato excluido com sucesso!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception erro)
            {
                TempData["Erro"] = "Erro ao excluir contato: " + erro.Message;
                return View();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}