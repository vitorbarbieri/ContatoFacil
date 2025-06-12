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
                _contatoRepository.Add(contato);
                return RedirectToAction(nameof(Index));
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
                _contatoRepository.Update(contato);
                return RedirectToAction(nameof(Index));
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
            Contato contato = _contatoRepository.GetById(id);
            if (contato == null)
            {
                return NotFound();
            }

            _contatoRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}