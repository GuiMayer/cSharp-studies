using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public class JsonSerializer
{
    private readonly string _filePath;

    public JsonSerializer(string filePath)
    {
        _filePath = filePath;
    }

    public void Serialize(object obj)
    {
        string json = JsonConvert.SerializeObject(obj, Formatting.Indented);
        File.WriteAllText(_filePath, json);
    }

    public T Deserialize<T>()
    {
        if (!File.Exists(_filePath))
        {
            throw new FileNotFoundException($"File {_filePath} not found.");
        }

        string json = File.ReadAllText(_filePath);
        return JsonConvert.DeserializeObject<T>(json);
    }

    public void SerializeList<T>(List<T> list)
    {
        string json = JsonConvert.SerializeObject(list, Formatting.Indented);
        File.WriteAllText(_filePath, json);
    }

    public List<T> DeserializeList<T>()
    {
        if (!File.Exists(_filePath))
        {
            throw new FileNotFoundException($"File {_filePath} not found.");
        }

        string json = File.ReadAllText(_filePath);
        return JsonConvert.DeserializeObject<List<T>>(json);
    }
}
