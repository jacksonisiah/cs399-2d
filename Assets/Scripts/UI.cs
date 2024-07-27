using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField]
    private GameObject _pauseMenu;
    [SerializeField] 
    private GameObject _gameOverScreen;
    private bool _isPaused = false;
    private Text _lives;
    private Text _fruit;
    private PinkMan _player;
    
    private bool _isConfirmState = false;

    private void Start()
    {
        _pauseMenu.SetActive(false);
        _fruit = GameObject.Find("Items_Text").GetComponent<Text>();
        _lives = GameObject.Find("Lives_Text").GetComponent<Text>();
        _player = GameObject.Find("PinkMan").GetComponent<PinkMan>();
    }

    // Update is called once per frame
    private void Update()
    {
        _lives.text = $"x{_player.Lives.ToString()}";
        _lives.color = _player.Lives <= 1 ? Color.red : Color.white;
        _fruit.text = $"Items: {_player.ItemsCount.ToString()}";

        OnEscPress();
    }

    private void OnEscPress()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            if (_isPaused)
                Resume();
            else
                PauseMenu();
    }

    private void PauseMenu()
    {
        if (_gameOverScreen.activeSelf)
            return;
        
        _pauseMenu.SetActive(true);
        Time.timeScale = 0;
        _isPaused = true;
    }

    public void Resume()
    {
        _pauseMenu.SetActive(false);
        Time.timeScale = 1;
        _isPaused = false;
        _isConfirmState = false;
    }

    public void ShowGameOver()
    {
        _gameOverScreen.SetActive(true);
        Time.timeScale = 0;
        _isPaused = false;
    }
   
    public void Restart()
    {
        Time.timeScale = 1;
        _isConfirmState = false;
        _isPaused = false;
        PlayerPrefs.SetInt("Lives", 3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        _gameOverScreen.SetActive(false);
    }

    public void QuitToTitle()
    {
        // we use the calling component to display a confirmation 
        if (!_isConfirmState)
        {
            if (!_isPaused)
            { 
                var goBtn = GameObject.Find("goTxtBtnQuit").GetComponent<TMP_Text>();
                goBtn.text = "Confirm?";
            }
            else
            {
                var pmBtn = GameObject.Find("pmTxtBtnQuit").GetComponent<TMP_Text>();
                pmBtn.text = "Confirm?";
            }
            _isConfirmState = true;
            return;
        }

        _isConfirmState = false; // todo: reset if another button pressed?
        SceneManager.LoadScene("TitleScreen");
    }
        
}