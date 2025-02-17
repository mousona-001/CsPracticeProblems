/*
Write a C# program that:

Asks the user to enter two numbers.
Asks the user to choose an operation (+, -, *, /).
Performs the chosen operation and displays the result.
Handles division by zero properly.
*/

using System.Diagnostics;

interface Operation
{
    int Execute(int x, int y);
}

class AddOperation : Operation
{
    public int Execute(int x, int y)
    {
        return x + y;
    }
}

class SubtractOperation : Operation
{
    public int Execute(int x, int y)
    {
        return x - y;
    }
}

class ProductOperation : Operation
{
    public int Execute(int x, int y)
    {
        return x * y;
    }
}

class DivisionOperation : Operation
{
    public int Execute(int x, int y)
    {
        try
        {
            return x / y;
        }
        catch (DivideByZeroException ex)
        {
            throw new DivideByZeroException("Denominator can not be Zero");
        }
        catch (Exception e)
        {
            throw new Exception($"An error occurred! {e.Message}");
        }
    }
}

class Calculator
{
    private int num1;
    private int num2;
    private int result;
    public int Number1
    {
        set { num1 = value; }
    }
    public int Number2
    {
        set { num2 = value; }
    }

    public Calculator(int num1, int num2)
    {
        this.num1 = num1;
        this.num2 = num2;
    }

    public void ExecuteOperation(char Operator)
    {
        Operation? operation = null;
        switch (Operator)
        {
            case '+':
                operation = new AddOperation();
                break;
            case '-':
                operation = new SubtractOperation();
                break;
            case '*':
                operation = new ProductOperation();
                break;
            case '/':
                operation = new DivisionOperation();
                break;
            default:
                throw new Exception("Invalid Operation!");
        }
        try
        {
            result = operation.Execute(num1, num2);
            Display();
        }
        catch (Exception e)
        {
            System.Console.WriteLine(e.Message);
        }
    }

    private void Display()
    {
        System.Console.WriteLine(result);
    }
}

class Program
{
    public static void Main(string[] args)
    {
        Calculator calculator = new Calculator(0, 0);
        bool run = true;
        while (run)
        {
            System.Console.WriteLine("Enter number 1: ");
            int num1 = Convert.ToInt32(Console.ReadLine());
            calculator.Number1 = num1;
            System.Console.WriteLine("Enter number 2: ");
            int num2 = Convert.ToInt32(Console.ReadLine());
            calculator.Number2 = num2;
            System.Console.WriteLine("Enter the operator: ");
            char op = Convert.ToChar(Console.ReadLine() ?? "");
            calculator.ExecuteOperation(op);
            System.Console.WriteLine("Continue? Y/N");
            char cont = Convert.ToChar(Console.ReadLine() ?? "");
            if (cont.Equals('N') || cont.Equals('n'))
            {
                run = false;
            }
        }
    }
}
