using System.Linq;
using UnityEngine;
using Random = System.Random;

public class WordBank
{
    private Word[] _words; //массив для хранения слов для класса Word
        
    private static Random _random = new Random();
    
    public WordBank() //конструкутор, инициализирует массив _words словами
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
            word.Length >= difficulty.MinWordLength && word.Length <= difficulty.MaxWordLength).ToArray(); //принимает параметр сложности
        if (words.Length == 0)
        {
            Debug.LogWarning($"There are no words of suitable length for {difficulty} complexity");
            return _words[_random.Next(words.Length)];
        }
        var index = _random.Next(words.Length);
        return words[index];
    }
    
    
}