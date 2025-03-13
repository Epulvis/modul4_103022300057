internal class Program
{
    private static void Main(string[] args)
    {
        KodeProduk kodeProduk = new KodeProduk();
        string produk = Console.ReadLine();     
        Console.WriteLine(kodeProduk.getKodeProduk(produk));
    }
}

public class KodeProduk
{
    private Dictionary<string, string> kodeProdukData;

    public KodeProduk()
    {
        kodeProdukData = new Dictionary<string, string>
        {
            {"Laptop", "E100"},
            {"Smartphone", "E101"},
            {"Tablet", "E102"},
            {"Headset", "E103"},
            {"Keyboard", "E104"},
            {"Mouse", "E105"},
            {"Printer", "E106"},
            {"Monitor", "E107"},
            {"Smartwatch", "E108"},
            {"Kamera", "E109"}
        };
    }

    public string getKodeProduk(string produk)
    {
        if (kodeProdukData.ContainsKey(produk))
        {
            return kodeProdukData[produk];
        }
        else
        {
            return "Kode pos tidak ditemukan";
        }
    }
}