using System;

namespace GuessTheWord2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            

            char[] guessedLetters = new[] { 'h', 'a' , 'e', 'i', 'o', 'u', 'y' };
            
            var easyMode = new Difficulty(DifficultyType.Easy);
            var normalMode = new Difficulty(DifficultyType.Normal);
            var hardMode = new Difficulty(DifficultyType.Hard);
            
            var wordBank =  new WordBank();
            var generateWord = wordBank.Generate(hardMode);
            generateWord.DebugValue();
            
            Console.WriteLine($"{generateWord.GetMask(guessedLetters)}");

            
            
        }
    }
}