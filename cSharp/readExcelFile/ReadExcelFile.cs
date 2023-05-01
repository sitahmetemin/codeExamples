//Depended package IronXL.Excel

public class ReadExcelFile
{
    public const string UrlPattern = "https://source.file.url.information.right.here";

    public void DowloadAndSave()
    {
        WorkBook workBook = WorkBook.Load("C:\\file\\path\\excel\\file.xlsx");
        var pageCells = workBook.GetWorkSheet("Page1");

        StringBuilder failedCodes = new StringBuilder();

        foreach (var cell in pageCells["A:A"])
        {
            using var client = new HttpClient();

            var responseService = client.GetAsync(string.Format(UrlPattern, cell)).Result;

            var byteArrayImage = responseService.Content.ReadAsByteArrayAsync().Result;

            if (responseService.StatusCode != System.Net.HttpStatusCode.OK)
            {
                failedCodes.AppendLine(string.Join(" - ", cell.Text, responseService.StatusCode.ToString()));
                Console.WriteLine($"{cell.Text} ERROR!! -> {responseService.StatusCode}");
            }
            else
            {
                File.WriteAllBytesAsync($"C:\\folder\\path\\and\\file\\name.png", byteArrayImage);
                Console.WriteLine($"{cell.Text} ok");
            }
        }

        File.WriteAllText($"C:\\folder\\path\\and\\file\\name\\for\\fail.txt", failedCodes.ToString());
    }
}