using CadastroDeProduosAPI.Models;
using CadastroDeProduosAPI.Models.Produto;
using Microsoft.EntityFrameworkCore;




namespace CadastroDeProduosAPI.Repositorios.Produtos
{
    public class ProdutoRepository : IProdutoRepository
    {

        private readonly Contexto _contexto;

        public ProdutoRepository(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<Produto> AdicionarProdutoAsync(Produto produto)
        {
            if (produto == null)
            {
                throw new ArgumentNullException(nameof(produto), "Produto não pode ser nulo.");
            }

            try
            {
                // Definindo as datas, se necessário
                produto.CreateDate = DateTime.Now;
                produto.UpdateDate = DateTime.Now;
                Produto produtoTeste = produto;

                _contexto.Produtos.Add(produto);
                await _contexto.SaveChangesAsync();
                return produto;
            }
            catch (Exception ex)
            {
                // Log detalhado da exceção
                Console.WriteLine($"Ocorreu um erro: {ex.Message}");
                throw;
            }
        }

        public async Task<List<Produto>> ListarProdutoAsync()
        {
            List<Produto> produtos = await _contexto.Produtos.ToListAsync();
            return produtos == null ? null : produtos;
        }
        public async Task<Produto> VerificarProdutoAsync(int id)
        {
            Produto produto = await _contexto.Produtos.FindAsync(id);
            return produto == null ? null : produto;    
        }
         public async Task<Produto> DeletarProdutoAsync(int id)
        {
            var produto = await _contexto.Produtos.FindAsync(id);
            if (produto == null)
            {
                return null; 
            }

            _contexto.Produtos.Remove(produto);
            await _contexto.SaveChangesAsync();
            return produto; 
        }

        public async Task<Produto> AlterarProdutoAsync(Produto produto)
        {

            _contexto.Produtos.Update(produto);
            await _contexto.SaveChangesAsync();
            return produto;

        }

    }
}
