using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
   public void LoadLevel() => 
      SceneManager.LoadScene("Level1");

   public void Exit()
   {
#if UNITY_EDITOR
      EditorApplication.isPlaying = false;
#else
      Application.Quit();
#endif 
   }
}
