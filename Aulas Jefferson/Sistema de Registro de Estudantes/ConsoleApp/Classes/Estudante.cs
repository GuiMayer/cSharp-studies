using System;

class Student
{
    public int id;
    public string name;
    public DateTime birthDate;
    private static int nextId = 1;

    public Student(string name, DateTime birthDate)
    {
        this.name = name;
        this.birthDate = birthDate;
        this.id = nextId++;
    }
}