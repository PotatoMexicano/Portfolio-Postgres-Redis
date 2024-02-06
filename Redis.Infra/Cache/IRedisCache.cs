using Redis.Business.Models;

namespace Redis.Infra.Cache
{
    public interface IRedisCache
    {
        Task SetCache(int id, Produto produto);
        Task<Produto?> GetCache(int id);
    }
}