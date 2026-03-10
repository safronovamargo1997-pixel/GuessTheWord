using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUIView : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputLetter;
    [SerializeField] private Button _enterButton;
    [SerializeField] private TMP_Text _usedLetters;
    [SerializeField] private Image _healthCount;
    [SerializeField] private Button _easyButton;
    [SerializeField] private Button _normalButton;
    [SerializeField] private Button _hardButton;
    [SerializeField] private TMP_Text _guessWord;
    [SerializeField] private Button _quitButton;
    [SerializeField] private Button _replayButton;
    // обявление доступных в юнити полей для добавления игровых объектов 
    
    private char _letter; //приватная переменная типа char с именем _letter
    private bool _isDifficultySelected = false;
    
    public event Action <char> LetterEntered; //приватное событие,
    //ничего не возвращает,
    //тип данных char
    public event Action <DifficultyType> DifficultySelected;

    private void Start()
    {
        _enterButton.interactable = false;
        _inputLetter.interactable = false;
    }
    private void OnEnable()
    {
        _inputLetter.onValueChanged.AddListener(OnLetterInput);
        _enterButton.onClick.AddListener(OnEnterClick);
        _easyButton.onClick .AddListener(() => OnDifficultyClick(DifficultyType.Easy));
        _normalButton.onClick.AddListener(() => OnDifficultyClick (DifficultyType.Normal));
        _hardButton.onClick.AddListener(() => OnDifficultyClick (DifficultyType.Hard));
        _quitButton.onClick.AddListener(OnQuitScene);
        _replayButton.onClick.AddListener(OnReplayClick);
    }
    
    private void OnDisable()
    {
        _inputLetter.onValueChanged.RemoveListener(OnLetterInput);
        _enterButton.onClick.RemoveListener(OnEnterClick);
        _easyButton.onClick .RemoveListener(() => OnDifficultyClick(DifficultyType.Easy));
        _normalButton.onClick.RemoveListener(() => OnDifficultyClick (DifficultyType.Normal));
        _hardButton.onClick.RemoveListener(() => OnDifficultyClick (DifficultyType.Hard));
    }
    
    private void OnLetterInput(string letter) //метод для проверки введеной буквы
        //и смены регистра
    {
        if (!_isDifficultySelected)
        {
            _inputLetter.SetTextWithoutNotify(string.Empty);
            return;
        }
        if (ValidateLetter(letter))
        {
            string upperLetter = letter.ToUpper();
            _inputLetter.SetTextWithoutNotify(upperLetter);
            _letter = upperLetter[0];
            _enterButton.interactable = true;
            
        }
        else
        {
            _inputLetter.SetTextWithoutNotify(string.Empty);
            _letter = char.MinValue;
            _enterButton.interactable = false;
        }
    }

    private bool ValidateLetter(string letter) //метод для проверки наличия буквы
    {
        if (string.IsNullOrEmpty(letter)) 
            return false;

        if (letter.Length != 1) 
            return false;
        
        
        return char.IsLetter(letter[0]);
    }

    
    private void OnEnterClick() //метод для действий после начатия Enter
    {
        LetterEntered?.Invoke(_letter); //вызов события
        
        _inputLetter.SetTextWithoutNotify(string.Empty); //очистка поля после воода
        _letter = char.MinValue;
        _enterButton.interactable = false;
        
        _inputLetter.Select(); //возвращаемся в поле ввода
    }
    private void OnDifficultyClick(DifficultyType difficulty) //метод для выбора уровня сложности
    {
        _isDifficultySelected = true;

        _inputLetter.interactable = true;
        _inputLetter.Select();
        
        DifficultySelected?.Invoke(difficulty);
        
    }
    
    public void ShowUsedLetters(IEnumerable<char> usedLetters) //метод для отображения выбранных букв,
        //вызывается в GameController
    {
        _usedLetters.text = string.Join(' ', usedLetters);
    }

    public void ShowGuessWord(string mask)
    {
        _guessWord.text = mask;
    }

    public void UpdateHealthCount(int attemptsLeft, int maxAttempts)
    {
        _healthCount.fillAmount = (float)attemptsLeft / maxAttempts;
    }
    
    private void OnQuitScene()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    private void OnReplayClick()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}