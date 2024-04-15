using System;

class Program
{
    static void Main(string[] args)
    {
        Student bruna = new Student("Bruna Camila Silveira", 20, 8, 2005);
        Student guilherme = new Student("Guilherme Mayer dos Santos", 17, 2, 2005);
        Console.WriteLine(bruna.GetAge());
        Console.WriteLine(guilherme.GetAge());
    }
}