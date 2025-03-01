namespace Lab10;

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
}