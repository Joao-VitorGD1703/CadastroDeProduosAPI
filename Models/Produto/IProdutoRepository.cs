namespace CadastroDeProduosAPI.Models.Produto
{
    public interface IProdutoRepository
    {
        Task<Produto> AdicionarProdutoAsync(Produto produto);
        Task<List<Produto>> ListarProdutoAsync();
        Task<Produto> VerificarProdutoAsync(int id);
        Task<Produto> DeletarProdutoAsync(int id);
        Task<Produto> AlterarProdutoAsync(Produto produto);
    }

}
