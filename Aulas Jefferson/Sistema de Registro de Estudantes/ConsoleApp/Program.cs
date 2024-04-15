using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Criando um objeto Student
        Student student = new Student("John", 15, 4, 2000);

        // Adicionando algumas notas
        student.AddGrade(85);
        student.AddGrade(90);
        student.AddGrade(75);

        // Testando métodos da classe Student
        Console.WriteLine("Nome: " + student.name);
        Console.WriteLine("Idade: " + student.GetAge());
        Console.WriteLine("Quantidade de notas: " + student.CountGrades());
        Console.WriteLine("Notas do aluno:");
        foreach (float grade in student.GetGrades())
        {
            Console.WriteLine("- " + grade);
        }
        Console.WriteLine("Média das notas: " + student.CalcAvarage());

        // Removendo a última nota
        student.RemoveLastGrade();

        // Testando novamente após a remoção
        Console.WriteLine("Quantidade de notas após remover a última: " + student.CountGrades());
        Console.WriteLine("Notas do aluno após remover a última:");
        foreach (float grade in student.GetGrades())
        {
            Console.WriteLine("- " + grade);
        }

        // Removendo todas as notas
        student.RemoveAllGrades();

        // Testando novamente após a remoção de todas as notas
        Console.WriteLine("Quantidade de notas após remover todas: " + student.CountGrades());

        // Definindo nova data de nascimento
        student.SetBirthDate(1, 1, 2002);
        Console.WriteLine("Nova idade após definir nova data de nascimento: " + student.GetAge());
    }
}
