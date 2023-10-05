using UnityEngine;
using DG.Tweening;
using TMPro;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Collections;

public class UIController : Singleton<UIController>
{
    public GameObject levelWinPanel;
    public TextMeshProUGUI movesCountText;
    public GameObject levelLosePanel;


    private void Start()
    {
        movesCountText.text = LevelManager.Instance.numberOfMoves.ToString();
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
        if (LevelManager.Instance.currentPlateCount.Count > 0 && LevelManager.Instance.numberOfMoves <= 0)
        {
            levelLosePanel.SetActive(true);
        }
    }
}
