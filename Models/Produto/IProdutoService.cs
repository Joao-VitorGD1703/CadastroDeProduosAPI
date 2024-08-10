using CadastroDeProduosAPI.Models.Produto;

namespace CadastroDeProduosAPI.Models.Produto
{
    public interface IProdutoService
    {
        Task<Produto> CriarProdutoAsync(Produto produto);
        Task<List<Produto>> ListagemProdutosAsync();
        Task<Produto> VerificaProdutoAsync(int id);
        Task<Produto> DeletandoProdutoAsync(int id);
        Task<Produto> AlterandoProdutoAsync(int id, Produto produto);   
    }
}
