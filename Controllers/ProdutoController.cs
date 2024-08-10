using CadastroDeProduosAPI.Models;
using CadastroDeProduosAPI.Models.Produto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CadastroDeProduosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        public class ApiResponse<T>
        {
            public T Data { get; set; }
            public string Message { get; set; }
        }
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }
    
        [HttpPost]
        public async Task<IActionResult> CriarProduto([FromBody] Produto produto)
        {
            try
            {
                produto.CreateDate = DateTime.Now;
                produto.UpdateDate = DateTime.Now;
                var resultado = await _produtoService.CriarProdutoAsync(produto);

                var response = new ApiResponse<Produto>
                {
                    Data = resultado,
                    Message = "Produto criado com sucesso!"
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponse<object>
                {
                    Data = null,
                    Message = $"Ocorreu um erro: {ex.Message}"
                };

                return StatusCode(500, errorResponse);
            }
        }

         [HttpGet]
          public async Task<ActionResult<List<Produto>>> ListarProdutos()
          {
              try
              {
                List<Produto> produtos = await _produtoService.ListagemProdutosAsync();
                  return Ok(produtos);

              }
              catch (Exception ex)
              {
                  var errorResponse = new ApiResponse<object>
                  {

                      Data = null,
                      Message = $"Ocorreu um erro: {ex.Message}"
                  };

                  return StatusCode(500, errorResponse);

              }

          }

          [HttpGet("{id}")]
         public async Task<IActionResult> ProcurarProduto(int id)
         {
             try
             {

                 Produto produto = await _produtoService.VerificaProdutoAsync(id);  
                 return Ok(produto);
             }
             catch (Exception ex)
             {
                 var errorResponse = new ApiResponse<object>
                 {

                     Data = null,
                     Message = $"Ocorreu um erro: {ex.Message}"
                 };

                 return StatusCode(500, errorResponse);
             }
         }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarProduto(int id)
        {
            try
            {

                    Produto deletado = await _produtoService.DeletandoProdutoAsync(id);
                   if(deletado != null)
                   {
                     var resposta = new ApiResponse<object>
                     {

                        Data = null,
                        Message = $"Item deletado"
                     };
                     return Ok(resposta);

                   }
                   else
                   {
                    return BadRequest();
                }
               
               

            }

            catch (Exception ex)
            {
                var errorResponse = new ApiResponse<object>
                {

                    Data = null,
                    Message = $"Ocorreu um erro: {ex.Message}"
                };

                return StatusCode(500, errorResponse);
            }
        }

       
        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarProduto(int id, [FromBody] Produto produto)
        {
            try
            {
                  
                Produto produtos = await _produtoService.AlterandoProdutoAsync(id, produto);
                return Ok(produtos);    
                
            }
            catch (Exception e)
            {
                // Retorna um erro se algo der errado
                return BadRequest(e.Message);
            }
        }



    }


}
