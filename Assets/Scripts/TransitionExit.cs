using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionExit : MonoBehaviour
{
    private const string Player = "PinkMan";

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == Player) SceneManager.LoadScene("Level2");
    }
}