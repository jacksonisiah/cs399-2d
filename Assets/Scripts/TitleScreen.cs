using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScreen : MonoBehaviour
{
    public AudioClip buttonClickSFX;
    public AudioClip buttonSelectSFX;
    [SerializeField]
    private AudioSource cameraAudioSource;
    [SerializeField]
    private AudioSource menuAudioSource;
    public Slider sldMusicVolume;
    public Toggle sfxToggle;
    
   public void LoadLevel() => 
      SceneManager.LoadScene("Level1");

   public void Start()
   {
       menuAudioSource = GetComponent<AudioSource>();
       cameraAudioSource = Camera.main!.GetComponent<AudioSource>();

       sldMusicVolume.value = cameraAudioSource.volume;
       menuAudioSource.PlayOneShot(buttonClickSFX);

       sfxToggle.isOn = Configs.SFX;
   }

   public void OnVolumeChange()
   {
       cameraAudioSource.volume = sldMusicVolume.value;
   }

   public void OnButtonClick()
   {
       if (Configs.SFX)
           menuAudioSource.PlayOneShot(buttonClickSFX);
   }

   public void OnButtonSelect()
   {
       if (Configs.SFX)
        menuAudioSource.PlayOneShot(buttonSelectSFX);
   }

   public void Exit()
   {
#if UNITY_EDITOR
      EditorApplication.isPlaying = false;
#else
      Application.Quit();
#endif 
   }

   public void OnSFXToggle()
   {
       Configs.SFX = !Configs.SFX;
   }
}
