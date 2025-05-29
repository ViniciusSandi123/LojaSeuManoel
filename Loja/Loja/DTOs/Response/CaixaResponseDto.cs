namespace Loja.DTOs.Response
{
    public class CaixaResponseDto
    {
        public string TipoCaixa { get; set; } = string.Empty;
        public List<ProdutoResponseDto> Produtos { get; set; } = new List<ProdutoResponseDto>();
    }
}
