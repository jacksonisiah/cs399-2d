using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Configs : MonoBehaviour
{
    // On/Off toggle for sound effect
    public static bool SFX { get; set; } = true;

    // Music volume
    public static float MusicVol { set; get; } = 1;

    private TMP_Text __Debug_Timescale;
    private TMP_Text __Debug_Frametime;
    private TMP_Text __Debug_FPS;
    
    public float timeLastFrame;
    
    
    private GameObject __Debug_Zazu;
    
    // bye
    public void Start()
    {
        __Debug_Zazu = GameObject.Find("CoolDebugZazu");
        
        if (!Debug.isDebugBuild)
            Destroy(__Debug_Zazu);

        timeLastFrame = Time.realtimeSinceStartup;
        
        __Debug_Frametime = GameObject.Find("txtFrameTime").GetComponent<TMP_Text>(); 
        __Debug_Timescale = GameObject.Find("txtTimescale").GetComponent<TMP_Text>();
        __Debug_FPS = GameObject.Find("txtFps").GetComponent<TMP_Text>();
    }

    private void Update()
    {
        if (!Debug.isDebugBuild)
            return;
        
        var realDeltaTime = Time.realtimeSinceStartup - timeLastFrame;
        timeLastFrame = Time.realtimeSinceStartup;

        __Debug_Frametime.text = $"Update Frametime: {realDeltaTime*1000:F3}ms";
        __Debug_Timescale.text = $"Timescale: {Time.timeScale}";
        __Debug_FPS.text = $"FPS: {(int)(1f / Time.unscaledDeltaTime)}";
    }

    
    
    public static void __Debug_DestroyPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("Deleted player prefs");
    }

    public static void __Debug_KillScoreboard()
    {
        GameObject.Find("Scoreboard").SetActive(false);
        GameObject.Find("GameOverScreen").SetActive(false);
        GameObject.Find("PauseMenu").SetActive(false);
        GameObject.Find("HUD").SetActive(false); 
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