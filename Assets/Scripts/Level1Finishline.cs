using UnityEngine;

// ReSharper disable once IdentifierTypo
public class Level1Finishline : MonoBehaviour
{
    private const string Player = "PinkMan";
    private GameObject _scoreboard;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == Player)
        {
            _scoreboard = GameObject.Find("Scoreboard");
            _scoreboard.SendMessage("Toggle");
        }
    }
}