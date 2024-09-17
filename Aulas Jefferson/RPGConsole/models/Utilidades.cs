class Utilidades
{
    public static void Print(string text)
    {
        for (int i = 0; i < text.Length; i++)
        {
            Console.Write(text[i]);
            Thread.Sleep(30);
        }
    }
    public static void Print(string text, int time)
    {
        for (int i = 0; i < text.Length; i++)
        {
            Console.Write(text[i]);
            Thread.Sleep(time);
        }
    }
    public static void PrintLn(string text)
    {
        for (int i = 0; i < text.Length; i++)
        {
            Console.Write(text[i]);
            Thread.Sleep(30);
        }
        Console.WriteLine();
    }
    public static void PrintLn(string text, int time)
    {
        for (int i = 0; i < text.Length; i++)
        {
            Console.Write(text[i]);
            Thread.Sleep(time);
        }
        Console.WriteLine();
    }
}