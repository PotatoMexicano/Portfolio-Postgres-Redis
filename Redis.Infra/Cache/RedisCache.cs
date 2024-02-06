using System.Text;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Redis.Business.Models;

namespace Redis.Infra.Cache
{
    public class RedisCache(IDistributedCache cache) : IRedisCache
    {
        private readonly DistributedCacheEntryOptions options = new DistributedCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(60));
        private readonly IDistributedCache _cache = cache;

        public async Task SetCache(int id, Produto produto)
        {
            string serializedProduto;
            byte[]? redisProduto;

            serializedProduto = JsonConvert.SerializeObject(produto);
            redisProduto = Encoding.UTF8.GetBytes(serializedProduto);

            options.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(120);

            await _cache.SetAsync($"produto:{id}", redisProduto, options);  
        }

        public async Task<Produto?> GetCache(int id)
        {
            string serializedProduto;
            Produto? produto;

            var redisProduto = await _cache.GetAsync($"produto:{id}");

            if (redisProduto != null)
            {
                serializedProduto = Encoding.UTF8.GetString(redisProduto);
                produto = JsonConvert.DeserializeObject<Produto>(serializedProduto)!;
                return produto;
            }
            else
            {
                return null;
            }
        }
    }
}