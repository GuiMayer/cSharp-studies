using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

class FileSaveManager
{
    public static void SaveStudentListToJson(List<Student> studentsList, string filePath)
    {
        string jsonString = JsonConvert.SerializeObject(studentsList);
        File.WriteAllText(filePath, jsonString);
    }

    public static void LoadStudentsListFromJsonFile(List<Student> studentsList, string filePath)
    {
        if (File.Exists(filePath))
        {
            string jsonString = File.ReadAllText(filePath);

            List<Student> students = JsonConvert.DeserializeObject<List<Student>>(jsonString);

            foreach (Student student in students)
            {
                studentsList.Add(student);
            }
        }
        else
        {
            Console.WriteLine("O arquivo JSON não foi encontrado.");
        }
    }

}