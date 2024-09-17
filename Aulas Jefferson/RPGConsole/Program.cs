using System;

class Program
{
    static void Main()
    {
        string texto = "";
        bool teste;

        Console.WriteLine(Console.WindowWidth);
        while (true)
        {
            for (int j = 0; j < Console.WindowHeight-1; j++)
            {
                teste = true;
                for (int i = 0; i < Console.WindowWidth; i++) {
                    if (j == 0 || j == Console.WindowHeight - 2) {Console.Write('-');}
                    else {
                        if (teste) {Console.Write('X');}
                        else {Console.Write('O');}
                        teste = !teste;
                    }
                    
                }
                Console.WriteLine();

            }
            Thread.Sleep(1000);
        }
        // Utilidades.PrintLn(texto, 100);
    }
}