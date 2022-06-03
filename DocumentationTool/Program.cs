string textFileName = "Document " + DateTime.Now.ToString("H m ss") + ".txt";

FileStream stream = new FileStream(textFileName, FileMode.OpenOrCreate);

Console.WriteLine("What do you want to Document?");
using (var t = new StreamWriter(stream))
{
    t.AutoFlush = true;

    do
    {
        Console.Write("Text: ");

        string inputToFile = Console.ReadLine();

        t.WriteLine(inputToFile);

        Console.Write("Press Enter For A New Line or Escape for Closing The Application...");
        Console.WriteLine();

    } while (Console.ReadKey(true).Key != ConsoleKey.Escape);

    t.Dispose();
    t.Close();
}