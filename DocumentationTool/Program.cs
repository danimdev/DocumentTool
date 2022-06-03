bool isDocumenting = true;

menu();

void menu()
{
    while (isDocumenting)
    {

        Console.WriteLine("What do you want to make?");
        Console.WriteLine("1. Make a new File");
        Console.WriteLine("2. Edit an existing File");
        Console.WriteLine("3. Close Application");

        int menuInput = Convert.ToInt32(Console.ReadLine());

        switch (menuInput)
        {
            case 1:
                MakeNewFileAndEdit();
                break;
            case 2:
                break;
            case 3:
                isDocumenting = false;
                break;
            default:
                Console.WriteLine("No Valid Choice");
                break;
        }
    }
}

void MakeNewFileAndEdit()
{
    isDocumenting = false;

    Console.WriteLine("1.Standard File Name");
    Console.WriteLine("2.Custom File Name");

    int fileNameChoice = Convert.ToInt32(Console.ReadLine());

    string textFileName = null;

    if (fileNameChoice == 1)
    {
        textFileName = "Document " + DateTime.Now.ToString("H m ss") + ".txt";
    }
    else if(fileNameChoice == 2)
    {
        Console.Write("Name: ");
        string newFileName = Console.ReadLine();
        textFileName = newFileName + ".txt";
    }

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

    isDocumenting = true;
}