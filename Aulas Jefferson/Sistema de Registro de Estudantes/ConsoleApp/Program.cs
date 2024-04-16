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

        studentsList.Add(new Student(125312, "Guilherme Mayer", 17, 02, 2005, "TADS"));
        studentsList.Add(new Student(125313, "Bruna Camila Silveira", 20, 08, 2005, "Quimica"));
    }
    public int MainMenu() // Menu principal do programa
    {
        Console.WriteLine("Escolha uma opção:");
        Console.WriteLine("1. Ver todos os estudantes.");
        Console.WriteLine("2. Consultar estudante pelo ID.");
        Console.WriteLine("3. Consultar notas do estudante pelo ID.");
        Console.WriteLine("4. Inserir novo estudante.");
        Console.WriteLine("5. Inserir nova nota para o estudante pelo ID.");
        Console.WriteLine("6. Exibir a média das notas de cada estudante.");
        Console.WriteLine("7. Editar os dados do estudante pelo ID.");
        Console.WriteLine("0. Encerrar o programa.");
        string choice = Console.ReadLine();
        int result;
        int.TryParse(choice, out result);
        return result;
    }

    public void Choice() // Escolha da ação a ser realizada no programa
    {
        bool idFinded = false;
        string idChosen;
        string tempNumberEdit;
        switch (MainMenu())
        {
            case 0: // Encerrar o programa.
                Environment.Exit(0);
                break;

            case 1: // Ver todos os estudantes.
                foreach (Student student in studentsList)
                {
                    Console.WriteLine("ID:" + student.GetId() + ", Nome:" + student.GetName() + ", Idade: " + student.GetAge());
                }
                Console.WriteLine("");
                break;

            case 2: // Consultar estudante pelo ID.
                Console.WriteLine("Insira o ID do aluno:");
                idChosen = Console.ReadLine();
                idFinded = false;
                foreach (Student student in studentsList)
                {
                    if (student.GetId() == Convert.ToInt32(idChosen)){
                        Console.WriteLine("ID: " + student.GetId() + ", Nome: " + student.GetName() + ", Idade: " + student.GetAge() + ", Data de nascimento: " + student.GetBirthDate());
                        Console.WriteLine("Número de matrícula: " + student.GetRegistrationNumber() + ", Curso:" + student.GetCourse());
                        idFinded = true;
                        break;
                    }
                }
                if (!idFinded){
                    Console.WriteLine("Aluno não encontrado.");
                }
                break;

            case 3: // Consultar notas do estudante pelo ID.
                Console.WriteLine("Insira o ID do aluno:");
                idChosen = Console.ReadLine();
                idFinded = false;
                foreach (Student student in studentsList)
                {
                    if (student.GetId() == Convert.ToInt32(idChosen)){
                        Console.WriteLine("ID: " + student.GetId() + ", Nome: " + student.GetName() + ", Idade: " + student.GetAge());
                        Console.WriteLine("Notas do estudante: " + string.Join(", ",student.GetGrades()));
                        idFinded = true;
                        break;
                    }
                }
                if (!idFinded){
                    Console.WriteLine("Aluno não encontrado.");
                }
                break;

            case 4: // Inserir novo estudante.
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

            case 5: // Inserir nova nota para o estudante pelo ID.
                Console.WriteLine("Insira o ID do aluno:");
                idChosen = Console.ReadLine();
                idFinded = false;
                foreach (Student student in studentsList)
                {
                    if (student.GetId() == Convert.ToInt32(idChosen)){
                        idFinded = true;
                        while (true){
                            Console.WriteLine("Insira a nota do aluno:");
                            string newGrade = Console.ReadLine();
                            double tempGrade = Convert.ToDouble(newGrade);
                            student.AddGrade(tempGrade);

                            Console.WriteLine("Deseja adicionar outra nota? S/N");
                            string tempAddAnotherGrade = Console.ReadLine();
                            if (tempAddAnotherGrade == "S" || tempAddAnotherGrade == "s"){
                                continue;
                            }
                            break;
                        }
                        break;
                    }
                    
                }
                if (!idFinded){
                    Console.WriteLine("Aluno não encontrado.");
                }
                break;

            case 6: // Exibir a média das notas de cada estudante
                foreach (Student student in studentsList)
                {
                    Console.WriteLine("ID: " + student.GetId() + ", Número de matrícula: " + student.GetRegistrationNumber() + ", Nome: " + student.GetName() + ", Média: " + student.CalcAvarage().ToString());
                }
                break;

            case 7: // Editar os dados do estudante pelo ID.
                Console.WriteLine("Insira o ID do aluno:");
                idChosen = Console.ReadLine();
                idFinded = false;
                foreach (Student student in studentsList)
                {
                    if (student.GetId() == Convert.ToInt32(idChosen)){
                        idFinded = true;
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

                        string choice = Console.ReadLine();
                        int result;
                        int.TryParse(choice, out result);
                        switch (result)
                        {
                            case 0: // Voltar ao menu principal.
                                break;
                            case 1: // Nome.
                                Console.WriteLine("Insira o novo nome:");
                                string tempNameEdit = Console.ReadLine();
                                student.SetName(tempNameEdit);
                                break;

                            case 2: // Data de nascimento.
                                string tempBirthDateEdit = Console.ReadLine();
                                student.SetName(tempBirthDateEdit);

                                Console.WriteLine("Insira o novo dia, mês e ano de nascimento do estudante, separado por Enter:");
                                string tempChoiceEdit = Console.ReadLine();
                                int tempDayEdit = Convert.ToInt32(tempChoiceEdit);

                                tempChoice = Console.ReadLine();
                                int tempMonthEdit = Convert.ToInt32(tempChoiceEdit);

                                tempChoice = Console.ReadLine();
                                int tempYearEdit = Convert.ToInt32(tempChoiceEdit);
                                student.SetBirthDate(tempDayEdit, tempMonthEdit, tempYearEdit);
                                break;

                            case 3: // Número de matrícula.
                                Console.WriteLine("Insira o novo número de matrícula do estudante:");
                                tempNumberEdit = Console.ReadLine();
                                int tempRegistrationNumberEdit = Convert.ToInt32(tempNumberEdit);
                                student.SetRegistrationNumber(tempRegistrationNumberEdit);
                                break;

                            case 4: // Curso.
                                Console.WriteLine("Insira o curso do estudante:");
                                string tempCourseEdit = Console.ReadLine();
                                student.SetCourse(tempCourseEdit);
                                break;

                            case 5: // Excluir uma nota.
                                int countGrade = 1;
                                Console.WriteLine("Notas do estudante:");
                                foreach (var grade in student.GetGrades())
                                {
                                    Console.WriteLine(countGrade + "°: " + grade);
                                }
                                Console.WriteLine("Posição da nota a ser excluida:");
                                tempNumberEdit = Console.ReadLine();
                                int gradeToBeDeleted = Convert.ToInt32(tempNumberEdit) + 1;
                                student.RemoveGradeAt(gradeToBeDeleted);
                                break;

                            case 6: // Alterar uma nota
                                int countGrade2 = 1;
                                Console.WriteLine("Notas do estudante:");
                                foreach (var grade in student.GetGrades())
                                {
                                    Console.WriteLine(countGrade2 + "°: " + grade);
                                }
                                Console.WriteLine("Posição da nota a ser editada:");
                                tempNumberEdit = Console.ReadLine();
                                int gradeToBeEdited = Convert.ToInt32(tempNumberEdit) + 1;

                                Console.WriteLine("Insira a nota do aluno:");
                                string newGrade = Console.ReadLine();
                                double tempGrade = Convert.ToDouble(newGrade);

                                student.ChangeGradeAt(tempGrade, gradeToBeEdited);
                                break;

                            case 7: // Excluir todas as notas
                                student.RemoveAllGrades();
                                Console.WriteLine("Todas as notas do estudante " + student.GetName() + " foram excluidas.");
                                break;
                            case 8: // Excluir o estudante.
                                Console.WriteLine("O estudante " + student.GetName() + " foi excluído.");
                                studentsList.Remove(student);
                                break;

                        }
                    }
                    break;
                }
                    
                if (!idFinded){
                    Console.WriteLine("Aluno não encontrado.");
                }
                break;

            default: // Qualquer falor fora das opções do menu
                Console.WriteLine("Por favor insira um número válido!");
                Choice();
                break;
        }
    }

    public void Begin() // Inicia o loop principal do programa
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
