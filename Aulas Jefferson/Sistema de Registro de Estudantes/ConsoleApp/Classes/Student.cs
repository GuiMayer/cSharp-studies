using System;
using System.Collections.Generic;

class Student
{
    private int id;
    private string name;
    private DateTime birthDate;
    private int registrationNumber;
    private string course;
    private List<float> grades;
    private static int nextId = 1;

    public Student(int registrationNumber, string name, int dayBirth, int monthBirth, int yearBirth, string course) // construtor da classe
    {
        this.id = nextId++;
        this.name = name;
        this.registrationNumber = registrationNumber;
        this.course = course;
        this.birthDate = new DateTime(yearBirth, monthBirth, dayBirth);
        this.grades = new List<float>();
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

    public void AddGrade(float grade) // adiciona uma nota do estudante
    {
        grades.Add(grade);
    }

    public int CountGrades() // retorna a quantidade de notas do estudante
    {
        return grades.Count;
    }

    public List<float> GetGrades() // retorna uma lista com todas as notas
    {
        return grades;
    }

    public void RemoveAllGrades() // remove todas as notas
    {
        grades.Clear();
    }

    public void RemoveGradeAt(int num) // remove a nota especificada pela posição na lista
    {
        grades.RemoveAt(num);
    }

    public float CalcAvarage() // retorna a média das notas
    {
        float sumGrades = 0;
        foreach (var grade in grades){
            sumGrades += grade;
        }
        return sumGrades/grades.Count;
    }

}
