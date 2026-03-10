using System;
using System.Linq;

namespace GuessTheWord2
{
    public class WordBank
    {
        private Word[] _words;
        
        public WordBank()
        {
            _words = new[]
            {
                new Word("ide"),
                new Word("dog"),
                new Word("cat"),
                new Word("home"),
                new Word("cold"),
                new Word("unity"),
                new Word("laptop"),
                new Word("family"),
                new Word("teacher"),
                new Word("computer"),
            };
        }

        public Word Generate(Difficulty difficulty)
        {
            var words = _words.Where(word =>
                word.Lenght >= difficulty.MinWordLenght && word.Lenght <= difficulty.MaxWordLenght).ToArray();
            var random = new Random();
            var index = random.Next(words.Length);
            return words[index];
        } 
    }
}