using System;
using System.Threading.Tasks;
using ApiDotnet5SqliteSample.Data;
using ApiDotnet5SqliteSample.Models;
using ApiDotnet5SqliteSample.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiDotnet5SqliteSample.Controllers
{
    [ApiController]
    [Route("v1")]
    public class ProdutoController : ControllerBase
    {
        [HttpGet]
        [Route("produtos")]
        public async Task<IActionResult> Get(
            [FromServices] ApiDbContext context)
        {
            var produtos = await context
                .Produtos
                .AsNoTracking()
                .ToListAsync();
            
            return Ok(produtos);
        }
        
        [HttpGet]
        [Route("produtos/{id}")]
        public async Task<IActionResult> GetById(
            [FromServices] ApiDbContext context,
            [FromRoute] int id)
        {
            var todo = await context
                .Produtos
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            return todo == null
                ? NotFound()
                : Ok(todo);
        }
        
        [HttpPost("produtos")]
        public async Task<IActionResult> Post(
            [FromServices] ApiDbContext context,
            [FromBody] ProdutoViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var produto = new Produto
            {
                Nome = model.Nome,
                Valor = model.Valor,
                Ativo = true
            };

            await context.Produtos.AddAsync(produto);
            await context.SaveChangesAsync();
            return Created($"v1/produtos/{produto.Id}", produto);
        }
        
        [HttpPut("produtos/{id}")]
        public async Task<IActionResult> PutAsync(
            [FromServices] ApiDbContext context,
            [FromBody] ProdutoViewModel model,
            [FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var produto = await context.Produtos.FirstOrDefaultAsync(x => x.Id == id);

            if (produto == null)
                return NotFound();

            produto.Nome = model.Nome;
            produto.Valor = produto.Valor;
            produto.Ativo = produto.Ativo;
                
            context.Produtos.Update(produto);
            await context.SaveChangesAsync();
            return Ok(produto);
        }

        [HttpDelete("produtos/{id}")]
        public async Task<IActionResult> DeleteAsync(
            [FromServices] ApiDbContext context,
            [FromRoute] int id)
        {
            var produto = await context.Produtos.FirstOrDefaultAsync(x => x.Id == id);

            context.Produtos.Remove(produto);
            await context.SaveChangesAsync();

            return Ok();
        }
    }
}