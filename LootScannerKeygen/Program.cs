using System.Security.Cryptography;

Console.Write("Copy public key: ");
var machineRegexGuid = Console.ReadLine();


var daysToExpire = 0;
Console.Write($"Days to expire [Default (enter/empty) is 30 days]: ");
while (true)
{
    try
    {
        var userInput = Console.ReadLine();
        daysToExpire = string.IsNullOrWhiteSpace(userInput) ? 30 : int.Parse(userInput);
        break;
    }
    catch (Exception e)
    {
        Console.Write($"Are you serious? Print an number, please: {e.Message}");
    }
}

var aesAlg = Aes.Create();
aesAlg.IV = "abcdef9876543210"u8.ToArray();
aesAlg.Key = "0123456789abcdef"u8.ToArray();

// Regex is: ---Days:(\d+) --- Y:(\d+) --- M:(\d+) --- D:(\d+) --- Machine:(.+)
var startActivationDate = DateTime.UtcNow;
var originalText = $"---Days:{daysToExpire} --- Y:{startActivationDate.Year} --- M:{startActivationDate.Month} --- D:{startActivationDate.Day} --- Machine:{machineRegexGuid}";

using var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
using var msEncrypt = new MemoryStream();
using var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);
using (var swEncrypt = new StreamWriter(csEncrypt))
{
    swEncrypt.Write(originalText);
}

var encrypted = msEncrypt.ToArray();

var encryptedText = Convert.ToBase64String(encrypted);
Console.WriteLine("Activation key is below. Copy, send and close this window. User should put this line in the \"Activation key\" field");
Console.WriteLine(encryptedText);
Console.ReadLine();
