using System;
using System.Xml.XPath;

public class GameManager
{
    private int minEquationRange = 1;
    private int maxEquationRange = 100;
    private (int a, int b, int result, int mathOperation) GenerateEquation()
    {
        Random random = new Random();
        var a = random.Next(minEquationRange, maxEquationRange);
        var b = random.Next(minEquationRange, maxEquationRange);
        var mathOperation = random.Next(0, 4);
        var result = CalculateEquation(a, b, mathOperation);
        if (result != null) {
            return (a, b, (int)result, mathOperation);
        }
        else {
            throw new ArgumentException("Result is null");
        }
    }

    private int? CalculateEquation(int a, int b, int mathOperation)
    {
        if (mathOperation == 0) {
            return a + b;
        } else if (mathOperation == 1) {
            return a - b;
        } else if (mathOperation == 2) {
            return a * b;
        } else if (mathOperation == 3) {
            if (a % b == 0) {
                return a / b;
            }
            else {
                return null;
            }
            
        }
        return null;
        
    }

    public void GenerateGame()
    {
        Dictionary<int, string> mathOperations = new Dictionary<int, string>();
        mathOperations.Add(0, "+");
        mathOperations.Add(1, "-");
        mathOperations.Add(2, "*");
        mathOperations.Add(3, "/");
        var equation = GenerateEquation();
        //Console.WriteLine($"{equation.a} {mathOperations[equation.mathOperation]} {equation.b} = {equation.result}");
        Console.WriteLine($"{equation.a} _ {equation.b} = {equation.result}");
        int answer = int.Parse(Console.ReadLine());
        
        if (answer == equation.mathOperation) {
            Console.WriteLine("RESPOSTA CORRETA");
        } else {
            Console.WriteLine("RESPOSTA ERRADA");
        }
    }
}