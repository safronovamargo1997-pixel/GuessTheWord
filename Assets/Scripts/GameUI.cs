using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] private Button _menuButton;
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _replayButton;
    [SerializeField] private Button _quitButton;
    [SerializeField] private GameObject _menu;
    [SerializeField] private Slider _volumeSlider;
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private Image _healthLine;
    [SerializeField] private Button _damageButton;

    private string _userName;

    private void Start()
    {
        _menu.SetActive(false);
    }
    private void OnEnable()
    {
        _menuButton.onClick.AddListener(OnMenuClick);
        _playButton.onClick.AddListener(OnPlayClick);
        _replayButton.onClick.AddListener(OnReplayScene);
        _quitButton.onClick.AddListener(OnQuitScene);
        _volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
        _inputField.onValueChanged.AddListener(OnInputFieldChange);
        _damageButton.onClick.AddListener(OnDamageClick);
    }


    private void OnDisable()
    {
        _menuButton.onClick.RemoveListener(OnMenuClick);
        _playButton.onClick.RemoveListener(OnPlayClick);
        _replayButton.onClick.RemoveListener(OnReplayScene);
        _quitButton.onClick.RemoveListener(OnQuitScene);
        _volumeSlider.onValueChanged.RemoveListener(OnVolumeChanged);
        _inputField.onValueChanged.RemoveListener(OnInputFieldChange);
    }

    private void OnDamageClick()
    {
        _healthLine.fillAmount -= 0.1f;
        Debug.Log($"The player has taken damage {1-_healthLine.fillAmount}");
    }
    private void OnInputFieldChange(string text)
    {
        _userName = _inputField.text;
        Debug.Log($"UserName is {_userName}");
    }
    private void OnPlayClick()
    {
        _menu.SetActive(!_menu.activeSelf);
    }
    
    private void OnReplayScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
    private void OnQuitScene()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
    private void OnMenuClick()
    {
        _menu.SetActive(!_menu.activeSelf);
    }
    private void OnVolumeChanged(float value)
    {
        Debug.Log(value);
    }
}