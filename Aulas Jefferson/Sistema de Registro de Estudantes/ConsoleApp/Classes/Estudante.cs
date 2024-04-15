using System;

class Student
{
    private int id;
    public string name;
    private DateTime birthDate;
    private static int nextId = 1;

    public Student(string name, int dayBirth, int monthBirth, int yearBirth)
    {
        this.id = nextId++;
        this.name = name;
        this.birthDate = new DateTime(yearBirth, monthBirth, dayBirth);
    }

    public int GetAge()
    {
        DateTime now = DateTime.Now;
        if ((int)birthDate.Day > (int)now.Day && (int)birthDate.Month > (int)now.Month){
            return (int)now.Year - (int)birthDate.Year - 1;    
        }
        else{
            return (int)now.Year - (int)birthDate.Year;
        }
        
    }

    public void SetBirthDate(int dayBirth, int monthBirth, int yearBirth)
    {
        this.birthDate = new DateTime(yearBirth, monthBirth, dayBirth);
    }
}