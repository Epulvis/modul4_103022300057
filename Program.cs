using System.Xml.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        KodeProduk kodeProduk = new KodeProduk();
        string produk = Console.ReadLine();     
        Console.WriteLine(kodeProduk.getKodeProduk(produk));

        FanLaptop fan = new FanLaptop();
        fan.TurboShortcut();
        fan.ModeDown();
        fan.ModeDown();
        fan.ModeDown();
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

public interface IModeState
{
    void ModeUp(FanLaptop fan);
    void ModeDown(FanLaptop fan);
    void DisplayState();
}

public class QuiteMode : IModeState
{
    public void ModeUp(FanLaptop fan)
    {
        fan.SetState(new BalanceMode());
        
    }
    public void ModeDown(FanLaptop fan)
    {
        Console.WriteLine("Fan Quiet (Sudah Mode Terendah)");
    }
    public void DisplayState()
    {
        Console.WriteLine("Fan Quiet");
    }
}

public class BalanceMode : IModeState
{
    public void ModeUp(FanLaptop fan)
    {
        fan.SetState(new PerformanceMode());
    }
    public void ModeDown(FanLaptop fan)
    {
        fan.SetState(new QuiteMode());
    }
    public void DisplayState()
    {
        Console.WriteLine("Fan Balance");
    }
}

public class PerformanceMode : IModeState
{
    public void ModeUp(FanLaptop fan)
    {
        fan.SetState(new TurboMode());
    }
    public void ModeDown(FanLaptop fan)
    {
        fan.SetState(new BalanceMode());
    }
    public void DisplayState()
    {
        Console.WriteLine("Fan Performa");
    }
}

public class TurboMode : IModeState
{
    public void ModeUp(FanLaptop fan)
    {
        Console.WriteLine("Fan Turbo (Sudah Mode Tertinggi)");
    }
    public void ModeDown(FanLaptop fan)
    {
        fan.SetState(new PerformanceMode());
    }
    public void DisplayState()
    {
        Console.WriteLine("Fan Turbo");
    }
}

public class FanLaptop
{
    private IModeState _currentState;

    public FanLaptop()
    {
        _currentState = new QuiteMode();
        _currentState.DisplayState();
    }

    public void SetState(IModeState newState)
    {
        _currentState = newState;
        _currentState.DisplayState();
    }

    public void ModeUp()
    {
        Console.Write(" Berubah Menjadi ");
        _currentState.ModeUp(this);

    }

    public void ModeDown()
    {
        Console.WriteLine(" Berubah Menjadi ");
        _currentState.ModeDown(this);
    }

    public void TurboShortcut()
    {
        if (_currentState is QuiteMode)
        {
            Console.WriteLine(" Berubah Menjadi ");
            SetState(new TurboMode());
        }
        else if (_currentState is TurboMode) {
            Console.WriteLine(" Berubah Menjadi ");
            SetState(new QuiteMode());
        }

    }
}