using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    public List<GameObject> currentPlateCount = new List<GameObject>();
    public int numberOfMoves;

    private void Start()
    {
        GameObject[] currentPlates = GameObject.FindGameObjectsWithTag("Plate");
        currentPlateCount.AddRange(currentPlates);
    }

    //IEnumerator CheckForLevelWinCoroutine()
    //{

    //}

    public void CheckForLevelWin()
    {
        if (currentPlateCount.Count <= 0)
        {
            UIController.Instance.ActivateLevelWin();
        }
    }
}
