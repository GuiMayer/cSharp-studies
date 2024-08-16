using System;
using System.Collections.Specialized;
using System.Data.Common;
class Restaurante : Estabelecimento
{
    private List<Prato> cardapio;
    private List<PedidoAbstrato> pedidos = new List<PedidoAbstrato>();
    
    public Restaurante(string nome, string endereco, string telefone)
        : base(nome, endereco, telefone) 
    {
        cardapio = new List<Prato>();
    }
    public Restaurante(string nome, string endereco, string telefone, Prato prato)
        : base(nome, endereco, telefone) 
    {
        cardapio = new List<Prato>();
        if (prato != null)
        {
            cardapio.Add(prato);
        }
    }
    public Restaurante(string nome, string endereco, string telefone, List<Prato> pratos)
        : base(nome, endereco, telefone) 
    {
        cardapio = new List<Prato>();
        foreach (var prato in pratos) {
            if (prato != null) {
                cardapio.Add(prato);
            }
        }
    }

    public void AdicionarPedidoDelivery(List<Prato> pratos)
    {
        PedidoDelivery pedidoDelivery = new PedidoDelivery();
        foreach (var prato in pratos) {
            pedidoDelivery.AdicionarPrato(prato);
        }
        pedidos.Add(pedidoDelivery);
    }
    public void AdicionarPedidoPresencial(List<Prato> pratos)
    {
        PedidoPresencial pedidoPresencial = new PedidoPresencial();
        foreach (var prato in pratos) {
            pedidoPresencial.AdicionarPrato(prato);
        }
        pedidos.Add(pedidoPresencial);
    }
    public List<PedidoAbstrato> ObterPedidos()
    {
        return pedidos;
    }
    public void AdicionarPrato(Prato prato)
    {
        cardapio.Add(prato);
    }
    public bool RemoverPrato(string nomePrato)
    {
        if (cardapio.RemoveAll(p => p.ObterNome().ToLower() == nomePrato.ToLower()) == 0) {
            return false;
        } else {
            return true;
        }
    }
    public Prato? BuscarPrato(string nomePrato)
    {
        return cardapio.Find(item => item.ObterNome().ToLower() == nomePrato.ToLower());
    }
    public List<Prato> ObterCardapio()
    {
        return cardapio;
    }
}