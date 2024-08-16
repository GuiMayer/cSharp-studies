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
        if (restaurantes.Count == 0) {Console.WriteLine("Não há nenhum restaurante cadastrado."); return;}

        Console.WriteLine("Digite o número do restaurante que deseja selecionar:");
        if (int.TryParse(Console.ReadLine() ?? "", out int index) && index > 0 && index < restaurantes.Count+1)
        {
            restauranteSelecionado = restaurantes[index-1];
            Console.WriteLine($"Restaurante {restauranteSelecionado.ObterNome()} selecionado.");
        }
        else
        {
            if (index < 0) {Console.WriteLine("Números de restaurante não podem ser negativos."); return;}
            Console.WriteLine("Restaurante inválido, tente novamente.");
        }
    }
    private static void ExcluirRestaurante()
    {
        MostrarRestaurantes();
        if (restaurantes.Count == 0) {Console.WriteLine("Não há nenhum restaurante cadastrado."); return;}

        Console.WriteLine("Digite o número do restaurante que deseja excluir:");
        if (int.TryParse(Console.ReadLine() ?? "", out int index) && index > 0 && index < restaurantes.Count+1)
        {
            
            Console.WriteLine($"Restaurante {restaurantes[index-1].ObterNome()} excluído.");
            restaurantes.RemoveAt(index-1);
        }
        else
        {
            if (index < 0) {Console.WriteLine("Números de restaurante não podem ser negativos."); return;}
            Console.WriteLine("Restaurante inválido, tente novamente.");
        }
        Console.WriteLine(index);
    }
    private static void MostrarRestaurantes()
    {
        if (restaurantes.Count == 0) {return;}
        Console.WriteLine("Restaurantes cadastrados:");
        for (int i = 0; i < restaurantes.Count; i++)
        {
            Console.WriteLine($"{i+1}: {restaurantes[i].ObterNome()}");
        }
    }
    private static void VerRestaurante()
    {
        Console.WriteLine($"Nome: {restauranteSelecionado.ObterNome()} Endereço: {restauranteSelecionado.ObterEndereco()}");
        Console.WriteLine($"Telefone: {restauranteSelecionado.ObterTelefone()}");
    }
    private static void VerCardapio()
    {
        if (restauranteSelecionado.ObterCardapio().Count() == 0) {
            Console.WriteLine("Não há pratos no cardápio.");
            return;
        } else {
            foreach (var prato in restauranteSelecionado.ObterCardapio()) {
                Console.WriteLine("Nome do Prato: " + prato.ObterNome() + " Preço: " + prato.ObterPreco() + " Vegetariano:" + prato.IsVegetariano());
            }
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
        Console.WriteLine("Digite S se o prato for vegetariano e N se ele não for.");
        string isVegetariano = Console.ReadLine() ?? "";
        if (isVegetariano.ToLower() == "sim" || isVegetariano.ToLower() == "s") {
            restauranteSelecionado.AdicionarPrato(new Prato(nomePrato, precoPrato, true));
        }
        else if (isVegetariano.ToLower() == "não" || isVegetariano == "nao" || isVegetariano.ToLower() == "n") {
            restauranteSelecionado.AdicionarPrato(new Prato(nomePrato, precoPrato, false));
        } else {
            Console.WriteLine("Por favor, digite sim ou não.");
        }
    }
    private static void RemoverPrato()
    {
        Console.WriteLine("Digite o nome do prato:");
        string nomePrato = Console.ReadLine() ?? "";
        if (restauranteSelecionado.RemoverPrato(nomePrato)) {
            Console.WriteLine($"Prato {nomePrato} removido.");
        } else {
            Console.WriteLine($"Prato {nomePrato} não existe.");
        }
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

                while (true) {
                    Console.WriteLine("1. Pedido presencial.");
                    Console.WriteLine("2. Pedido delivery.");
                    opcao = Console.ReadLine() ?? "";
                    if (opcao == "1" || opcao == "2") {
                        break;
                    }
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
    private static void VerPedidos() // imprime todos os pedidos
    {
        for (int i = 0; i < restauranteSelecionado.ObterPedidos().Count(); i++) {
            var pedido = restauranteSelecionado.ObterPedidos()[i];
            Console.WriteLine("Número do pedido: " + pedido.ObterNumeroPedido());
            Console.WriteLine("Lista de pratos do pedido:");
            foreach (var prato in pedido.ObterPratos()) {
                Console.WriteLine("Nome do prato: " + prato.ObterNome() + "  Valor do prato: " + prato.ObterPreco());
            }
            Console.WriteLine($"Valor total do pedido: {pedido.CalcularTotal()}");
            Console.WriteLine();
        }
    }
    private static void VerPedido() // imprime um pedido especifico
    {
        Console.WriteLine("Escreva o número do pedido: ");
        if (int.TryParse(Console.ReadLine() ?? "", out int opcao))
        {
            try {
                var pedido = restauranteSelecionado.ObterPedidos()[opcao-1];
                Console.WriteLine("Número do pedido: " + pedido.ObterNumeroPedido());
                Console.WriteLine("Lista de pratos do pedido:");
                foreach (var prato in pedido.ObterPratos()) {
                    Console.WriteLine("Nome do prato: " + prato.ObterNome() + "  Valor do prato: " + prato.ObterPreco());
                }
                Console.WriteLine();
            }
            catch (ArgumentOutOfRangeException) {
                Console.WriteLine("Número de pedido inexistente.");
            }
        }
        else {
            Console.WriteLine("Número do pedido inválido.");
        }
    }
}
