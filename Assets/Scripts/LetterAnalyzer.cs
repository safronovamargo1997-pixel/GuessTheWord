using System.Collections.Generic;

public class LetterAnalyzer
{
    private HashSet<char> _usedLetters = new(); //создание коллекции для хранения
                                                //выбранных букв без дубликатов
    
    public IEnumerable<char> UsedLetters => _usedLetters; //метод для перебора
                                                          //букв в HashSet _usedLetters
    
    public void AddLetter(char letter) //метод для добавления букв в _usedLetters,
                                       //вызывается в GameController.AddLetter
    {
        _usedLetters.Add(letter);   
    }
}