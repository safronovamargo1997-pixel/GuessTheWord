using System;

namespace GuessTheWord2
{
    public class ConsoleUI
    {
        public char InputLetter()
        {
            string result = Console.ReadLine();
            return result[0];
        }

        public DifficultyType ChooseDifficulty()
        {
            
        }
    }
} 