using System;
using System.Reflection.Metadata.Ecma335;
using System.Security;

namespace BurrowsWheeler
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Если вы хотите выполнить преобразование Барроуза-Уилера, нажмите 0 \n" +
                "Если вы хотите выполнить обратное преобразование, нажмите 1");
            var choice = Convert.ToInt32(Console.ReadLine());
            while (choice != 0 && choice != 1)
            {
                Console.WriteLine("Такой команды не существует.\n" +
                    "Если вы хотите выполнить преобразование Барроуза-Уилера, нажмите 0 \n" +
                    "Если вы хотите выполнить обратное преобразование, нажмите 1");
                choice = Convert.ToInt32(Console.ReadLine());
            }

            if (choice == 0)
            {
                Console.WriteLine("Введите строку для преобразования: ");
                var stringForTransformation = Console.ReadLine();
                while (String.IsNullOrWhiteSpace(stringForTransformation) || stringForTransformation.Length == 1)
                {
                    Console.WriteLine("Строка пустая или состоит из одного символа\n" +
                        "Введите строку для обратного преобразования: ");
                    stringForTransformation = Console.ReadLine();
                }

                var indexOfTheOriginalString = 0;
                var resultString = BurrowsWheelerTransform(stringForTransformation, out indexOfTheOriginalString);
                indexOfTheOriginalString++;
                Console.WriteLine($"Строка после преобразования: {resultString}, позиция конца строки: {indexOfTheOriginalString}.");
            }
            else if (choice == 1)
            {
                Console.WriteLine("Введите строку для обратного преобразования: ");
                string stringForTransformation = Console.ReadLine();
                while (String.IsNullOrWhiteSpace(stringForTransformation) || stringForTransformation.Length == 1)
                {
                    Console.WriteLine("Строка пустая или состоит из одного символа\n" +
                        "Введите строку для обратного преобразования: ");
                    stringForTransformation = Console.ReadLine();
                }

                Console.WriteLine("Введите позицию конца строки: ");
                var positionOfTheLastString = Convert.ToInt32(Console.ReadLine());
                var resultString = ReverseBWT(stringForTransformation, positionOfTheLastString);
                Console.WriteLine($"Строка после обратного преобразования: {resultString}");
            }
        }

        static string BurrowsWheelerTransform(string stringForTransformation, out int indexOfTheOriginalString)
        {
            var lengthOfTheString = stringForTransformation.Length;
            string[] arrayOfShifts = new string[lengthOfTheString];
            arrayOfShifts[0] = stringForTransformation;
            for (int i = 1; i < lengthOfTheString; i++)
            {
                var temporaryPlace = stringForTransformation.Substring(0, i);
                arrayOfShifts[i] = stringForTransformation.Remove(0, i) + temporaryPlace;
            }

            Array.Sort(arrayOfShifts, (x, y) => x.CompareTo(y));
            string resultString = "";
            indexOfTheOriginalString = Array.IndexOf(arrayOfShifts, stringForTransformation);
            for (int i = 0; i < lengthOfTheString; i++)
            {
                resultString += arrayOfShifts[i][lengthOfTheString - 1];
            }

            return resultString;
        }

        static string ReverseBWT(string stringForTransformation, int positionOfTheLastChar)
        {
            var lengthOfTheString = stringForTransformation.Length;
            string[] arrayOfShifts = new string[lengthOfTheString];
            for(int i = 0; i < lengthOfTheString; i++)
            {
                for(int j = 0; j < lengthOfTheString; j++)
                {
                    arrayOfShifts[j] = stringForTransformation[j] + arrayOfShifts[j];
                }
                Array.Sort(arrayOfShifts, (x, y) => x.CompareTo(y));
            }

            return arrayOfShifts[positionOfTheLastChar];
        }

    }
}