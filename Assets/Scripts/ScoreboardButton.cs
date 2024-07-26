using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreboardButton : MonoBehaviour
{
    private GameObject _scoreboard;

    public void OnClick()
    {
        _scoreboard = GameObject.Find("Scoreboard");
        _scoreboard.SendMessage("Toggle");
        Debug.Log("Scoreboard: Loading next level...");
        SceneManager.LoadScene("Transition-Graveyard");
    }
}