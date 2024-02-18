using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Redis.Business.Models;
using Redis.Infra.Interface;
using System.Runtime.InteropServices.JavaScript;

namespace Redis.Web.Api.Controllers
{

    public class InsertRequest
    {
        [JsonProperty("name")]
        public required string Name { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController(IProdutoService produtoService) : ControllerBase
    {
        private readonly IProdutoService _produtoService = produtoService;

        [HttpGet]
        [Route("select-all")]
        [Authorize]
        public async Task<IActionResult> ListAll()
        {
            List<Produto> produtos = await _produtoService.ListAll();
            return Ok(produtos);
        }

        [HttpGet]
        [Route("count")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Count()
        {
            int contagem = await _produtoService.Count();
            return Ok(contagem);
        }

        [HttpGet]
        [Route("select-one")]
        [Authorize]
        public async Task<IActionResult> SelectOne(int id)
        {
            Produto? produto = await _produtoService.ListById(id);

            return Ok(produto);
        }

        [HttpPost]
        [Route("insert")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Insert(InsertRequest request)
        {
            Produto? produto = await _produtoService.Insert(name: request.Name);

            return Ok(produto);
        }

    }
}
