﻿namespace Loja.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public List<Produto> Produtos { get; set; } = new List<Produto>();
    }
}
