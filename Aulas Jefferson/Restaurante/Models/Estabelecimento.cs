using System;
using System.Dynamic;
using System.Text.RegularExpressions;

class Estabelecimento
{
    private string nome;
    private string endereco;
    private string telefone;

    public Estabelecimento(string nome, string endereco, string telefone)
    {
        this.nome = nome;
        this.endereco = endereco;
        if (VerificarFormatoTelefone(telefone)) {
            this.telefone = telefone;
        }
        else {
            Console.WriteLine("Formato de telefone inválido.");
            this.telefone = "";
        }
    }

    private bool VerificarFormatoTelefone(string telefone)
    {
        string padrao = @"^\(?\d{2}\)?\s?\d{5}-?\d{4}$";
        return Regex.IsMatch(telefone, padrao);
    }
    public string ObterNome()
    {
        return nome;
    }
    public void AtualizarNome(string nome)
    {
        this.nome = nome;
    }
    public string ObterEndereco()
    {
        return endereco;
    }
    public void AtualizarEndereco(string endereco)
    {
        this.endereco = endereco;
    }
    public string ObterTelefone()
    {
        return telefone;
    }
    public void AtualizarTelefone(string telefone)
    {
        if (VerificarFormatoTelefone(telefone)) {
            this.telefone = telefone;
        }
        else {
            Console.WriteLine("Formato de telefone inválido.");
        }
    }
}