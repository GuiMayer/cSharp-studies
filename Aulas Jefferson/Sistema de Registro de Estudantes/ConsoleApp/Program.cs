using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.Design;

class Interface // classe responsável pelo loop principal do programa
{
    private List<Student> studentsList;

    public Interface() // Construtor da classe
    {
        studentsList = new List<Student>();
    }
    public int MainMenu() // Menu principal do programa
    {
        Console.WriteLine("Escolha uma opção:");
        Console.WriteLine("1. Ver todos os estudantes.");
        Console.WriteLine("2. Consultar estudante pelo ID.");
        Console.WriteLine("3. Inserir novo estudante.");
        Console.WriteLine("4. Inserir nova nota para o estudante pelo ID.");
        Console.WriteLine("5. Exibir a média das notas de cada estudante.");
        Console.WriteLine("6. Encerrar o programa.");
        string choice = Console.ReadLine();
        int result;
        int.TryParse(choice, out result);
        return result;
    }

    public void Choice() // Escolha da ação a ser realizada no programa
    {
        switch (MainMenu())
        {
            case 0:
                Console.WriteLine("Por favor insira um número válido!");
                Choice();
                break;
            case 1:
                foreach (Student student in studentsList)
                {
                    Console.WriteLine("ID:" + student.GetId() + ", Nome:" + student.GetName() + ", Idade: " + student.GetAge());
                }
                Console.WriteLine("");
                break;
            case 2:
                Console.WriteLine("Insira o ID do aluno:");
                string idChosen = Console.ReadLine();
                foreach (Student student in studentsList)
                {
                    if (student.GetId() == Convert.ToInt32(idChosen)){
                        Console.WriteLine("ID: " + student.GetId() + ", Nome: " + student.GetName() + ", Idade: " + student.GetAge());
                        Console.WriteLine("Número de matrícula: " + student.GetRegistrationNumber() + ", Curso:" + student.GetCourse() + ", Data de nascimento: " + student.GetBirthDate());
                        break;
                    }
                }
                // Console.WriteLine("Aluno não encontrado.");
                break;
            case 3:
                Console.WriteLine("Insira o nome do estudante:");
                string tempName = Console.ReadLine();

                Console.WriteLine("Insira o dia, mês e ano de nascimento do estudante, separado por Enter:");
                string tempChoice = Console.ReadLine();
                int tempDay = Convert.ToInt32(tempChoice);

                tempChoice = Console.ReadLine();
                int tempMonth = Convert.ToInt32(tempChoice);

                tempChoice = Console.ReadLine();
                int tempYear = Convert.ToInt32(tempChoice);

                Console.WriteLine("Insira o número de matrícula do estudante:");
                string tempNumber = Console.ReadLine();
                int tempRegistrationNumber = Convert.ToInt32(tempNumber);

                Console.WriteLine("Insira o curso do estudante:");
                string tempCourse = Console.ReadLine();

                studentsList.Add(new Student(tempRegistrationNumber, tempName, tempDay, tempMonth, tempYear, tempCourse));
                
                break;
            case 4:
                Console.WriteLine("Insira o ID do aluno:");
                string idChosen2 = Console.ReadLine();
                foreach (Student student in studentsList)
                {
                    if (student.GetId() == Convert.ToInt32(idChosen2)){
                        Console.WriteLine("Insira a nota do aluno:");
                        string newGrade = Console.ReadLine();
                        float tempGrade = (float)Convert.ToDouble(newGrade);
                        student.AddGrade(tempGrade);
                        break;
                    }
                }
                // Console.WriteLine("Aluno não encontrado.");
                break;
            case 5:
                foreach (Student student in studentsList)
                {
                    Console.WriteLine("ID: " + student.GetId() + "Número de matrícula: " + student.GetRegistrationNumber() + ", Nome: " + student.GetName() + ", Média: " + student.CalcAvarage());
                }
                break;
            case 6:
                Environment.Exit(0);
                break;
        }
    }

    public void Begin()
    {
        while (true){
            this.Choice();
        }
        
    }
}

class Program
{
    static void Main(string[] args)
    {
        Interface inter = new Interface();
        inter.Begin();
    }
}
