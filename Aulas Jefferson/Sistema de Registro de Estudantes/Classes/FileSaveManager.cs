using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

class FileSaveManager
{
    public static void SaveStudentListToJson(List<Student> studentsList, string filePath)
    {
        List<object> data = new List<object>();
        foreach (Student student in studentsList)
        {
            var studentData = new
            {
                id = student.GetId(),
                name = student.GetName(),
                registration_number = student.GetRegistrationNumber(),
                birth_date = student.GetBirthDate(),
                course = student.GetCourse(),
                grades = student.GetGrades()
            };
            data.Add(studentData);
        }
        string jsonData = JsonConvert.SerializeObject(data);
        File.WriteAllText(filePath, jsonData);
    }

    public static void LoadStudentsListFromJsonFile(List<Student> studentsList, string filePath)
    {
        try
        {
            if (File.Exists(filePath))
            {
                string jsonData = File.ReadAllText(filePath);
                var data = JsonConvert.DeserializeObject<List<dynamic>>(jsonData);
                foreach (var studentData in data)
                {
                    Student student = new Student(
                        studentData.registration_number,
                        studentData.name,
                        int.Parse(studentData.birth_date.Split('/')[0]),
                        int.Parse(studentData.birth_date.Split('/')[1]),
                        int.Parse(studentData.birth_date.Split('/')[2]),
                        studentData.course
                    );
                    student.SetGrades(studentData.grades.ToObject<List<double>>());
                    studentsList.Add(student);
                }
            }
            else
            {
                Console.WriteLine("O arquivo JSON não foi encontrado.");
            }
        }
        catch (JsonException ex)
        {
            Console.WriteLine("Erro ao ler o arquivo JSON: " + ex.Message);
        }
    }
}
