using System.Runtime.CompilerServices;

class Prato
{
    private string nome;
    private decimal preco;
    private bool isVegetariano;
    public Prato(string nome, decimal preco, bool isVegetariano)
    {
        this.nome = nome;
        if(preco >= 0) {
            this.preco = preco;
        } else {
            Console.WriteLine("Número inválido, o preço deve ser um número positivo.");
            this.preco = 0;
        }
        this.isVegetariano = isVegetariano;
    }
    public string ObterNome()
    {
        return nome;
    }
    public void AtualizarNome(string nome)
    {
        this.nome = nome;
    }
    public decimal ObterPreco()
    {
        return preco;
    }
    public void AtualizarPreco(decimal preco)
    {
        if(preco >= 0) {
            this.preco = preco;
        } else {
            Console.WriteLine("Número inválido, o preço deve ser um número positivo.");
        }
    }
    
}