
using System.Net.Http.Headers;

Console.WriteLine("Hello, World!");
Console.WriteLine("Press any key to start upload ...");
Console.ReadLine();
var file = File.ReadAllBytes(@"F:\flower.jpg");

await UploadImage("http://localhost:5291/api/robot", file);



async Task UploadImage(string url, byte[] ImageData)
{
    var client=new HttpClient();

    var requestContent = new MultipartFormDataContent();
    var imageContent = new ByteArrayContent(ImageData);
    imageContent.Headers.ContentType =
        MediaTypeHeaderValue.Parse("image/jpeg");

    requestContent.Add(imageContent, "file", "my-flower.jpg");

    await client.PostAsync(url, requestContent);

    
}