﻿namespace Loja.Models
{
    public class Caixa
    {
        public int Id { get; set; }
        public int Altura { get; set; }
        public int Largura { get; set; }
        public int Comprimento { get; set; }
        public int Volume => Altura * Largura * Comprimento;

        public bool Embala(Produto produto)
        {
            return produto.Altura  <= Altura &&
                   produto.Largura <= Largura &&
                   produto.Comprimento <= Comprimento;
        }
    }
}
