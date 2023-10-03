using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    public LevelData levelData;
    private int currentLevelIndex = 0;
    public GameObject levelWinPanel;
    public List<GameObject> currentPlateCount = new List<GameObject>();

    private void Start()
    {
        GameObject[] currentPlates = GameObject.FindGameObjectsWithTag("Plate");
        currentPlateCount.AddRange(currentPlates);
        currentLevelIndex = 0;
        LoadLevel(currentLevelIndex);
    }

    public void LoadNextLevel()
    {
        currentLevelIndex++;

        if (currentLevelIndex < levelData.levels.Length-1)
        {
            LoadLevel(currentLevelIndex);
        }
        else
        {

        }
    }

    private void LoadLevel(int levelIndex)
    {
        Level level = levelData.levels[levelIndex];
        Debug.Log("Loading Level: " + level.levelName);
    }
    public void CheckForLevelWin()
    {
        if (currentPlateCount.Count <= 0)
        {
            levelWinPanel.SetActive(true);
            Debug.Log("YOU WIN");
        }
    }
}
