namespace Lab10;
using static AdditionalFunctions.AdditionalFunctions;
using Lab9_1;

public class Program
{
    public static MusicalInstrument[] GenerateMusicalInstrumentsArray(int length)
    {
        MusicalInstrument[] instruments = new MusicalInstrument[length];
        Random rand = new Random();
        
        for (int i = 0; i < instruments.Length; i++)
        {
            int type = rand.Next(4);
            int id = rand.Next(1000);
    
            switch (type)
            {
                case 0:
                    instruments[i] = new MusicalInstrument("", id);
                    break;
                case 1:
                    instruments[i] = new Guitar(4, id);
                    break;
                case 2:
                    instruments[i] = new ElectricGuitar("аккумулятор", 6, id);
                    break;
                case 3:
                    instruments[i] = new Piano(88, "октавная", id);
                    break;
            }
            instruments[i].RandomInit();
        }
        return instruments;
    }
    
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
    
    public static double AverageGuitarStrings(MusicalInstrument[] instruments)
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
        return numberGuitars > 0 ? (double)totalNumberStrings / numberGuitars : 0;
    }
    
    public static int NumberStringsAllElectricGuitarsFixedPowerSupply(MusicalInstrument[] instruments)
    {
        int totalNumberStrings = 0;

        foreach (var instrument in instruments)
        {
            ElectricGuitar? electricGuitar = instrument as ElectricGuitar;
            if (electricGuitar != null && electricGuitar.PowerSource.ToLower() == "фиксированный источник питания")
            {
                totalNumberStrings += electricGuitar.NumberStrings;
            }
        }
        return totalNumberStrings;
    }
    
    public static int MaxNumberOctavePianoKeys(MusicalInstrument[] instruments)
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

    static void DemonstratePartThree()
    {
        MusicalInstrument[] objects = GenerateMusicalInstrumentsArray(10);

        Guitar searchTarget = new Guitar(8,555);
        searchTarget.Name = "Лучшая гитара";
        objects[objects.Length - 1] = new Guitar(searchTarget.NumberStrings, searchTarget.Id.Id);
        objects[objects.Length - 1].Name = searchTarget.Name;

        foreach (var obj in objects)
        {
            Console.WriteLine(obj);
        }
        
        TextSeparator();
        Console.WriteLine($"Количество объектов класса музыкальный инструмент: {MusicalInstrument.NumberMusicalInstruments}");
        Console.WriteLine($"Количество объектов класса гитары: {Guitar.NumberGuitars}");
        Console.WriteLine($"Количество объектов класса электрогитары: {ElectricGuitar.NumberElectricGuitars}");
        Console.WriteLine($"Количество объектов класса фортепиано: {Piano.NumberPianos}");
        
        TextSeparator();
        Array.Sort(objects);
        foreach (var obj in objects)
        {
            Console.WriteLine(obj);
        }
        
        TextSeparator();
        Console.WriteLine("Сортировка по полю Name");
        int findedIndex = Array.BinarySearch(objects, searchTarget);
        Console.WriteLine($"Студент с именем {searchTarget.Name} найден по индексу: {findedIndex}");
        Console.WriteLine(objects[findedIndex]);
        
        TextSeparator();
        Array.Sort(objects, new NameLengthComparer());
        foreach (var obj in objects)
        {
            Console.WriteLine(obj);
        }
        
        TextSeparator();
        Console.WriteLine("Сортировка по длине поля Name");
        findedIndex = Array.BinarySearch(objects, searchTarget, new NameLengthComparer());
        Console.WriteLine($"Студент с именем {searchTarget.Name} найден по индексу: {findedIndex}");
        Console.WriteLine(objects[findedIndex]);
        
        TextSeparator();
        Console.WriteLine("Демонстрация глубокого и поверхностного копирования на примере Student");
        Student originalStudent = new Student(0, "Александр", 18, 7.17);
        Console.WriteLine($"Исходный студент: \n{originalStudent}");
        
        Student shallowStudent = (Student)originalStudent.ShallowClone();
        Student cloneStudent = (Student)shallowStudent.Clone();

        Console.WriteLine("Изменение возраста");
        originalStudent.Id.Id = 100;

        Console.WriteLine($"Исходный студент: \n{originalStudent}");
        Console.WriteLine($"Копия студента: \n{shallowStudent}");
        Console.WriteLine($"Клон студента: \n{cloneStudent}");
        
    }

    static void Menu()
    {
        Console.WriteLine("1. Вывод первой части");
        Console.WriteLine("2. Вывод второй части");
        Console.WriteLine("3. Вывод третьей части");
    }
    static void Main(string[] args)
    {
        MusicalInstrument[] instruments = GenerateMusicalInstrumentsArray(20);

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
                    DemonstratePartThree();
                    break;
            }
            TextSeparator();
        }
    }
}