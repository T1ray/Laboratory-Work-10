

namespace Lab10;

public class MusicalInstrument
{
    private string[] randomInstruments = new string[]
    {
        "Гитара", "Фортепиано", "Барабаны", "Саксофон", "Скрипка",
        "Бас-гитара", "Клавишные", "Труба", "Акустическая гитара", "Маракасы"
    };
    
    public string Name { get; set; }

    public MusicalInstrument()
    {
        Name = "";
    }

    public MusicalInstrument(string name)
    {
        Name = name;
    }

    public void Show()
    {
        Console.WriteLine($"Название инструмента - {Name}");
    }

    public virtual void VirtualShow()
    {
        Console.WriteLine($"Название инструмента - {Name}");
    }

    public virtual void Init()
    {
        Console.Write("Введите название инструмента: ");
        string input = Console.ReadLine();
        Name = input;
    }

    public virtual void RandomInit()
    {
        Random rand = new Random();
        Name = randomInstruments[rand.Next(randomInstruments.Length)];
    }

    public override bool Equals(object obj)
    {
        if (obj is MusicalInstrument instrument)
        {
            return Name == instrument.Name;
        }
        return false;
    }
}

