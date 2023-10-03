using UnityEngine;

[CreateAssetMenu(fileName = "NewLevelData", menuName = "Level Data")]
public class LevelData : ScriptableObject
{
    public Level[] levels;
}

[System.Serializable]
public class Level
{
    public string levelName;
    public int levelNumber;
    public int targetPlateCount;
}
