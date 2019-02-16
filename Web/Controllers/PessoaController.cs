using System.Linq;
using Dados;
using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Web.Controllers
{
    public class PessoaController : Controller
    {
        private readonly ApplicationDbContext _contexto;

        public PessoaController(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public IActionResult Index()
        {
            var pessoas = _contexto.Pessoas.ToList();
            return View(pessoas);
        }

        public IActionResult Editar(int id)
        {
            var pessoa = _contexto.Pessoas.First(x => x.Id == id);
            return View("Salvar", pessoa);
        }

        public IActionResult Deletar(int id)
        {
            var pessoa = _contexto.Pessoas.First(x => x.Id == id);
            _contexto.Pessoas.Remove(pessoa);
            _contexto.SaveChanges();

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
                if(model.Id == 0)
                {
                    _contexto.Pessoas.Add(model);
                }
                else
                {
                    var pessoa = _contexto.Pessoas.First(x => x.Id == model.Id);
                    pessoa.Nome = model.Nome;
                    pessoa.Email = model.Email;
                    pessoa.Telefone = model.Telefone;
                }

                _contexto.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        public bool VerificaEmailExiste(string email)
        {
            bool existe = _contexto.Pessoas.Where(x => x.Email.ToUpper().Equals(email.ToUpper())).Count() > 1;

            return existe;
        }
    }
}