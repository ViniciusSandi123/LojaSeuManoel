namespace Loja.DTOs.Response
{
    public class ProdutoResponseDto
    {
        public string Nome { get; set; } = string.Empty;
        public int Altura { get; set; }
        public int Largura { get; set; }
        public int Comprimento { get; set; }
    }
}
