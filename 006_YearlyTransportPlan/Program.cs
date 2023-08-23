using System;

public enum TransportEnum
{
    CAR,
    BUS,
    SUBWAY,
    BIKE,
    WALK
}

public static class TransportEnumExtensions
{
    public static char GetChar(this TransportEnum transport)
    {
        switch (transport)
        {
            case TransportEnum.BIKE: return 'B';
            case TransportEnum.BUS: return 'U';
            case TransportEnum.CAR: return 'C';
            case TransportEnum.SUBWAY: return 'S';
            case TransportEnum.WALK: return 'W';
            default: throw new Exception("Unknown transport");
        }
    }

    public static ConsoleColor GetColor(this TransportEnum transport)
    {
        switch (transport)
        {
            case TransportEnum.BIKE: return ConsoleColor.Blue;
            case TransportEnum.BUS: return ConsoleColor.DarkGreen;
            case TransportEnum.CAR: return ConsoleColor.Red;
            case TransportEnum.SUBWAY: return ConsoleColor.DarkMagenta;
            case TransportEnum.WALK: return ConsoleColor.DarkYellow;
            default: throw new Exception("Unknown transport");
        }
    }
}

class Program
{
    private static string[] GetMonthNames()
    {
        string[] names = new string[12];
        for (int month = 1; month <= 12; month++)
        {
            DateTime firstDay = new DateTime(DateTime.Now.Year, month, 1);
            string name = firstDay.ToString("MMMM");
            names[month - 1] = name;
        }
        return names;
    }

    static void Main(string[] args)
    {
        Random random = new Random();
        int transportTypesCount = Enum.GetNames(typeof(TransportEnum)).Length;
        TransportEnum[][] transport = new TransportEnum[12][];

        for (int month = 1; month <= 12; month++)
        {
            int daysCount = DateTime.DaysInMonth(DateTime.Now.Year, month);
            transport[month - 1] = new TransportEnum[daysCount];

            for (int day = 1; day <= daysCount; day++)
            {
                int randomType = random.Next(transportTypesCount);
                transport[month - 1][day - 1] = (TransportEnum)randomType;
            }
        }

        string[] monthNames = GetMonthNames();
        int monthNamesPart = monthNames.Max(n => n.Length) + 2;

        for (int month = 1; month <= transport.Length; month++)
        {
            Console.Write($"{monthNames[month - 1]}:".PadRight(monthNamesPart));

            for (int day = 1; day <= transport[month - 1].Length; day++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = transport[month - 1][day - 1].GetColor();
                Console.Write(transport[month - 1][day - 1].GetChar());
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(" ");
            }

            Console.WriteLine();
        }
    }
}
