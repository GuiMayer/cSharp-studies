using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Student> students = StudentFactory.CreateStudents(10);

        JsonSerializer jsonSerializer = new JsonSerializer("data.json");

        jsonSerializer.SerializeList(students);
        
    }
}

class StudentsManagement
{
    static void PrintStudents(List<Student> students)
    {
        foreach (Student student in students)
        {
            Console.WriteLine("ID: {0}", student.GetId());
            Console.WriteLine("Nome: {0}", student.GetName());
            Console.WriteLine("Número de Matrícula: {0}", student.GetRegistrationNumber());
            Console.WriteLine("Data de Nascimento: {0}", student.GetBirthDate());
            Console.WriteLine("Curso: {0}", student.GetCourse());
            Console.WriteLine("Idade: {0}", student.GetAge());
            Console.WriteLine("---------------------------------------------"); // Adiciona uma linha em branco para separar os estudantes
        }
    }
}

class StudentFactory
{
    private static Random rand = new Random();

    public static List<Student> CreateStudents(int count)
    {
        List<Student> students = new List<Student>();

        for (int i = 0; i < count; i++)
        {
            // Gerando informações aleatórias para os estudantes
            int registrationNumber = 1000 + i;
            string name = GenerateRandomName();
            int dayBirth = GenerateRandomDay();
            int monthBirth = GenerateRandomMonth();
            int yearBirth = GenerateRandomYear();
            string course = GenerateRandomCourse();

            // Criando e adicionando o estudante à lista
            Student student = new Student(registrationNumber, name, dayBirth, monthBirth, yearBirth, course);
            students.Add(student);
        }

        return students;
    }

    // Função para gerar um nome aleatório
    private static string GenerateRandomName()
    {
        string[] firstNames = { "Maria", "João", "Ana", "Pedro", "Mariana", "Lucas", "Carolina", "Gabriel", "Juliana", "Marcos", "Luiza", "Rafael", "Camila", "Matheus", "Isabela", "Gustavo", "Letícia", "Thiago", "Amanda", "Fernando" };
        string[] lastNames = { "Silva", "Santos", "Oliveira", "Pereira", "Souza", "Ferreira", "Almeida", "Costa", "Rodrigues", "Nascimento", "Lima", "Araujo", "Carvalho", "Gomes", "Martins", "Rocha", "Ribeiro", "Alves", "Monteiro", "Mendes" };
        string firstName = firstNames[rand.Next(firstNames.Length)];
        string lastName = lastNames[rand.Next(lastNames.Length)];
        return firstName + " " + lastName;
    }

    // Função para gerar um dia de nascimento aleatório
    private static int GenerateRandomDay()
    {
        return rand.Next(1, 29); // Vamos limitar até o dia 28 para simplificar
    }

    // Função para gerar um mês de nascimento aleatório
    private static int GenerateRandomMonth()
    {
        return rand.Next(1, 13); // De janeiro (1) a dezembro (12)
    }

    // Função para gerar um ano de nascimento aleatório
    private static int GenerateRandomYear()
    {
        return rand.Next(1990, 2005); // Vamos limitar entre 1990 e 2004 para ter estudantes com idades realistas
    }

    // Função para gerar um curso aleatório
    private static string GenerateRandomCourse()
    {
        string[] courses = { "Engenharia", "Medicina", "Administração", "Direito", "Ciência da Computação", "Psicologia", "Economia", "Arquitetura", "Biologia", "Artes", "Matemática", "Física", "Química", "Educação Física", "Geografia", "História", "Letras", "Sociologia", "Filosofia", "Nutrição" };
        return courses[rand.Next(courses.Length)];
    }
}
