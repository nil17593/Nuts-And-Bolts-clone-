using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void OnPlayButtonPressed()
    {
        if (!PlayerPrefs.HasKey("CurrentLevel"))
        {
            PlayerPrefs.SetInt("CurrentLevel", 1);
            SceneManager.LoadScene(1);
        }
        else
        {
            int i = PlayerPrefs.GetInt("CurrentLevel");
            if (i >= SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(1);
            }
            else
            {
                SceneManager.LoadScene(PlayerPrefs.GetInt("CurrentLevel"));
            }
        }
    }
    
}
