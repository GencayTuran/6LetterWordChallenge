#region InputData
//get input data
string baseDirectoryPath = AppDomain.CurrentDomain.BaseDirectory;
string fileName = "input.txt";

//Go up to the root level of the github directory to get the input file.
string filePath = Path.GetFullPath(Path.Combine(baseDirectoryPath, "..\\..\\..\\..\\..", fileName));

//put data into collection
var inputData = await File.ReadAllLinesAsync(filePath);
#endregion

//combine the data
var combinedData = CombineData(inputData);

#region ViewData
//return collection
foreach (var data in combinedData)
{
    Console.WriteLine(data);
}
Console.ReadLine();
#endregion

IEnumerable<string> CombineData(string[] inputData)
{
    var existingCombinations = inputData.Where(data => data.Length == 6).ToArray();
    var toBeCombinedWords = inputData.Where(data => data.Length < 6 && data.Length > 0).ToArray();

    var combinedWords = from word1 in toBeCombinedWords
                        from word2 in toBeCombinedWords
                        where word1 != word2
                        let combined = word1 + word2
                        where existingCombinations.Contains(combined, StringComparer.OrdinalIgnoreCase)
                        select $"{word1}+{word2}={combined}";

    return combinedWords;
}