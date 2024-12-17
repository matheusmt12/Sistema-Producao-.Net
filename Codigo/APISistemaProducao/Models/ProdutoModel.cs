namespace APISistemaProducao.Models
{
    public class ProdutoModel
    {
        public int IdProduto { get; set; }

        public string NomeProduto { get; set; } = null!;

        public decimal Valor { get; set; }

        public int Estoque { get; set; }
    }
}
