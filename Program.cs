
using System;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {  // q1
            UnderstandingTypes.DisplayTypesInfo();
            Console.WriteLine();
            // q2
            TimeConverter.ConvertCenturies();
            Console.WriteLine();
            //q1 FizzBuzz
            FizzBuzz.Run();
            Console.WriteLine();
            //q2
            ByteOverflow.CheckOverflow();
            Console.WriteLine();
            //q3
            NumberGuessingGame.Play();
            Console.WriteLine();
            //q4
            PyramidPrinter.PrintPyramid();
            Console.WriteLine();
            //q5
            BirthdayCalculator.CalculateAgeAndAnniversary();
            Console.WriteLine();
            //q6
            GreetingByTime.SayHello();
            Console.WriteLine();
            //q7
            FlexibleCounter.Run();
        }
    }

    class UnderstandingTypes
    {
        public static void DisplayTypesInfo()
        {
            Console.WriteLine("{0,-10}{1,10}{2,30}{3,30}", "Type", "Bytes", "Min Value", "Max Value");
            PrintTypeInfo("sbyte", sizeof(sbyte), sbyte.MinValue, sbyte.MaxValue);
            PrintTypeInfo("byte", sizeof(byte), byte.MinValue, byte.MaxValue);
            PrintTypeInfo("short", sizeof(short), short.MinValue, short.MaxValue);
            PrintTypeInfo("ushort", sizeof(ushort), ushort.MinValue, ushort.MaxValue);
            PrintTypeInfo("int", sizeof(int), int.MinValue, int.MaxValue);
            PrintTypeInfo("uint", sizeof(uint), uint.MinValue, uint.MaxValue);
            PrintTypeInfo("long", sizeof(long), long.MinValue, long.MaxValue);
            PrintTypeInfo("ulong", sizeof(ulong), ulong.MinValue, ulong.MaxValue);
            PrintTypeInfo("float", sizeof(float), float.MinValue, float.MaxValue);
            PrintTypeInfo("double", sizeof(double), double.MinValue, double.MaxValue);
            PrintTypeInfo("decimal", sizeof(decimal), decimal.MinValue, decimal.MaxValue);
        }

        static void PrintTypeInfo(string type, int size, object min, object max)
        {
            Console.WriteLine("{0,-10}{1,10}{2,30}{3,30}", type, size, min, max);
        }
    }

    class TimeConverter
    {
        public static void ConvertCenturies()
        {
            Console.Write("Enter number of centuries: ");
            int centuries = int.Parse(Console.ReadLine());
            int years = centuries * 100;
            int days = (int)(years * 365.2422);
            long hours = days * 24L;
            long minutes = hours * 60L;
            long seconds = minutes * 60L;
            long milliseconds = seconds * 1000L;
            decimal microseconds = (decimal)milliseconds * 1000;
            decimal nanoseconds = microseconds * 1000;

            Console.WriteLine($"{centuries} centuries = {years} years = {days} days = {hours} hours = {minutes} minutes");
            Console.WriteLine($"= {seconds} seconds = {milliseconds} milliseconds = {microseconds} microseconds = {nanoseconds} nanoseconds");
        }
    }

    class FizzBuzz
    {
        public static void Run()
        {
            for (int i = 1; i <= 100; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                    Console.WriteLine("fizzbuzz");
                else if (i % 3 == 0)
                    Console.WriteLine("fizz");
                else if (i % 5 == 0)
                    Console.WriteLine("buzz");
                else
                    Console.WriteLine(i);
            }
        }
    }

    class ByteOverflow
    {
        public static void CheckOverflow()
        {
            int max = 500;
            for (byte i = 0; i < byte.MaxValue; i++)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("\nWarning: Loop stops at 255 due to byte overflow.");
        }
    }

    class NumberGuessingGame
    {
        public static void Play()
        {
            int correctNumber = new Random().Next(3) + 1;
            Console.Write("Guess a number between 1 and 3: ");
            int guessedNumber = int.Parse(Console.ReadLine());

            if (guessedNumber < 1 || guessedNumber > 3)
                Console.WriteLine("Out of range!");
            else if (guessedNumber < correctNumber)
                Console.WriteLine("Too low!");
            else if (guessedNumber > correctNumber)
                Console.WriteLine("Too high!");
            else
                Console.WriteLine("Correct!");
        }
    }

    class PyramidPrinter
    {
        public static void PrintPyramid()
        {
            int height = 5;
            for (int i = 1; i <= height; i++)
            {
                for (int j = 1; j <= height - i; j++)
                    Console.Write(" ");

                for (int k = 1; k <= 2 * i - 1; k++)
                    Console.Write("*");

                Console.WriteLine();
            }
        }
    }

    class BirthdayCalculator
    {
        public static void CalculateAgeAndAnniversary()
        {
            Console.Write("Enter your birthdate (yyyy-mm-dd): ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());
            DateTime today = DateTime.Today;
            TimeSpan age = today - birthDate;
            int daysOld = (int)age.TotalDays;

            Console.WriteLine($"You are {daysOld} days old.");

            int daysToNextAnniversary = 10000 - (daysOld % 10000);
            DateTime nextAnniversary = today.AddDays(daysToNextAnniversary);
            Console.WriteLine($"Your next 10,000-day anniversary is on {nextAnniversary.ToShortDateString()}");
        }
    }

    class GreetingByTime
    {
        public static void SayHello()
        {
            DateTime now = DateTime.Now;
            int hour = now.Hour;

            if (hour >= 5 && hour < 12)
                Console.WriteLine("Good Morning");
            if (hour >= 12 && hour < 17)
                Console.WriteLine("Good Afternoon");
            if (hour >= 17 && hour < 21)
                Console.WriteLine("Good Evening");
            if (hour >= 21 || hour < 5)
                Console.WriteLine("Good Night");
        }
    }

    class FlexibleCounter
    {
        public static void Run()
        {
            for (int step = 1; step <= 4; step++)
            {
                for (int i = 0; i <= 24; i += step)
                {
                    Console.Write(i);
                    if (i + step <= 24)
                        Console.Write(",");
                }
                Console.WriteLine();
            }
        }
    }
}
