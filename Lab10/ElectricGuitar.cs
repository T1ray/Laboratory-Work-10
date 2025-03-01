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
    
}