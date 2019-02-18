using System.Linq;
using Dados;
using Dominio.Entidades;
using Dados.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Web.Controllers
{
    public class PessoaController : Controller
    {
        //private readonly ApplicationDbContext _contexto;
        private readonly IPessoaRepository _repository;

        public PessoaController(IPessoaRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var pessoas = _repository.GetAll();
            return View(pessoas);
        }

        public IActionResult Editar(int id)
        {
            var pessoa = _repository.Edit(id);
            return View("Salvar", pessoa);
        }

        public IActionResult Deletar(int id)
        {
            _repository.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Salvar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Salvar(Pessoa model) 
        {   
            if(!VerificaEmailExiste(model.Email))
            {
                _repository.Create(model);
                return RedirectToAction("Index");
            }

            return View();
        }

        public bool VerificaEmailExiste(string email)
        {
            bool existe = _repository.GetAll().Where(x => x.Email.ToUpper().Equals(email.ToUpper())).Count() >= 1;

            return existe;
        }
    }
}