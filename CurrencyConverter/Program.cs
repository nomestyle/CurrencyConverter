using static CurrencyConverter.Helpers.NumberConverter;
using static CurrencyConverter.Helpers.Enums.Unit;

/**
 * This is a simple console program that will convert numeric values to its word representation.
 **/

bool endApp = false;
Console.WriteLine("C# Currency Converter\r");
Console.WriteLine("------------------------\n");

while (!endApp)
{
    // Declare variables and set to empty.
    string input = "";

    // Ask the user to type the first number.
    Console.Write("Type a number, and then press Enter: ");
    input = Console.ReadLine();

    double cleanDouble = 0;
    while (!double.TryParse(input, out cleanDouble))
    {
        Console.Write("This is not valid input. Please enter a numeric value: ");
        input = Console.ReadLine();
    }

    try
    {
        var value = cleanDouble.ToString("F2").ToString();
        var splitValue = value.TrimStart('-').Split('.');
        var dollar = ConvertNumberToWords(splitValue[0], Dollar);
        var cent = "";

        if (value.Contains('.') && splitValue[0].Length < 13)
        {
            cent = "and " + ConvertNumberToWords(splitValue[1], Cent);
        }

        Console.WriteLine($"{dollar} {cent}");
    }
    catch (Exception e)
    {
        Console.WriteLine("An exception occurred.\n - Details: " + e.Message);
    }

    Console.WriteLine("------------------------\n");

    // Wait for the user to respond before closing.
    Console.Write("Press 'x' and Enter to close the app, or press any other key and Enter to continue: ");
    if (Console.ReadLine() == "x") endApp = true;

    Console.WriteLine("\n"); // Friendly linespacing.
}
return;

