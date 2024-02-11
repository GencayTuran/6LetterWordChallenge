//get input data
string baseDirectoryPath = AppDomain.CurrentDomain.BaseDirectory;
string fileName = "input.txt";

//Go up to the root level of the github directory to get the input file.
string filePath = Path.GetFullPath(Path.Combine(baseDirectoryPath, "..\\..\\..\\..\\..", fileName));

//put data into collection
var inputData = await File.ReadAllLinesAsync(filePath);

//return collection
foreach (var data in inputData)
{
    Console.WriteLine(data);
}

Console.ReadLine();