using System;
using System.Collections.Generic;
using System.Linq;


class Student
{
    private int id;
    private string name;
    private int birthDateDay;
    private int birthDateMonth;
    private int birthDateYear;
    private int registrationNumber;
    private string course;
    private List<double> grades;
    private static int nextId = 1;

    public Student(int registrationNumber, string name, int dayBirth, int monthBirth, int yearBirth, string course)
    {
        this.id = nextId++;
        this.name = name;
        this.registrationNumber = registrationNumber;
        this.course = course;
        this.birthDateDay = dayBirth;
        this.birthDateMonth = monthBirth;
        this.birthDateYear = yearBirth;
        this.grades = new List<double>();
    }

    public int GetAge()
    {
        DateTime now = DateTime.Now;
        if (birthDateMonth > now.Month || (birthDateMonth == now.Month && birthDateDay > now.Day))
        {
            return now.Year - birthDateYear - 1;
        }
        else
        {
            return now.Year - birthDateYear;
        }
    }

    public int GetId() => id;

    public int GetRegistrationNumber() => registrationNumber;

    public string GetCourse() => course;

    public string GetBirthDate() => $"{birthDateDay}/{birthDateMonth}/{birthDateYear}";

    public string GetName() => name;

    public void SetBirthDate(int dayBirth, int monthBirth, int yearBirth)
    {
        birthDateDay = dayBirth;
        birthDateMonth = monthBirth;
        birthDateYear = yearBirth;
    }

    public void SetName(string name) => this.name = name;

    public void SetRegistrationNumber(int registrationNumber) => this.registrationNumber = registrationNumber;

    public void SetCourse(string course) => this.course = course;

    public void ChangeGradeAt(double grade, int position) => grades[position] = grade;

    public void AddGrade(double grade) => grades.Add(grade);

    public void SetGrades(List<double> grades) => this.grades = grades;

    public int CountGrades() => grades.Count;

    public List<double> GetGrades() => grades;

    public void RemoveAllGrades() => grades.Clear();

    public void RemoveGradeAt(int num) => grades.RemoveAt(num);

    public double CalcAverage()
    {
        try
        {
            return grades.Average();
        }
        catch (Exception)
        {
            return 0;
        }
    }
}
