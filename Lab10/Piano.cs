namespace Lab10;
using static AdditionalFunctions;
public class Piano : MusicalInstrument
{
    private string[] availableKeyLayouts = new string[]
    {
        "октавная",
        "шкальная",
        "дигитальная"
    };

    private string keyLayout;
    private int numberKeys;

    public string KeyLayout
    {
        get => keyLayout;
        set
        {
            if (!availableKeyLayouts.Contains(value.ToLower()))
            {
                throw new Exception("Нет такой раскладки клавиш!");
            }
            keyLayout = value;
        }
    }
    public int NumberKeys
    {
        get => numberKeys;
        set
        {
            if (value < 1) throw new Exception("Количество клавиш не может быть отрицательным числом!");
            numberKeys = value;
        }
    }

    public Piano() : base("Фортепиано")
    {
        KeyLayout = availableKeyLayouts[0];
        NumberKeys = 88;
    }

    public Piano(int numberKeys) : base("Фортепиано")
    {
        KeyLayout = availableKeyLayouts[0];
        NumberKeys = numberKeys;
    }

    public Piano(int numberKeys, string keyLayout) : base("Фортепиано")
    {
        KeyLayout = keyLayout;
        NumberKeys = numberKeys;
    }

    public new void Show()
    {
        base.Show();
        Console.WriteLine($"Количество клавиш у фортепиано - {NumberKeys}");
        Console.WriteLine($"Раскладка клавиш - {KeyLayout}");
    }

    public override void VirtualShow()
    {
        base.VirtualShow();
        Console.WriteLine($"Количество клавиш у фортепиано - {NumberKeys}");
        Console.WriteLine($"Раскладка клавиш - {KeyLayout}");
    }

    public override void Init()
    {
        base.Init();
        Console.WriteLine("Введите количество клавиш: ");
        NumberKeys = CorrectIntegerInput();
        Console.WriteLine("Введитье раскладку клавиш фортепиано: ");
        KeyLayout = Console.ReadLine();
    }

    public override void RandomInit()
    {
        Random rand = new Random();
        base.RandomInit();
        NumberKeys = rand.Next(88, 103);
        KeyLayout = availableKeyLayouts[rand.Next(0,availableKeyLayouts.Length)];
    }
    
    public override bool Equals(object obj)
    {
        if (obj is Piano piano)
        {
            return Name == piano.Name && NumberKeys == piano.NumberKeys && KeyLayout == piano.KeyLayout;
        }
        return false;
    }
}