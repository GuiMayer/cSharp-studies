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
    public void VerPedido() // imprime todos os pedidos
    {
        for (int i = 0; i < pedidos.Count(); i++) {
            VerPedido(i);
        }
    }
    public void VerPedido(int index)
    {
        var pedido = pedidos[index];
        Console.WriteLine("Número do pedido: " + pedido.ObterNumeroPedido());
        Console.WriteLine("Lista de pratos do pedido:");
        foreach (var prato in pedido.ObterPratos()) {
            Console.WriteLine("Nome do prato: " + prato.ObterNome() + "  Valor do prato: " + prato.ObterPreco());
        }
        Console.WriteLine();
        
    }
    public void AdicionarPrato(Prato prato)
    {
        cardapio.Add(prato);
    }
    public void RemoverPrato(string nomePrato)
    {
        cardapio.RemoveAll(p => p.ObterNome().ToLower() == nomePrato.ToLower());
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