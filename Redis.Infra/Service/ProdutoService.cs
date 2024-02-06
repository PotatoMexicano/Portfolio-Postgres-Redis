using System.Text;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Redis.Business.Models;
using Redis.Infra.Context;
using Redis.Infra.Interface;
using Mono.TextTemplating;
using Redis.Infra.Cache;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Redis.Infra.Service
{
    public class ProdutoService(AppDbContext context, IRedisCache cache) : IProdutoService
    {
        private readonly AppDbContext _context = context;
        private readonly IRedisCache _cache = cache;

        public async Task<int> Count()
        {
            int quantidade = 0;
            quantidade = await _context.Produtos.CountAsync();
            return quantidade;
        }

        public async Task<List<Produto>> ListAll()
        {
            List<Produto> produtos = await _context.Produtos.ToListAsync();
            Thread.Sleep(TimeSpan.FromSeconds(5));

            return produtos;
        }

        public async Task<Produto?> ListById(int id)
        {
            Produto? produto;

            produto = await _cache.GetCache(id);

            if (produto != null)
            {
                Console.WriteLine("Produto recuperado do Redis.");
                return produto;
            }
            
            produto = await _context.Produtos.Where(p => p.Id == id).FirstOrDefaultAsync();
            Thread.Sleep(TimeSpan.FromSeconds(5));

            if (produto != null)
            {
                await _cache.SetCache(id, produto);
                Console.WriteLine("Produto salvo em Redis.");
            }

            return produto;
        }

        public async Task<Produto?> ListFirst()
        {
            Produto? produto = await _context.Produtos.FirstOrDefaultAsync();
            Thread.Sleep(TimeSpan.FromSeconds(5));
            return produto;
        }
    }
}