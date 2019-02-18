using System.Linq;
using System.Threading.Tasks;
using Dominio.Entidades;

namespace Dados.Interfaces
{
    public interface IPessoaRepository
    {
        void Create(Pessoa pessoa);
        Pessoa Edit(int id);
        Pessoa GetPessoaById(int id);
        void Delete(int id);
        IQueryable<Pessoa> GetAll();
    }
}