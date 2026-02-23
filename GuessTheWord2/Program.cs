using System;

namespace GuessTheWord2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var ui = new ConsoleUI();
            ui.ShowUsedLetters(new []{'a', 'b', 'c', 'd', 'e', 'f'});
        }
    }
}