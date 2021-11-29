namespace TestApp;
public static class Program
{
    public static void Main(string[] args)
    {
        var userId = int.Parse(args[0]);
        Console.WriteLine("It worked!!" + userId);
        Console.ReadLine();
    }
}