// Version 1 (Counts folders and files in the given path):
Console.Write("Enter a directory path (version 1): ");
string? inputPath1 = Console.ReadLine();

if (string.IsNullOrWhiteSpace(inputPath1))
{
    Console.WriteLine("No path was provided.");
    return;
}

if (!Directory.Exists(inputPath1))
{
    Console.WriteLine("The path does not exist or is not a directory.");
    return;
}

try
{
    long fileCount1 = Directory.EnumerateFiles(inputPath1).LongCount();
    long folderCount1 = Directory.EnumerateDirectories(inputPath1).LongCount();

    Console.WriteLine($"Total files: {fileCount1}");
    Console.WriteLine($"Total folders: {folderCount1}");
}
catch (UnauthorizedAccessException ex)
{
    Console.WriteLine($"Access denied while scanning folders: {ex.Message}");
}
catch (DirectoryNotFoundException ex)
{
    Console.WriteLine($"A folder was not found during scanning: {ex.Message}");
}
catch (IOException ex)
{
    Console.WriteLine($"An I/O error occurred while scanning: {ex.Message}");
}


Console.WriteLine();





// Version 2 (Counts folders, subfolders and files in the given path)
Console.Write("Enter a directory path (version 2): ");
string? inputPath = Console.ReadLine();

if (string.IsNullOrWhiteSpace(inputPath))
{
    Console.WriteLine("No path was provided.");
    return;
}

if (!Directory.Exists(inputPath))
{
    Console.WriteLine("The path does not exist or is not a directory.");
    return;
}

long fileCount = 0;
long folderCount = 0;

try
{
    var directoriesToProcess = new Stack<string>();
    directoriesToProcess.Push(inputPath);

    while (directoriesToProcess.Count > 0)
    {
        string currentDirectory = directoriesToProcess.Pop();

        foreach (string subDirectory in Directory.EnumerateDirectories(currentDirectory))
        {
            folderCount++;
            directoriesToProcess.Push(subDirectory);
        }

        foreach (string file in Directory.EnumerateFiles(currentDirectory))
        {
            fileCount++;
        }
    }

    Console.WriteLine($"Total files: {fileCount}");
    Console.WriteLine($"Total folders: {folderCount}");
}
catch (UnauthorizedAccessException ex)
{
    Console.WriteLine($"Access denied while scanning folders: {ex.Message}");
}
catch (DirectoryNotFoundException ex)
{
    Console.WriteLine($"A folder was not found during scanning: {ex.Message}");
}
catch (IOException ex)
{
    Console.WriteLine($"An I/O error occurred while scanning: {ex.Message}");
}