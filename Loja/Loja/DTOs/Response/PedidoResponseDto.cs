namespace Loja.DTOs.Response
{
    public class PedidoResponseDto
    {
        public int PedidoId { get; set; }
        public List<CaixaResponseDto> CaixasUsadas { get; set; } = new List<CaixaResponseDto>();
    }
}
