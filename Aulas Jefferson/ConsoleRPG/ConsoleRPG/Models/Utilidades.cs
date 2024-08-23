using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilidades
{
    class P
    {
        public static void PrintLn(string texto)
        {
            for (int i = 0; i < texto.Length; i++)
            {
                Console.Write(texto[i]);
                Thread.Sleep(50);
            }
            Console.WriteLine();
        }
        public static void PrintLn(string texto, int tempo)
        {
            for (int i = 0; i < texto.Length; i++)
            {
                Console.Write(texto[i]);
                Thread.Sleep(tempo);
            }
            Console.WriteLine();
        }public static void Print(string texto)
        {
            for (int i = 0; i < texto.Length; i++)
            {
                Console.Write(texto[i]);
                Thread.Sleep(50);
            }
        }
        public static void Print(string texto, int tempo)
        {
            for (int i = 0; i < texto.Length; i++)
            {
                Console.Write(texto[i]);
                Thread.Sleep(tempo);
            }
        }
    }
}