using System.Linq;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameUIView _gameUI; //доступное в Юнити поле
    //для связи классов
    [SerializeField] private TMP_Text _resultGame;
        
    private LetterAnalyzer _letterAnalyzer =  new ();
    private Word _guessWord; 
    private WordBank _bank = new(); 
    private Difficulty _difficulty;
    private int _attemptsLeft;

    public void Start()
    {
        _resultGame.enabled = false;
    }
    
    private void OnEnable()
    {
        _gameUI.LetterEntered += OnLetterEntered; //подписка метода OnLetterEntered
        //на событие LetterEntered
        _gameUI.DifficultySelected += OnDifficultySelected; //подписка метода
        //OnDifficultySelected
        //на событие DifficultySelected
    }
    
    private void OnDisable()
    {
        _gameUI.DifficultySelected -= OnDifficultySelected; // отписка
        _gameUI.LetterEntered -= OnLetterEntered; //отписка
    }

    private void OnDifficultySelected(DifficultyType type) //метод - делегат
    {
        _difficulty = new Difficulty(type); //создание экземпляра класса Diff
        _attemptsLeft = _difficulty.Attempts; //связываем переменную "оставшиеся попытки"
        //с кол-вом попыток в классе Diff
        
        StartNewGames();
    }

    private void StartNewGames()
    {
        
        _guessWord = _bank.Generate(_difficulty);
        _letterAnalyzer =  new LetterAnalyzer();
        
        UpdateUI();
    }

    private void OnLetterEntered(char letter) // метод  - делегат 
    {
        if (!_guessWord.Contains(letter))
        {
            _attemptsLeft--;
            _gameUI.UpdateHealthCount(_attemptsLeft, _difficulty.Attempts);
            
            if (_attemptsLeft <= 0)
            {
                GameOver(false);
                return;
            }
        }
        _letterAnalyzer.AddLetter(letter);

        UpdateUI();

        if (CheckWin())
        {
            GameOver(true);
        }
    }
    
    private void UpdateUI() //обновление UI
    {
        _gameUI.ShowUsedLetters(_letterAnalyzer.UsedLetters);
        string mask = _guessWord.GetMask(_letterAnalyzer.UsedLetters.ToArray());
        _gameUI.ShowGuessWord(mask);
    }
    
    private bool CheckWin() //победа, если не осталось звездочек
    {
        string mask = _guessWord.GetMask(_letterAnalyzer.UsedLetters.ToArray());
        return !mask.Contains('*'); 
    }
    
    private void GameOver(bool isWin)
    {
        _resultGame.enabled = true;
        if (isWin)
            _resultGame.text = "You win!";
        else
            _resultGame.text = "You lose! Word: " + _guessWord;

    }
}