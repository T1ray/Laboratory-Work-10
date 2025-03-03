namespace Lab10;

public class ElectricGuitar : Guitar
{
    private string[] availablePowerSupplies = new string[]
    {
        "батарейки",
        "аккумулятор",
        "фиксированный источник питания",
        "usb"
    };

    private string powerSource;
    
    public string PowerSource
    {
        get => powerSource;
        set
        {
            if (!availablePowerSupplies.Contains(value.ToLower()))
            {
                throw new Exception("Нет данного источника питания!");
            }
            powerSource = value;
        }
    }

    public ElectricGuitar() : base(6)
    {
        Name = "Электрическая гитара";
        PowerSource = "Аккумулятор";
    }

    public ElectricGuitar(string powerSource) : base(6)
    {
        Name = "Электрическая гитара";
        PowerSource = powerSource;
    }

    public ElectricGuitar(string powerSource, int numberStrings) : base(numberStrings)
    {
        Name = "Электрическая гитара";
        PowerSource = powerSource;
    }

    public new void Show()
    {
        base.Show();
        Console.WriteLine($"Источник питания - {PowerSource}");
    }
    
    public override void VirtualShow()
    {
        base.VirtualShow();
        Console.WriteLine($"Источник питания - {PowerSource}");
    }

    public override void Init()
    {
        base.Init();
        Console.WriteLine("Введите источник питания: ");
        PowerSource = Console.ReadLine();
    }

    public override void RandomInit()
    {
        base.RandomInit();
        Random rand = new Random();
        Name = "Электрическая гитара";
        PowerSource = availablePowerSupplies[rand.Next(0, availablePowerSupplies.Length)];
    }
    
    public override bool Equals(object obj)
    {
        if (obj is ElectricGuitar electricGuitar)
        {
            return Name == electricGuitar.Name 
                   && NumberStrings == electricGuitar.NumberStrings 
                   && PowerSource == electricGuitar.PowerSource;
        }
        return false;
    }
}