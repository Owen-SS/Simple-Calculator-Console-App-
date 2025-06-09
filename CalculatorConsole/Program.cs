Console.WriteLine("Welcome to my console calculator application");

bool keepGoing = true;

while (keepGoing)
{
    double firstNumber = GetValidNumber("Enter your first number:");
    double secondNumber = GetValidNumber("Enter your second number");
    string operation = GetOperation("Choose an operation:");
    Calculate(firstNumber, secondNumber, operation);
    keepGoing = AskToContinue();
}

double GetValidNumber(string prompt)
{
    double num;
    string input;

    while (true)
    {
        Console.WriteLine(prompt);          
        input = Console.ReadLine() ?? string.Empty;  

        if (double.TryParse(input, out num))
        {
            break;
        }

        Console.WriteLine("That's not a valid number. Please enter a number (e.g., 4 or 3.14):");
    }

    Console.WriteLine($"You entered: {num}");
    return num;
}

double Calculate(double firstNumber, double secondNumber, string operation)
{
    double result = default;
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
    return result;
}

string GetOperation(string prompt)
{
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
    return operation;
}

bool AskToContinue()
{
    Console.WriteLine("Would you like to perform another calculation? (Y/N)");

    while (true)
    {
        var key = Console.ReadKey(true);
        char input = char.ToUpper(key.KeyChar);

        if (input == 'Y')
            return true;
        else if (input == 'N')
            return false;
        else
            Console.WriteLine("Please press 'Y' to continue or 'N' to exit.");
    }
}