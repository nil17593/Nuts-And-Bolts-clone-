using UnityEngine;
using DG.Tweening;
using TMPro;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class UIController : Singleton<UIController>
{
    public GameObject levelWinPanel;
    public TextMeshProUGUI movesCountText;
    public GameObject levelLosePanel;
    public Button soundOnButton;
    public Button soundOffButton;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("Sound"))
        {
            PlayerPrefs.SetInt("Sound", 1);
        }

        bool isSoundOn = PlayerPrefs.GetInt("Sound") == 1;
        soundOnButton.gameObject.SetActive(isSoundOn);
        soundOffButton.gameObject.SetActive(!isSoundOn);
        SoundManager.Instance.Mute(!isSoundOn);

        movesCountText.text = LevelManager.Instance.numberOfMoves.ToString();
    }


    public void OnSoundOnButtonPressed()
    {
        PlayerPrefs.SetInt("Sound", 0);
        soundOffButton.gameObject.SetActive(true);
        soundOnButton.gameObject.SetActive(false);
        SoundManager.Instance.Mute(true);

    }

    public void OnSoundOffButtonPressed()
    {
        PlayerPrefs.SetInt("Sound", 1);
        soundOnButton.gameObject.SetActive(true);
        soundOffButton.gameObject.SetActive(false);
        SoundManager.Instance.Mute(false);
    }

    IEnumerator WinCoroutine()
    {
        yield return new WaitForSeconds(2f);
        levelWinPanel.SetActive(true);
        int i = PlayerPrefs.GetInt("CurrentLevel");
        i += 1;
        PlayerPrefs.SetInt("CurrentLevel", i);
    }

    public void OnMainMenuButtonPressed()
    {
        SceneManager.LoadScene(0);
    }

    public void ActivateLevelWin()
    {
        //levelWinPanel.transform.DOMove(Vector3.zero, 1f);
        StartCoroutine(WinCoroutine());   
    }

    public void OnNextLevelButtonPressed()
    {
        int i = PlayerPrefs.GetInt("CurrentLevel");
        Debug.Log(i);
        if (i >= SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(1);
            PlayerPrefs.SetInt("CurrentLevel", 1);
        }
        else
        {
            SceneManager.LoadScene(i);
        }
    }

    public void OnRestartButtonClick()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void ReduceMovesCount()
    {
        LevelManager.Instance.numberOfMoves -= 1;
        int moves = LevelManager.Instance.numberOfMoves;
        movesCountText.rectTransform.DOShakeScale(0.1f, 1, 10, 90).OnComplete(() => { 
        movesCountText.text = moves.ToString();
        });
        StartCoroutine(CoroutineForLevelLose());
    }

    IEnumerator CoroutineForLevelLose()
    {
        yield return new WaitForSeconds(0.2f);
        if (LevelManager.Instance.numberOfMoves <= 0)
        {
            if (LevelManager.Instance.CheckForPlatesAttachedToScrews())
            {
                levelLosePanel.SetActive(true);
            }
        }
    }
}
