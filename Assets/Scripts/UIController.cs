using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.SceneManagement;

public class UIController : Singleton<UIController>
{
    public GameObject levelWinPanel;
    public TextMeshProUGUI movesCountText;
    public GameObject levelLosePanel;

    private void Start()
    {
        movesCountText.text = LevelManager.Instance.numberOfMoves.ToString();
    }

    public void ActivateLevelWin()
    {
        //levelWinPanel.transform.DOMove(Vector3.zero, 1f);
        levelWinPanel.SetActive(true);
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
