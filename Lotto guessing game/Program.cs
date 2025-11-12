using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotto_guessing_game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int attemptsAllowed = 3;
            int numberCount = 6;
            int maxNumber = 49;

            Console.WriteLine("Welcome to the Number Guessing Game!");
            Console.WriteLine("------------------------------------\n");

            while (true)
            {
                List<int> lotteryNumbers = new List<int>();
                while (lotteryNumbers.Count < numberCount)
                {
                    int num = rnd.Next(1, maxNumber + 1);
                    if (!lotteryNumbers.Contains(num))
                        lotteryNumbers.Add(num);
                }

                List<int> userNumbers = new List<int>();
                Console.WriteLine($"Please enter {numberCount} unique numbers between 1 and {maxNumber}:");

                while (userNumbers.Count < numberCount)
                {
                    Console.Write($"Number {userNumbers.Count + 1}: ");
                    bool valid = int.TryParse(Console.ReadLine(), out int guess);
                    if (!valid || guess < 1 || guess > maxNumber || userNumbers.Contains(guess))
                    {
                        Console.WriteLine("Invalid number or already entered. Try again.");
                    }
                    else
                    {
                        userNumbers.Add(guess);
                    }
                }

                int correctCount = 0;
                foreach (var num in userNumbers)
                {
                    if (lotteryNumbers.Contains(num))
                        correctCount++;
                }

                Console.WriteLine("\nLottery numbers: " + string.Join(", ", lotteryNumbers));
                Console.WriteLine("Your numbers: " + string.Join(", ", userNumbers));
                Console.WriteLine($"You guessed {correctCount} number(s) correctly!\n");

                attemptsAllowed--;
                if (attemptsAllowed > 0)
                {
                    Console.WriteLine($"You have {attemptsAllowed} attempt(s) left.");
                    Console.Write("Do you want to play again? (yes/no): ");
                    string again = Console.ReadLine().ToLower();
                    if (again != "yes")
                        break;
                }
                else
                {
                    Console.WriteLine("No attempts left. Game over!");
                    break;
                }

                Console.WriteLine();
            }

            Console.WriteLine("Thank you for playing!");
        }
    }
}