using System;
using Lab9_1;
namespace Lab10;

public class MusicalInstrument : IInit, IComparable<MusicalInstrument>, ICloneable
{
    private static int numberMusicalInstruments = 0; 
    private static string[] randomInstruments = new string[]
    {
        "Гитара", "Фортепиано", "Барабаны", "Саксофон", "Скрипка",
        "Бас-гитара", "Клавишные", "Труба", "Акустическая гитара", "Маракасы"
    };

    public static int NumberMusicalInstruments {get => numberMusicalInstruments;}
    
    public string Name { get; set; }

    public MusicalInstrument()
    {
        Name = "";
        numberMusicalInstruments++;
    }

    public MusicalInstrument(string name)
    {
        Name = name;
        numberMusicalInstruments++;
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
        numberMusicalInstruments++;
    }

    public virtual void RandomInit()
    {
        Random rand = new Random();
        Name = randomInstruments[rand.Next(randomInstruments.Length)];
        numberMusicalInstruments++;
    }

    public int CompareTo(MusicalInstrument? other)
    {
        if (other == null) return -1;
        return Name.CompareTo(other.Name);
    }
    
    public int CompareTo(IInit? other)
    {
        if (other == null) return -1;
        return Name.CompareTo(other.Name);
    }

    public override bool Equals(object obj)
    {
        if (obj is MusicalInstrument instrument)
        {
            return Name == instrument.Name;
        }
        return false;
    }

    public override string ToString()
    {
        return $"Название инструмента: {Name}\n";
    }

    public virtual object Clone()
    {
        return new MusicalInstrument(this.Name);
    }

    public object ShallowClone()
    {
        return this.MemberwiseClone();
    }
}

