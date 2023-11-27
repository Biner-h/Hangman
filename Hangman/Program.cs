using System;
using System.Collections.Generic;
using static System.Random;
using System.Text;

namespace Hangman
{
    internal class Program
    {
        private static void printHangman(int wrong)
        {
            if (wrong == 0)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine("    |");
                Console.WriteLine("    |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 1)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine("O   |");
                Console.WriteLine("    |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 2)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine("O   |");
                Console.WriteLine("|   |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 3)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O  |");
                Console.WriteLine("/|  |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 4)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O  |");
                Console.WriteLine("/|\\ |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 5)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O  |");
                Console.WriteLine("/|\\ |");
                Console.WriteLine("/   |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 6)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O   |");
                Console.WriteLine("/|\\  |");
                Console.WriteLine("/ \\  |");
                Console.WriteLine("   ===");
            }
        }

        private static int printWord(List<char>guessedLetters, String randomWord)
        {
            int counter = 0;
            int rightLetters = 0;
            Console.WriteLine("\r\n");
            foreach (char c in randomWord)
            {
                if (guessedLetters.Contains(c))
                { 
                    Console.Write(c + " ");
                    rightLetters++;
                }
                else
                {
                    Console.Write("  ");
                }
                counter++;
            }
            return rightLetters;
        }

        private static void printLines(String randomWord)
        {
            Console.Write("\r");
            foreach (char _ in randomWord)
            {
                Console.OutputEncoding = System.Text.Encoding.Unicode;
                Console.Write("\u0305 ");
            }
        }

        static void Main()
        {
            Console.WriteLine("Velkommen til hangman :)");
            Console.WriteLine("--------------------------------------------");
            
            Random random = new Random();
            List<String> wordsToGet = new List<String> 
            { 
                "tomat", "bøyeslange", "bananramme", "karaffel", "spekkdiplomat", 
                "tentakkel", "opium", "perrong", "marmelade", "katamaran", "kahytt" 
            };
            int index = random.Next(wordsToGet.Count);
            String randomWord = wordsToGet[index];

            foreach (char _ in randomWord)
            {
                Console.Write("_ ");
            }

            int lengthOfWordToGuess = randomWord.Length;
            int amountOfTimesWrong = 0;
            List<char> currentLetterGuessed = new List<char>();
            int currentLettersRight = 0;

            while (amountOfTimesWrong != 6 && currentLettersRight != lengthOfWordToGuess)
            {
                Console.Write("\nBokstaver gjettet: ");
                foreach (char letter in currentLetterGuessed)
                {
                    Console.Write(letter + " ");
                }
                Console.Write("\nGjett en bokstav: ");
                char letterguessed = Console.ReadLine()[0];
                if (currentLetterGuessed.Contains(letterguessed))
                {
                    Console.Write("\r\nDu har allerede gjettet bokstaven.");
                    printHangman(amountOfTimesWrong);
                    currentLettersRight = printWord(currentLetterGuessed, randomWord);
                    printLines(randomWord);
                }
                else
                {
                    bool right = false;
                    for (int i = 0; i < randomWord.Length; i++)
                    {
                        if (letterguessed == randomWord[i]) { right = true; }
                    }
                    if (right)
                    {
                        printHangman(amountOfTimesWrong);
                        currentLetterGuessed.Add(letterguessed);
                        currentLettersRight = printWord(currentLetterGuessed, randomWord);
                        Console.Write("\r\n");
                        printLines(randomWord);
                    }
                    else
                    {
                        amountOfTimesWrong++;
                        currentLetterGuessed.Add(letterguessed);
                        printHangman(amountOfTimesWrong);
                        currentLettersRight = printWord(currentLetterGuessed, randomWord);
                        Console.Write("\r\n");
                        printLines(randomWord);
                    }
                }
            }
            Console.WriteLine("\r\nSpillet er over :)");
        }
    }
}
