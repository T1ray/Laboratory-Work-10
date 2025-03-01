namespace Lab10;

class Guitar : MusicalInstrument
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

}