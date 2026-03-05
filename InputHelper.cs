public static class InputHelper
{
    public static decimal ReadDecimal(string prompt, decimal minValue = 0, decimal maxValue = decimal.MaxValue)
    {
        decimal value;
        string input;
        bool isValid;

        do
        {
            Console.WriteLine(prompt);
            input = Console.ReadLine()!;
            isValid = decimal.TryParse(input, out value);
            if (!isValid)
            {
                Console.WriteLine("Entrada inválida. Por favor, digite um número decimal válido.");
            }
            else if (value < minValue || value > maxValue)
            {
                Console.WriteLine($"O valor deve estar entre {minValue} e {maxValue}.");
                isValid = false;
            }


        }
        while (!isValid);
        return value;
    }

    public static int ReadInt(string prompt, int minValue = int.MinValue, int maxValue = int.MaxValue)
    {
        int value;
        string input;
        bool isValid;

        do
        {
            Console.Write(prompt);
            input = Console.ReadLine()!;
            isValid = int.TryParse(input, out value);

            if (!isValid)
            {
                Console.WriteLine();
            }
            else if (value < minValue || value > maxValue)
            {
                Console.WriteLine($"O valor deve estar entre {minValue} e {maxValue}.");
                isValid = false;
            }

        } while (!isValid);

        return value;
    }



    public static string ReadString(string prompt, int minLength = 1, int maxLength = 100)
    {
        string value;
        bool isValid;

        do
        {
            Console.Write(prompt);
            value = Console.ReadLine()!;
            isValid = !string.IsNullOrWhiteSpace(value) && value.Length >= minLength && value.Length <= maxLength;

            if (!isValid)
            {
                Console.WriteLine($"Entrada inválida. O texto não pode ser vazio e deve ter entre {minLength} e {maxLength} caracteres.");
            }

        } while (!isValid);

        return value;
    }

}
