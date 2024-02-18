using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Redis.Business.Models;
using Redis.Infra.Cache;
using Redis.Infra.Context;
using Redis.Infra.Interface;
using Redis.Infra.Service;

namespace Redis;

class Program
{
    public static void Main(string[] args)
    {
        var services = new ServiceCollection();

        services.AddSingleton<IProdutoService, ProdutoService>()
        .AddStackExchangeRedisCache(options => options.Configuration = "localhost:6379")
        .AddDbContext<AppDbContext>(options => options.UseNpgsql("Host=localhost:5431;Database=postgres;Userid=postgres;Password=UrubuDoPix;"))
        .AddScoped<IRedisCache, RedisCache>()
        .BuildServiceProvider();

        var serviceProvicer = services.BuildServiceProvider();
        var produtoService = serviceProvicer.GetService<IProdutoService>();
        var serviceCache = serviceProvicer.GetService<IRedisCache>();

        int[] produtos = [0, 1, 2, 3, 4, 5, 6, 7, 8];

        
        foreach (var prod in produtos)
        {
            Console.WriteLine($"Buscando produto: {prod}");
            Produto? produto = produtoService!.ListById(prod).Result;

            if (produto != null)
            {
                Console.WriteLine(produto.Name);
            }
            
        }       

        Console.ReadLine();
        
    }
}