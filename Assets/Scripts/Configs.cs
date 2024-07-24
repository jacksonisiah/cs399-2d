using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Configs : MonoBehaviour
{
    // On/Off toggle for sound effect
    public static bool SFX { get; set; } = true;

    // Music volume
    public static float MusicVol { set; get; } = 1;

    
    // bye
    public void Start()
    {
        if (!Debug.isDebugBuild)
            Destroy(GameObject.Find("CoolDebugZazu").gameObject); 
    }

    public static void __Debug_DestroyPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("Deleted player prefs");
    }

    public static void __Debug_KillScoreboard()
    {
        Destroy(GameObject.Find("Scoreboard").gameObject);
    }

    public static void __Debug_GotoSceneID()
    {
        var inpt = GameObject.Find("dm_SceneId").GetComponent<Text>();
        var id = int.Parse(inpt.text);

        SceneManager.LoadScene(
            id switch
            {
                1 => "Level1",
                2 => "Level2",
                3 => "Transition-Graveyard",
                _ => "Level1"
            }
        );
    }
}