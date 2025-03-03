namespace Lab10;
using static AdditionalFunctions;

class Program
{
    
    static void DemonstratePartOne(MusicalInstrument[] instruments)
    {
        Console.WriteLine("Пример использования не виртуальной функции Show");
        foreach (MusicalInstrument instrument in instruments)
        {
            instrument.Show();
            Console.WriteLine();
        }

        TextSeparator();
        
        Console.WriteLine("Пример использования виртуальной функции Show");
        foreach (MusicalInstrument instrument in instruments)
        {
            instrument.VirtualShow();
            Console.WriteLine();
        }
    }

    static void DemonstratePartTwo(MusicalInstrument[] instruments)
    {
        Console.WriteLine("Запрос 30: Среднее количество струн всех гитар");
        Console.WriteLine(AverageGuitarStrings(instruments));
        TextSeparator();
        
        Console.WriteLine("Запрос 31: Количество струн всех электрогитар c фиксированным источником питания");
        Console.WriteLine(NumberStringsAllElectricGuitarsFixedPowerSupply(instruments));
        TextSeparator();
        
        Console.WriteLine("Запрос 32: Максимальное количество клавиш на фортепиано с октавной раскладкой");
        Console.WriteLine(MaxNumberOctavePianoKeys(instruments));
    }
    
    static double AverageGuitarStrings(MusicalInstrument[] instruments)
    {
        int totalNumberStrings = 0;
        int numberGuitars = 0;

        foreach (var instrument in instruments)
        {
            if (instrument is Guitar guitar)
            {
                totalNumberStrings += guitar.NumberStrings;
                numberGuitars++;
            }
        }
        return numberGuitars > 0 ? totalNumberStrings / numberGuitars : 0;
    }
    
    static int NumberStringsAllElectricGuitarsFixedPowerSupply(MusicalInstrument[] instruments)
    {
        int totalNumberStrings = 0;

        foreach (var instrument in instruments)
        {
            ElectricGuitar electricGuitar = instrument as ElectricGuitar;
            if (electricGuitar != null && electricGuitar.PowerSource == "фиксированный источник питания")
            {
                totalNumberStrings += electricGuitar.NumberStrings;
            }
        }
        return totalNumberStrings;
    }
    
    static int MaxNumberOctavePianoKeys(MusicalInstrument[] instruments)
    {
        int maxNumberKeys = 0;

        foreach (var instrument in instruments)
        {
            if (instrument.GetType() == typeof(Piano))
            {
                Piano piano = (Piano)instrument;
                if (piano.KeyLayout == "октавная" && piano.NumberKeys > maxNumberKeys)
                {
                    maxNumberKeys = piano.NumberKeys;
                }
            }
        }
        return maxNumberKeys;
    }

    static void DemonstratePartThree(MusicalInstrument[] instruments)
    {
        
    }

    static void Menu()
    {
        Console.WriteLine("1. Вывод первой части");
        Console.WriteLine("2. Вывод второй части");
        Console.WriteLine("3. Вывод третьей части");
    }
    static void Main(string[] args)
    {
        MusicalInstrument[] instruments = new MusicalInstrument[20];
        Random rand = new Random();
        
        for (int i = 0; i < instruments.Length; i++)
        {
            int type = rand.Next(4);
    
            switch (type)
            {
                case 0:
                    instruments[i] = new MusicalInstrument();
                    break;
                case 1:
                    instruments[i] = new Guitar();
                    break;
                case 2:
                    instruments[i] = new ElectricGuitar();
                    break;
                case 3:
                    instruments[i] = new Piano();
                    break;
            }
            instruments[i].RandomInit();
        }

        while (true)
        {
            Menu();
            Console.Write("Выберите пункт меню: ");
            string input = Console.ReadLine();
            TextSeparator();
            switch (input)
            {
                case "1":
                    DemonstratePartOne(instruments);
                    break;
                case "2":
                    DemonstratePartTwo(instruments);
                    break;
                case "3":
                    DemonstratePartThree(instruments);
                    break;
            }
            TextSeparator();
        }
    }
}