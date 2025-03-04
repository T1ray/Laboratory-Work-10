﻿namespace Lab10;
using static AdditionalFunctions.AdditionalFunctions;
using Lab9_1;

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
        return numberGuitars > 0 ? (double)totalNumberStrings / numberGuitars : 0;
    }
    
    static int NumberStringsAllElectricGuitarsFixedPowerSupply(MusicalInstrument[] instruments)
    {
        int totalNumberStrings = 0;

        foreach (var instrument in instruments)
        {
            ElectricGuitar? electricGuitar = instrument as ElectricGuitar;
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

    static void DemonstratePartThree()
    {
        IInit[] objects = new IInit[10];
        Random rand = new Random();
        
        for (int i = 0; i < objects.Length-1; i++)
        {
            int type = rand.Next(5);
    
            switch (type)
            {
                case 0:
                    objects[i] = new MusicalInstrument();
                    break;
                case 1:
                    objects[i] = new Guitar();
                    break;
                case 2:
                    objects[i] = new ElectricGuitar();
                    break;
                case 3:
                    objects[i] = new Piano();
                    break;
                case 4:
                    objects[i] = new Student();
                    break;
            }
            objects[i].RandomInit();
        }
        objects[objects.Length - 1] = new Student {Age = 19, Gpa = 8.87, Name = "Константин"};
        Student searchTarget = (Student)objects[objects.Length - 1];

        foreach (var obj in objects)
        {
            Console.WriteLine(obj);
        }
        
        TextSeparator();
        Console.WriteLine($"Количество объектов класса музыкальный инструмент: {MusicalInstrument.NumberMusicalInstruments}");
        Console.WriteLine($"Количество объектов класса гитары: {Guitar.NumberGuitars}");
        Console.WriteLine($"Количество объектов класса электрогитары: {ElectricGuitar.NumberElectricGuitars}");
        Console.WriteLine($"Количество объектов класса фортепиано: {Piano.NumberPianos}");
        Console.WriteLine($"Количество объектов класса студент: {Student.NumberStudents}");
        
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
        findedIndex = Array.BinarySearch(objects, searchTarget);
        Console.WriteLine($"Студент с именем {searchTarget.Name} найден по индексу: {findedIndex}");
        Console.WriteLine(objects[findedIndex]);
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
                    DemonstratePartThree();
                    break;
            }
            TextSeparator();
        }
    }
}