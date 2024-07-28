using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadTitleScene : MonoBehaviour
{
   public void LoadTitle()
   {
      SceneManager.LoadScene("TitleScreen");
   } 
}
