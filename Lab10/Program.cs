using Lab10;

namespace Lab10;
using static AdditionalFunctions;

class Program
{
    
    static void DemonstratePartOne(MusicalInstrument[] instruments)
    {
        // Не виртупльная функция show
        foreach (MusicalInstrument instrument in instruments)
        {
            instrument.Show();
        }

        TextSeparator();
        
        // Виртуальная функция show
        foreach (MusicalInstrument instrument in instruments)
        {
            instrument.VirtualShow();
        }
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
        DemonstratePartOne(instruments);
    }
}