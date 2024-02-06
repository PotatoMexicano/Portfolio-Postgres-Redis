
using Redis.Business.Models;

namespace Redis.Infra.Interface
{
    public interface IProdutoService
    {
        Task<Produto?> ListById(int id);
        Task<List<Produto>> ListAll();
        Task<Produto?> ListFirst();
        Task<int> Count();
    }
}