using System;
using System.Data.Common;
class Restaurante : Estabelecimento
{
    private List<Prato> cardapio;
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
    public void AdicionarPrato(Prato prato)
    {
        cardapio.Add(prato);
    }
    public void RemoverPrato(string nomePrato)
    {
        cardapio.RemoveAll(p => p.ObterNome() == nomePrato);
    }
    public List<Prato> ObterCardapio()
    {
        return cardapio;
    }
}