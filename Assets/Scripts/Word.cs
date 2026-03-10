using System.Linq;

public class Word
{
     
     private string _value; //приватная переменная "значение"
     
     public int Length => _value.Length;// публичный метод "длина слова"

     public Word(string value)
     {
          _value = value.ToUpper();
     }
     
     public bool Contains(char letter)
     {
          return _value.Contains(char.ToUpper(letter)); //возвращает содержимое значения
     }
     
     public string GetMask(char[] guessLetters)
     {
          var upperGuess = guessLetters.Select(char.ToUpper).ToArray();
          string result =  string.Empty;
          foreach (char letter in _value) // цикл перебирания букв в слове
          {
               if (upperGuess.Contains(letter))
                    result += letter;
               else
                    result += "*";
          }
          return result;
     }
     
     public override string ToString() => _value;
     
     
}