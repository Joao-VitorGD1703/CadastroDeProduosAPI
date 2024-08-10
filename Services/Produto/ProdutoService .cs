
using CadastroDeProduosAPI.Models.Produto;


namespace CadastroDeProduosAPI.Services.Produtos
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<Produto> CriarProdutoAsync(Produto produto)
        {
            return await _produtoRepository.AdicionarProdutoAsync(produto);
        }
        public async Task<List<Produto>> ListagemProdutosAsync()
        {
            return await _produtoRepository.ListarProdutoAsync();
        }
        public async Task<Produto> VerificaProdutoAsync(int id)
        {
            return await _produtoRepository.VerificarProdutoAsync(id);  
        }
        public async Task<Produto> DeletandoProdutoAsync(int id)
        {
            return await _produtoRepository.DeletarProdutoAsync(id);
        }
        public async Task<Produto> AlterandoProdutoAsync(int id, Produto produto)
        {
            var produtoExistente = await VerificaProdutoAsync(id);

            // Verifica se o produto existe
            if (produtoExistente == null)
            {
                return null;
            }

            
            produtoExistente.Nome = produto.Nome;
            produtoExistente.Descricao = produto.Descricao;
            produtoExistente.Preco = produto.Preco;
            produtoExistente.QuantidadeEmEstoque = produto.QuantidadeEmEstoque;
            produtoExistente.Sku = produto.Sku;
            produtoExistente.Marca = produto.Marca;
            produtoExistente.UpdateDate = DateTime.Now;

            return await _produtoRepository.AlterarProdutoAsync(produtoExistente);

            
        }
    }
}
