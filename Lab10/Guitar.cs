namespace Lab10;
using static AdditionalFunctions;

public class Guitar : MusicalInstrument
{
    private int numberStrings;

    public int NumberStrings
    {
        get => numberStrings;
        
        set
        {
            if (value < 1) throw new Exception("Количество струн должно быть положительным числом");
            numberStrings = value;
        }
        
    }

    public Guitar() : base("Гитара")
    {
        NumberStrings = 4;
    }

    public Guitar(int numberStrings) : base("Гитара")
    {
        NumberStrings = numberStrings;
    }

    public new void Show()
    {
        base.Show();
        Console.WriteLine($"Количество струн - {NumberStrings}");
    }

    public override void VirtualShow()
    {
        base.VirtualShow();
        Console.WriteLine($"Количество струн - {NumberStrings}");
    }

    public override void Init()
    {
        base.Init();
        
        Console.WriteLine("Введите количество струн:");
        NumberStrings = CorrectIntegerInput();
    }

    public override void RandomInit()
    {
        Random rand = new Random();
        base.RandomInit();
        Name = "Гитара";
        NumberStrings = rand.Next(4, 13);
    }

    public override bool Equals(object obj)
    {
        if (obj is Guitar guitar)
        {
            return Name == guitar.Name && NumberStrings == guitar.NumberStrings;
        }
        return false;
    }
}