using System;

public class Creature
{
    private string name;
    private int lifePoints;
    private int ID;

    private static int nextID = 1;

    public string GetName(){
        return name;
    }

    public int GetLifePoints(){
        return lifePoints;
    }
    
    public int GetID(){
        return ID;
    }

    public void SetName(string name){
        this.name = name;
    }

    public void SetLifePoints(int lifePoints){
        this.lifePoints = lifePoints;
    }

    public Creature()
    {
        ID = nextID++;
    }
}

class Program
{
    public static void Main(string[] args){
        Creature zombie = new Creature();
        zombie.SetName("Criatura 1");
        zombie.SetLifePoints(100);

        Creature creature2 = new Creature();
        creature2.SetName("Criatura 2");
        creature2.SetLifePoints(150);

        Console.WriteLine($"ID da Criatura 1: {zombie.GetID()}");
        Console.WriteLine($"Nome da Criatura 1: {zombie.GetName()}");
        Console.WriteLine($"Pontos de vida da Criatura 1: {zombie.GetLifePoints()}");

        Console.WriteLine($"ID da Criatura 2: {creature2.GetID()}");
        Console.WriteLine($"Nome da Criatura 2: {creature2.GetName()}");
        Console.WriteLine($"Pontos de vida da Criatura 2: {creature2.GetLifePoints()}");

        Console.ReadLine();
    }
}