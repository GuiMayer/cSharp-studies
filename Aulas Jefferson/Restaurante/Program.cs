using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Criando pratos
        Prato prato1 = new Prato("Lasanha", 25.0m, false);
        Prato prato2 = new Prato("Salada", 15.0m, true);
        Prato prato3 = new Prato("Pizza", 30.0m, false);

        // Testando a classe Estabelecimento
        Estabelecimento estabelecimento = new Estabelecimento("Restaurante Bom Sabor", "Rua das Flores, 123", "(11) 98765-4321");
        Console.WriteLine($"Nome do estabelecimento: {estabelecimento.ObterNome()}");
        Console.WriteLine($"Endereço: {estabelecimento.ObterEndereco()}");
        Console.WriteLine($"Telefone: {estabelecimento.ObterTelefone()}");

        // Testando a classe Restaurante
        List<Prato> cardapio = new List<Prato> { prato1, prato2 };
        Restaurante restaurante = new Restaurante("Restaurante Bom Sabor", "Rua das Flores, 123", "(11) 98765-4321", cardapio);

        restaurante.AdicionarPrato(prato3);

        Console.WriteLine("\nCardápio do Restaurante:");
        foreach (var prato in restaurante.ObterCardapio())
        {
            Console.WriteLine($"{prato.ObterNome()} - R$ {prato.ObterPreco()}");
        }

        restaurante.RemoverPrato("Salada");
        Console.WriteLine("\nCardápio após remover 'Salada':");
        foreach (var prato in restaurante.ObterCardapio())
        {
            Console.WriteLine($"{prato.ObterNome()} - R$ {prato.ObterPreco()}");
        }

        // Testando a classe PedidoDelivery
        PedidoDelivery pedidoDelivery = new PedidoDelivery(prato1);
        pedidoDelivery.AdicionarPrato(prato2);
        Console.WriteLine($"\nTotal do Pedido Delivery: R$ {pedidoDelivery.CalcularTotal()}");

        // Testando a classe PedidoPresencial
        PedidoPresencial pedidoPresencial = new PedidoPresencial(prato3);
        pedidoPresencial.AdicionarPrato(prato1);
        Console.WriteLine($"Total do Pedido Presencial: R$ {pedidoPresencial.CalcularTotal()}");
    }
}
