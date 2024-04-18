using System;
using System.Collections.Generic;
using System.Linq;

class Student
{
    private int id;
    private string name;
    private DateTime birthDate;
    private int registrationNumber;
    private string course;
    private List<double> grades;
    private static int nextId = 1;

    public Student(int registrationNumber, string name, int dayBirth, int monthBirth, int yearBirth, string course) // construtor da classe
    {
        this.id = nextId++;
        this.name = name;
        this.registrationNumber = registrationNumber;
        this.course = course;
        try
        {
            this.birthDate = new DateTime(yearBirth, monthBirth, dayBirth);
        }
        catch (Exception ex)
        {
            this.birthDate = new DateTime(1, 1, 1);
        }

        this.grades = new List<double>();
    }

    public int GetAge() // calcula e retorna a idade do estudante
    {
        DateTime now = DateTime.Now;
        if ((int)birthDate.Day > (int)now.Day && (int)birthDate.Month > (int)now.Month){
            return (int)now.Year - (int)birthDate.Year - 1;    
        }
        else{
            return (int)now.Year - (int)birthDate.Year;
        }
    }

    public int GetId()
    {
        return id;
    }

    public int GetRegistrationNumber()
    {
        return registrationNumber;
    }

    public string GetCourse()
    {
        return course;
    }

    public string GetBirthDate()
    {
        return birthDate.ToString("dd/MM/yyyy");
    }

    public string GetName()
    {
        return name;
    }

    public void SetBirthDate(int dayBirth, int monthBirth, int yearBirth) // define a idade do estudante
    {
        this.birthDate = new DateTime(yearBirth, monthBirth, dayBirth);
    }

    public void SetName(string name){ // define o nome do estudante
        this.name = name;
    }

    public void SetRegistrationNumber(int registrationNumber){ // define o número de matrícula do estudante
        this.registrationNumber = registrationNumber;
    }

    public void SetCourse(string course){ // define o curso do estudante
        this.course = course;
    }

    public void ChangeGradeAt(double grade, int position){ // muda a nota do estudante na posição especificada

    }

    public void AddGrade(double grade) // adiciona uma nota do estudante
    {
        grades.Add(grade);
    }

    public int CountGrades() // retorna a quantidade de notas do estudante
    {
        return grades.Count;
    }

    public List<double> GetGrades() // retorna uma lista com todas as notas
    {
        return grades;
    }

    public void RemoveAllGrades() // remove todas as notas
    {
        grades.Clear();
    }

    public void RemoveGradeAt(int num) // remove a nota especificada pela posição especificada
    {
        grades.RemoveAt(num);
    }

    public double CalcAvarage() // retorna a média das notas
    {
        try {
            double sumGrades = grades.Sum();
            return grades.Average();
        }
        catch (Exception) {
            return 0;
        }
    }

}
