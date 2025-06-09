Console.WriteLine("Welcome to my console calculator application");

bool keepGoing = true;
double firstNumber;
double secondNumber;
double result = default;

while (keepGoing)
{
    Console.WriteLine("Enter your first number:");

    while (!double.TryParse(Console.ReadLine(), out firstNumber))
    {
        Console.WriteLine("That's not a valid number. Please enter a number (e.g., 4 or 3.14):");
    }

    Console.WriteLine($"You entered: {firstNumber}");

    Console.WriteLine("Enter your second number");

    while (!double.TryParse(Console.ReadLine(), out secondNumber))
    {
        Console.WriteLine("That's not a valid number. Please enter a number (e.g., 4 or 3.14):");
    }

    Console.WriteLine($"You entered: {secondNumber}");

    Console.WriteLine("Choose an operation:");
    Console.WriteLine("A = Add");
    Console.WriteLine("S = Subtract");
    Console.WriteLine("M = Multiply");
    Console.WriteLine("D = Divide");

    char operationChar;
    string operation = string.Empty;

    while (true)
    {
        var keyInfo = Console.ReadKey(true);
        operationChar = char.ToUpper(keyInfo.KeyChar);

        switch (operationChar)
        {
            case 'A':
                operation = "+";
                break;
            case 'S':
                operation = "-";
                break;
            case 'M':
                operation = "*";
                break;
            case 'D':
                operation = "/";
                break;
            default:
                Console.WriteLine("Invalid key. Please press A, S, M, or D.");
                continue; 
        }
        break; 
    }

    Console.WriteLine($"You selected operation: {operation}");

    switch (operation)
    {
        case "+":
            result = firstNumber + secondNumber;
            break;
        case "-":
            result = firstNumber - secondNumber;
            break;
        case "*":
            result = firstNumber * secondNumber;
            break;
        case "/":
            if (secondNumber == 0)
            {
                Console.WriteLine("Error: Cannot divide by zero.");
                while (!double.TryParse(Console.ReadLine(), out secondNumber))
                {
                    Console.WriteLine("That's not a valid number. Try again:");
                }
            }
            else
            {
                result = firstNumber / secondNumber;
            }
            break;
        default:
            Console.WriteLine("Invalid key. Please press A = +, S = -, M = *, or D = /.");
            break;
    }



    Console.WriteLine($"Result {result}");

    Console.WriteLine("Would you like to keep going? Press Y or N on your keyboard");

    var key = Console.ReadKey();

    if(char.ToUpper(key.KeyChar) == 'Y')
    {
        keepGoing = true;
    }
    else if (char.ToUpper(key.KeyChar) == 'N')
    {
        keepGoing = false;
    }
}
