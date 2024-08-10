namespace CadastroDeProduosAPI.Models.Produto
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public double Preco { get; set; }
        public int QuantidadeEmEstoque { get; set; }
        public int Sku { get; set; }
        public string Marca { get; set; } = string.Empty;
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }

    }
}
