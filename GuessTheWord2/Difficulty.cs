using System;

namespace GuessTheWord2
{
    public class Difficulty
    {
        private readonly DifficultyType _type;
        
        public Difficulty(DifficultyType type)
        {
            _type = type;

            switch (type)
            {
                case DifficultyType.Easy:
                    Attempts = 10;
                    MinWordLenght = 3;
                    MaxWordLenght = 5;
                    break;
                case DifficultyType.Normal:
                    Attempts = 8;
                    MinWordLenght = 4;
                    MaxWordLenght = 6;
                    break;
                case DifficultyType.Hard:
                    Attempts = 6;
                    MinWordLenght = 5;
                    MaxWordLenght = 7;
                    break;
            }
        }
        
        public int Attempts { get; private set; }
        public int MinWordLenght { get; private set; }
        public int MaxWordLenght { get; private set; }
        
    }
    
    public enum DifficultyType
    {
        Easy,
        Normal,
        Hard
    }   
}