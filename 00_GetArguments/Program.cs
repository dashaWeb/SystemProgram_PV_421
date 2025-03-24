internal class Program
{
    private static void Main(string[] args)
    {
        foreach (var item in args)
        {
            Console.WriteLine(item);
        }
        Console.ReadKey();
    }
}