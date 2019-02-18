using System.Linq;
using Dominio.Entidades;
using Dados.Interfaces;

namespace Dados.Repository
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly ApplicationDbContext _context;

        public PessoaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(Pessoa model)
        {
            if(model.Id == 0)
            {
                _context.Pessoas.Add(model);
            }
            else
            {
                var pessoa = _context.Pessoas.First(x => x.Id == model.Id);
                pessoa.Nome = model.Nome;
                pessoa.Email = model.Email;
                pessoa.Telefone = model.Telefone;
            }

            _context.SaveChanges();
        }

        public Pessoa Edit(int id)
        {
            var pessoa = _context.Pessoas.First(x => x.Id == id);
            return pessoa;
        }
        public Pessoa GetPessoaById(int id)
        {
            var pessoa = _context.Pessoas.First(x => x.Id == id);
            return pessoa;
        }

        public void Delete(int id)
        {
            var pessoa = _context.Pessoas.First(x => x.Id == id);
            _context.Pessoas.Remove(pessoa);
            _context.SaveChanges();
        }

        public IQueryable<Pessoa> GetAll()
        {
            var pessoas = _context.Pessoas;
            return pessoas;
        }
    }
}