﻿using System;
using NerdStore.Core.DomainObjects;

namespace NerdStore.Vendas.Domain
{
    public class PedidoItem : Entity
    {
        public Guid PedidoId { get; private set; }

        // Como só utilizamos a propriedade ProdutoNome, não precisamos criar uma nova classe Produto nesse contexto. Caso fossem mais propriedades,
        // valeria a pena criar uma nova Entidade.
        public Guid ProdutoId { get; private set; }
        public string ProdutoNome { get; private set; }
        public int Quantidade { get; private set; }
        public decimal ValorUnitario { get; private set; }
        
        // EF Rel.
        public Pedido Pedido { get; set; }

        public PedidoItem(Guid produtoId, string produtoNome, int quantidade, decimal valorUnitario)
        {
            ProdutoId = produtoId;
            ProdutoNome = produtoNome;
            Quantidade = quantidade;
            ValorUnitario = valorUnitario;
        }

        // Necessário para o EF
        protected PedidoItem() { }

        internal void AssociarPedido(Guid pedidoId)
        {
            PedidoId = pedidoId;
        }

        public decimal CalcularValor()
        {
            return Quantidade * ValorUnitario;
        }

        internal void AdicionarUnidades(int unidades)
        {
            Quantidade += unidades;
        }

        internal void AtualizarUnidades(int unidades)
        {
            Quantidade = unidades;
        }

        public override bool EhValido()
        {
            return true;
        }
    }
}