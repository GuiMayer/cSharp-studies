using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    private static List<Restaurante> restaurantes = new List<Restaurante>();
    private static Restaurante? restauranteSelecionado = null;
    static void Main()
    {
        string? opcao;
        restaurantes.Add(new Restaurante("Restaurante Gatitos", "Rua Neko 123", "(42) 94002-8922")); // teste
        while (true) // loop principal do programa
        {
            if (restauranteSelecionado == null)
            {
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1. Cadastrar novo restaurante.");
                Console.WriteLine("2. Escolher Restaurante.");
                Console.WriteLine("3. Excluir Restaurante.");
                Console.WriteLine("0. Sair do programa.");
                opcao = Console.ReadLine() ?? "";

                switch (opcao)
                {
                    case "1":
                        CadastrarRestaurante();
                        break;

                    case "2":
                        EscolherRestaurante();
                        break;

                    case "3":
                        ExcluirRestaurante();
                        break;

                    case "0":
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Opção inválida, tente novamente.");
                        break;
                }
            }
            else
            {
                while (restauranteSelecionado != null) {

                    Console.WriteLine("Escolha uma opção:");
                    Console.WriteLine("1. Ver informações do restaurante.");
                    Console.WriteLine("2. Ver cardápio.");
                    Console.WriteLine("3. Cadastrar prato no cardápio.");
                    Console.WriteLine("4. Remover prato do cardápio.");
                    Console.WriteLine("5. Adicionar pedido.");
                    Console.WriteLine("6. Ver pedido.");
                    Console.WriteLine("7. Ver todos os pedidos.");
                    Console.WriteLine("0. Sair");
                    opcao = Console.ReadLine() ?? "";

                    switch (opcao)
                    {
                        case "1":
                            VerRestaurante();
                            break;
                        case "2":
                            VerCardapio();
                            break;

                        case "3":
                            CadastrarPrato();
                            break;

                        case "4":
                            RemoverPrato();
                            break;

                        case "5":
                            AdicionarPedido();
                            break;

                        case "6":
                            VerPedido();
                            break;

                        case "7":
                            VerPedidos();
                            break;

                        case "0":
                            restauranteSelecionado = null;
                            break;
                            
                        default:
                            Console.WriteLine("Opção inválida, tente novamente.");
                            break;
                    }
                }
            }
        }
    }

    private static void CadastrarRestaurante()
    {
        Console.WriteLine("Digite o nome do restaurante: ");
        string? nomeRestaurante = Console.ReadLine() ?? "";
        Console.WriteLine("Digite o endereço do restaurante: ");
        string? enderecoRestaurante = Console.ReadLine() ?? "";
        Console.WriteLine("Digite o telefone do restaurante (xx) xxxxx-xxxx: ");
        string? telefoneRestaurante = Console.ReadLine() ?? "";

        restaurantes.Add(new Restaurante(nomeRestaurante, enderecoRestaurante, telefoneRestaurante));
    }
    private static void EscolherRestaurante()
    {
        MostrarRestaurantes();

        Console.WriteLine("Digite o número do restaurante que deseja selecionar:");
        if (int.TryParse(Console.ReadLine() ?? "", out int index) && index >= 0 && index < restaurantes.Count)
        {
            restauranteSelecionado = restaurantes[index];
            Console.WriteLine($"Restaurante {restauranteSelecionado.ObterNome()} selecionado.");
        }
        else
        {
            Console.WriteLine("Restaurante inválido, tente novamente.");
        }
    }
    private static void ExcluirRestaurante()
    {
        MostrarRestaurantes();

        Console.WriteLine("Digite o número do restaurante que deseja excluir:");
        if (int.TryParse(Console.ReadLine() ?? "", out int index) && index >= 0 && index < restaurantes.Count)
        {
            Console.WriteLine($"Restaurante {restaurantes[index].ObterNome()} excluído.");
            restaurantes.RemoveAt(index);
        }
        else
        {
            Console.WriteLine("Restaurante inválido, tente novamente.");
        }
    }
    private static void MostrarRestaurantes()
    {
        Console.WriteLine("Restaurantes cadastrados:");
        for (int i = 0; i < restaurantes.Count; i++)
        {
            Console.WriteLine($"{i}: {restaurantes[i].ObterNome()}");
        }
    }
    private static void VerRestaurante()
    {
        Console.WriteLine($"Nome: {restauranteSelecionado.ObterNome()} Endereço: {restauranteSelecionado.ObterEndereco()}");
        Console.WriteLine($"Telefone: {restauranteSelecionado.ObterNome()}");
    }
    private static void VerCardapio()
    {
        foreach (var prato in restauranteSelecionado.ObterCardapio()) {
            Console.WriteLine("Nome do Prato: " + prato.ObterNome() + " Preço: " + prato.ObterPreco() + " Vegetariano:" + prato.IsVegetariano());
        }
    }
    private static void CadastrarPrato()
    {
        Console.WriteLine("Nome do prato:");
        string nomePrato = Console.ReadLine() ?? "";
        Console.WriteLine("Digite o preço do prato:");
        if (!decimal.TryParse(Console.ReadLine() ?? "", out decimal precoPrato)) {
            Console.WriteLine("Preço inválido!");
        }
        Console.WriteLine("Digite sim se o prato for vegetariano e não se ele não for.");
        string isVegetariano = Console.ReadLine() ?? "";
        if (isVegetariano.ToLower() == "sim") {
            restauranteSelecionado.AdicionarPrato(new Prato(nomePrato, precoPrato, true));
        }
        else if (isVegetariano.ToLower() == "não" | isVegetariano == "nao") {
            restauranteSelecionado.AdicionarPrato(new Prato(nomePrato, precoPrato, true));
        } else {
            Console.WriteLine("Por favor, digite sim ou não.");
        }
    }
    private static void RemoverPrato()
    {
        Console.WriteLine("Digite o nome do prato:");
        string nomePrato = Console.ReadLine() ?? "";
        restauranteSelecionado.RemoverPrato(nomePrato);
    }
    private static void AdicionarPedido()
    {
        List<Prato> pratosPedido = new List<Prato>();
        Prato prato;
        bool continuar = true;
        string opcao = "";
        while (continuar) {
            Console.WriteLine("Digite o nome do prato:");
            string nomePrato = Console.ReadLine() ?? "";
            if (restauranteSelecionado.BuscarPrato(nomePrato) != null) {
                prato = restauranteSelecionado.BuscarPrato(nomePrato);
                pratosPedido.Add(prato);
            } else {
                Console.WriteLine("Este prato não existe no cardápio.");
            }

            Console.WriteLine("0. Adicionar mais um prato.");
            if (!((Console.ReadLine() ?? "") == "0")) {
                continuar = false;

                while (opcao != "1" | opcao != "2") {
                    Console.WriteLine("1. Pedido presencial.");
                    Console.WriteLine("2. Pedido delivery.");
                }
                
                switch (opcao) {
                    case "1":
                        restauranteSelecionado.AdicionarPedidoPresencial(pratosPedido);
                        break;

                    case "2":
                        restauranteSelecionado.AdicionarPedidoDelivery(pratosPedido);
                        break;
                }

                
            }
            
        }
    }
    private static void VerPedido()
    {
        restauranteSelecionado.VerPedido();
    }
    private static void VerPedidos()
    {
        Console.WriteLine("Escreva o número do pedido: ");
        if (int.TryParse(Console.ReadLine() ?? "", out int opcao))
        {
            restauranteSelecionado.VerPedido(opcao - 1);
        }
        else {
            Console.WriteLine("Número do pedido inválido.");
        }
    }
}
