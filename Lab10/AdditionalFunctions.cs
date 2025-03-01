namespace Lab10;

public class AdditionalFunctions
{
    public static int CorrectIntegerInput()
    {
        bool isNumber = false;
        int intNumber = 0;
        while (!isNumber)
        {
            string input = Console.ReadLine();
            isNumber = int.TryParse(input, out intNumber);
            if (!isNumber)
            {
                Console.WriteLine("Вы ввели не число!");
            }
        }
        return intNumber;
    }
}