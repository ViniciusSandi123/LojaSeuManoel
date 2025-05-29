using Loja.Data;
using Loja.DTOs.Request;
using Loja.DTOs.Response;
using Loja.Models;
using System;

namespace Loja.Services
{
    public class EmbalarService
    {
        private readonly Context _context;
        private readonly List<Caixa> caixasDisponiveis = new List<Caixa>()
        {
            new Caixa { Id = 1, Altura = 30, Largura = 40, Comprimento = 80 },
            new Caixa { Id = 2, Altura = 80, Largura = 50, Comprimento = 40 },
            new Caixa { Id = 3, Altura = 50, Largura = 80, Comprimento = 60 },
        };

        public EmbalarService(Context context)
        {
            _context = context;
        }

        public PedidoResponseDto Embalar(int id, PedidoRequestDto pedidoDto)
        {
            var caixasUsadas = new List<CaixaResponseDto>();

            foreach (var produtos in pedidoDto.Produtos)
            {
                var produto = new Produto
                {
                    Nome = produtos.Nome,
                    Altura = produtos.Altura,
                    Largura = produtos.Largura,
                    Comprimento = produtos.Comprimento,
                };

                if (produto.Altura <= 0 || produto.Largura <= 0 || produto.Comprimento <= 0)
                {
                    throw new Exception($"Dimensões inválidas para o produto {produto.Nome}");
                }

                var caixaCerta = caixasDisponiveis
                    .OrderBy(c => c.Volume)
                    .FirstOrDefault(c => c.Embala(produto));

                if (caixaCerta == null)
                {
                    throw new Exception($"Nenhuma caixa consegue embalar o produto {produto.Nome}");
                }

                var caixasExistente = caixasUsadas
                    .FirstOrDefault(c => c.TipoCaixa == $"Caixa {caixaCerta.Id}");

                if(caixasExistente == null)
                {
                    caixasExistente = new CaixaResponseDto
                    {
                        TipoCaixa = $"Caixa {caixaCerta.Id}"
                    };
                    caixasUsadas.Add(caixasExistente);
                }

                caixasExistente.Produtos.Add(new ProdutoResponseDto
                {
                    Nome = produto.Nome,
                    Altura = produto.Altura,
                    Largura = produto.Largura,
                    Comprimento = produto.Comprimento,
                });
            }

            var pedido = new Pedido
            {
                Produtos = pedidoDto.Produtos.Select(p => new Produto
                {
                    Nome = p.Nome,
                    Altura = p.Altura,
                    Largura = p.Largura,
                    Comprimento = p.Comprimento,
                }).ToList()
            };

            _context.Pedidos.Add(pedido);
            _context.SaveChanges();

            return new PedidoResponseDto
            {
                PedidoId = pedido.Id,
                CaixasUsadas = caixasUsadas
            };
        }
    }
}
