using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Linq;

namespace StudentManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Interface userInterface = new Interface();
            userInterface.Begin();
        }
    }

    class FileSaveManager
    {
        public static void LoadStudentsListFromJsonFile(List<Student> studentsList, string filePath)
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                studentsList = JsonConvert.DeserializeObject<List<Student>>(json);
            }
        }

        public static void SaveStudentListToJson(List<Student> studentsList, string filePath)
        {
            string json = JsonConvert.SerializeObject(studentsList, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }
    }

    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime BirthDate { get; set; }
        public int RegistrationNumber { get; set; }
        public string Course { get; set; }
        public List<float> Grades { get; set; }

        public Student(int id, string name, int day, int month, int year, int registrationNumber, string course)
        {
            Id = id;
            Name = name;
            BirthDate = new DateTime(year, month, day);
            RegistrationNumber = registrationNumber;
            Course = course;
            Grades = new List<float>();
        }

        public void AddGrade(float grade)
        {
            Grades.Add(grade);
        }

        public void RemoveGradeAt(int index)
        {
            if (index >= 0 && index < Grades.Count)
            {
                Grades.RemoveAt(index);
            }
            else
            {
                Console.WriteLine("Índice inválido.");
            }
        }

        public void RemoveAllGrades()
        {
            Grades.Clear();
        }

        public void ChangeGradeAt(float newGrade, int index)
        {
            if (index >= 0 && index < Grades.Count)
            {
                Grades[index] = newGrade;
            }
            else
            {
                Console.WriteLine("Índice inválido.");
            }
        }

        public float CalcAverage()
        {
            float sum = 0;
            foreach (float grade in Grades)
            {
                sum += grade;
            }
            return Grades.Count > 0 ? sum / Grades.Count : 0;
        }
    }

    class Interface
    {
        private List<Student> studentsList;
        private string filePath = "save.json";

        public Interface()
        {
            studentsList = new List<Student>();
            FileSaveManager.LoadStudentsListFromJsonFile(studentsList, filePath);
        }

        public void Mainmenu()
        {
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("1. Ver todos os estudantes.");
            Console.WriteLine("2. Consultar estudante pelo ID.");
            Console.WriteLine("3. Consultar notas do estudante pelo ID.");
            Console.WriteLine("4. Inserir novo estudante.");
            Console.WriteLine("5. Inserir nova nota para o estudante pelo ID.");
            Console.WriteLine("6. Exibir a média das notas de cada estudante.");
            Console.WriteLine("7. Editar os dados do estudante pelo ID.");
            Console.WriteLine("8. Salvar dados.");
            Console.WriteLine("0. Encerrar o programa.");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                choice = -1;
            }

            Choice(choice);
        }

        public void Choice(int caseValue)
        {
            bool idFind = false;
            int idChosen;
            int tempNumberEdit;
            switch (caseValue)
            {
                case 0: // Encerrar o programa.
                    Environment.Exit(0);
                    break;
                case 1: // Ver todos os estudantes.
                    foreach (Student student in studentsList)
                    {
                        Console.WriteLine("ID: {0}, Nome: {1}, Idade: {2}", student.Id, student.Name, student.Age);
                    }
                    Console.WriteLine();
                    break;
                case 2: // Consultar estudante pelo ID.
                    Console.WriteLine("Insira o ID do aluno:");
                    idChosen = int.Parse(Console.ReadLine());
                    idFind = false;
                    foreach (Student student in studentsList)
                    {
                        if (student.Id == idChosen)
                        {
                            Console.WriteLine("ID: {0}, Nome: {1}, Idade: {2}, Data de nascimento: {3}, Número de matrícula: {4}, Curso: {5}",
                                student.Id, student.Name, student.Age, student.BirthDate.ToShortDateString(), student.RegistrationNumber, student.Course);
                            idFind = true;
                            break;
                        }
                    }
                    if (!idFind)
                    {
                        Console.WriteLine("Aluno não encontrado.");
                    }
                    break;
                case 3: // Consultar notas do estudante pelo ID.
                    Console.WriteLine("Insira o ID do aluno:");
                    idChosen = int.Parse(Console.ReadLine());
                    idFind = false;
                    foreach (Student student in studentsList)
                    {
                        if (student.Id == idChosen)
                        {
                            Console.WriteLine("ID: {0}, Nome: {1}, Idade: {2}", student.Id, student.Name, student.Age);
                            Console.WriteLine("Notas do estudante: {0}", string.Join(", ", student.Grades));
                            idFind = true;
                            break;
                        }
                    }
                    if (!idFind)
                    {
                        Console.WriteLine("Aluno não encontrado.");
                    }
                    break;
                case 4: // Inserir novo estudante.
                    Console.WriteLine("Insira o nome do estudante:");
                    string tempName = Console.ReadLine();

                    Console.WriteLine("Insira o dia, mês e ano de nascimento do estudante, separado por Enter:");
                    int tempDay = int.Parse(Console.ReadLine());
                    int tempMonth = int.Parse(Console.ReadLine());
                    int tempYear = int.Parse(Console.ReadLine());

                    Console.WriteLine("Insira o número de matrícula do estudante:");
                    int tempRegistrationNumber = int.Parse(Console.ReadLine());

                    Console.WriteLine("Insira o curso do estudante:");
                    string tempCourse = Console.ReadLine();

                    studentsList.Add(new Student(0, tempName, tempDay, tempMonth, tempYear, tempRegistrationNumber, tempCourse));
                    break;
                case 5: // Inserir nova nota para o estudante pelo ID.
                    Console.WriteLine("Insira o ID do aluno:");
                    idChosen = int.Parse(Console.ReadLine());
                    idFind = false;
                    foreach (Student student in studentsList)
                    {
                        if (student.Id == idChosen)
                        {
                            idFind = true;
                            while (true)
                            {
                                Console.WriteLine("Insira a nota do aluno:");
                                float newGrade = float.Parse(Console.ReadLine());
                                student.AddGrade(newGrade);

                                Console.WriteLine("Deseja adicionar outra nota? S/N");
                                string tempAddAnotherGrade = Console.ReadLine();
                                if (tempAddAnotherGrade.ToLower() == "s")
                                {
                                    continue;
                                }
                                break;
                            }
                            break;
                        }
                    }
                    if (!idFind)
                    {
                        Console.WriteLine("Aluno não encontrado.");
                    }
                    break;
                case 6: // Exibir a média das notas de cada estudante.
                    foreach (Student student in studentsList)
                    {
                        Console.WriteLine("ID: {0}, Número de matrícula: {1}, Nome: {2}, Média: {3}", student.Id, student.RegistrationNumber, student.Name, student.CalcAverage());
                    }
                    break;
                case 7: // Editar os dados do estudante pelo ID.
                    Console.WriteLine("Insira o ID do aluno:");
                    idChosen = int.Parse(Console.ReadLine());
                    idFind = false;
                    foreach (Student student in studentsList)
                    {
                        if (student.Id == idChosen)
                        {
                            idFind = true;
                            Console.WriteLine("Escolha uma opção:");
                            Console.WriteLine("1. Nome.");
                            Console.WriteLine("2. Data de nascimento.");
                            Console.WriteLine("3. Número de matrícula.");
                            Console.WriteLine("4. Curso.");
                            Console.WriteLine("5. Excluir uma nota.");
                            Console.WriteLine("6. Alterar uma nota.");
                            Console.WriteLine("7. Excluir todas as notas.");
                            Console.WriteLine("8. Excluir o estudante.");
                            Console.WriteLine("0. Voltar ao menu principal.");

                            int choice;
                            if (!int.TryParse(Console.ReadLine(), out choice))
                            {
                                choice = -1;
                            }

                            if (choice == 0) // Voltar ao menu principal.
                            {
                                break;
                            }
                            else if (choice == 1) // Nome.
                            {
                                Console.WriteLine("Insira o novo nome:");
                                string tempNameEdit = Console.ReadLine();
                                student.Name = tempNameEdit;
                            }
                            else if (choice == 2) // Data de nascimento.
                            {
                                Console.WriteLine("Insira o novo dia, mês e ano de nascimento do estudante, separado por Enter:");
                                int tempDayEdit = int.Parse(Console.ReadLine());
                                int tempMonthEdit = int.Parse(Console.ReadLine());
                                int tempYearEdit = int.Parse(Console.ReadLine());
                                student.BirthDate = new DateTime(tempYearEdit, tempMonthEdit, tempDayEdit);
                            }
                            else if (choice == 3) // Número de matrícula.
                            {
                                Console.WriteLine("Insira o novo número de matrícula do estudante:");
                                string tempNumberEditStr = Console.ReadLine();
                                int tempRegistrationNumberEdit = int.Parse(tempNumberEditStr);
                                student.RegistrationNumber = tempRegistrationNumberEdit;
                            }
                            else if (choice == 4) // Curso.
                            {
                                Console.WriteLine("Insira o curso do estudante:");
                                string tempCourseEdit = Console.ReadLine();
                                student.Course = tempCourseEdit;
                            }
                            else if (choice == 5) // Excluir uma nota.
                            {
                                Console.WriteLine("Notas do estudante:");
                                for (int i = 0; i < student.Grades.Count; i++)
                                {
                                    Console.WriteLine($"{i + 1}°: {student.Grades[i]}");
                                }
                                Console.WriteLine("Posição da nota a ser excluída:");
                                tempNumberEdit = int.Parse(Console.ReadLine());
                                student.RemoveGradeAt(tempNumberEdit - 1);
                            }
                            else if (choice == 6) // Alterar uma nota.
                            {
                                Console.WriteLine("Notas do estudante:");
                                for (int i = 0; i < student.Grades.Count; i++)
                                {
                                    Console.WriteLine($"{i + 1}°: {student.Grades[i]}");
                                }
                                Console.WriteLine("Posição da nota a ser editada:");
                                tempNumberEdit = int.Parse(Console.ReadLine());
                                Console.WriteLine("Insira a nova nota do aluno:");
                                float newGrade = float.Parse(Console.ReadLine());
                                student.ChangeGradeAt(newGrade, tempNumberEdit - 1);
                            }
                            else if (choice == 7) // Excluir todas as notas.
                            {
                                student.RemoveAllGrades();
                                Console.WriteLine($"Todas as notas do estudante {student.Name} foram excluídas.");
                            }
                            else if (choice == 8) // Excluir o estudante.
                            {
                                Console.WriteLine($"O estudante {student.Name} foi excluído.");
                                studentsList.Remove(student);
                            }
                            break;
                        }
                    }
                    if (!idFind)
                    {
                        Console.WriteLine("Aluno não encontrado.");
                    }
                    break;
                case 8:
                    FileSaveManager.SaveStudentListToJson(studentsList, filePath);
                    break;
                default: // Qualquer valor fora das opções do menu
                    Console.WriteLine("Por favor insira um número válido!");
                    break;
            }
        }

        public void Begin()
        {
            while (true)
            {
                Mainmenu();
            }
        }
    }
}
