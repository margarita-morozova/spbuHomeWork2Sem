using System;

namespace sort
{
    class Program
    {
        const float accuracy = 0.0001f;
        static void Main()
        {
            Console.Write("Введите размер массива: ");
            int amountOfNumbers = Convert.ToInt32(Console.ReadLine());
            var unsortedArray = new float[amountOfNumbers];

            for (int i = 0; i < unsortedArray.Length; i++)
            {
                Console.WriteLine("Введите элемент массива:");
                unsortedArray[i] = Convert.ToSingle(Console.ReadLine());
            }

            BubbleSort(unsortedArray);

            Console.Write("Отсортированный массив: ");
            for (int i = 0; i < unsortedArray.Length; i++)
            {
                Console.Write(unsortedArray[i] + " ");
            }
        }

        static void BubbleSort(float[] unsortedArray)
        {
            int sizeOfArray = unsortedArray.Length;
            for (int i = 0; i < sizeOfArray - 1; i++)
            {
                for (int j = 0; j < sizeOfArray - 1 - i; j++)
                {
                    if (unsortedArray[j] - unsortedArray[j + 1] > accuracy)
                    {
                        float temporaryPlace = unsortedArray[j];
                        unsortedArray[j] = unsortedArray[j + 1];
                        unsortedArray[j + 1] = temporaryPlace;
                    }
                }
            }
        }
    }
}
