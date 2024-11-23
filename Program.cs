using System;

class Program
{
    static int position; 
    static string sequence; 

    static void Main()
    {
        Console.WriteLine("Enter string to verification: ");
        sequence = Console.ReadLine();
        position = 0;

        if (ParseSequence() && position == sequence.Length)
        {
            Console.WriteLine("The string matches the given grammar.");
        }
        else
        {
            Console.WriteLine("The string doesn't match the given grammar.");
        }
    }

    static bool ParseSequence()
    {
        if (!ParseNumber()) 
            return false;

        while (position < sequence.Length && sequence[position] == ',')
        {
            position++;
            if (!ParseNumber())
                return false;
        }

        return true;
    }

    static bool ParseNumber()
    {
        int startPos = position;

       
        if (!ParseInteger())
            return false;


        if (position < sequence.Length && sequence[position] == '.')
        {
            position++;
            if (!ParseFloat())
                return false;
        }

        return true;
    }


    static bool ParseInteger()
    {
        int startPos = position;

        while (position < sequence.Length && char.IsDigit(sequence[position]))
        {
            position++;
        }

        return position > startPos;
    }

    static bool ParseFloat()
    {
        int startPos = position;

        while (position < sequence.Length && char.IsDigit(sequence[position]))
        {
            position++;
        }
        position--;

        if (position < sequence.Length && sequence[position] == '0')
            return false;

        position++;

        return position > startPos;
    }
}
