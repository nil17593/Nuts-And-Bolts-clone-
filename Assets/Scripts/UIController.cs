using UnityEngine;
using DG.Tweening;
using TMPro;

public class UIController : Singleton<UIController>
{
    public GameObject levelWinPanel;
    public TextMeshProUGUI movesCountText;

    private void Start()
    {
        movesCountText.text = LevelManager.Instance.numberOfMoves.ToString();
    }

    public void ActivateLevelWin()
    {
        //levelWinPanel.transform.DOMove(Vector3.zero, 1f);
        levelWinPanel.SetActive(true);
    }

    public void ReduceMovesCount()
    {
        LevelManager.Instance.numberOfMoves -= 1;
        int moves = LevelManager.Instance.numberOfMoves;
        movesCountText.rectTransform.DOShakeScale(0.1f, 1, 10, 90).OnComplete(() => { 
        movesCountText.text = moves.ToString();
        });
    }
}
