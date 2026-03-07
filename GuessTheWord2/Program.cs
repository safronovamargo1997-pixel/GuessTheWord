using System;

namespace GuessTheWord2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var game = new Game(10);
            game.AddLetter('a', true);
            
        }
    }
}