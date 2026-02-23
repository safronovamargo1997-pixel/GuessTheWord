using System;
using System.Linq;

namespace GuessTheWord2
{
    public class Word
    {
        private readonly string _value;

        public Word(string value)
        {
            _value = value;
        }
        
        public int Lenght => _value.Length;

        public bool Contains(char letter)
        {
            return _value.Contains(letter.ToString());
        }

        public string GetMask(char[] guessedLetters)
        {
            string result = string.Empty;

            foreach (char letter in _value)
            {
                if (guessedLetters.Contains(letter))
                    result += letter;
                else
                    result += "*";
            }
            return result;
        }

        public void DebugValue()
        {
            Console.WriteLine(_value);
        }
    }
}