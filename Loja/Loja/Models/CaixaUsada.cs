namespace Loja.Models
{
    public class CaixaUsada
    {
        public int Id { get; set; }
        public Caixa Caixa { get; set; }
        public List<Produto> Produtos { get; set; } = new List<Produto>();
    }
}
