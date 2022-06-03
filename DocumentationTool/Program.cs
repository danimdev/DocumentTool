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
                EditExistingFIle();
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
    Console.WriteLine("1.Standard File Name");
    Console.WriteLine("2.Custom File Name");

    int fileNameChoice = Convert.ToInt32(Console.ReadLine());

    string textFileName = "";

    if (fileNameChoice == 1)
    {
        textFileName = "Document " + DateTime.Now.ToString("H m ss") + ".txt";
    }
    else if (fileNameChoice == 2)
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
}

void EditExistingFIle()
{
    Console.Write("File or DirectoryName:");

    string fileName = Console.ReadLine();

    fileName += ".txt";

    bool isEditing = true;

    while (isEditing)
    {
        do
        {
            ReadAFile(fileName);
            WriteToFile(fileName);
            Console.WriteLine("Press Enter to continue Edit Escape to Exit editing");
        } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        isEditing = false;
    }
}

void ReadAFile(string fileName)
{
    FileStream readStream = new FileStream(fileName, FileMode.Open);

    using (var t = new StreamReader(readStream))
    {
        string ln;
        while ((ln = t.ReadLine()) != null)
        {
            Console.WriteLine(ln);
        }

        t.Close();
    }
}

void WriteToFile(string filename)
{
    FileStream writeStream = new FileStream(filename, FileMode.Append);
    using (var s = new StreamWriter(writeStream))
    {
        s.AutoFlush = true;

        Console.Write("NewText: ");

        string inputToFile = Console.ReadLine();

        s.WriteLine(inputToFile);

        s.Dispose();
        s.Close();
    }
}