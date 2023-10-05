using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    public List<GameObject> currentPlateCount = new List<GameObject>();
    public List<Screw> currentScrews = new List<Screw>();
    public int numberOfMoves;
    public ParticleSystem confettiVFX;

    private void Start()
    {
        GameObject[] currentPlates = GameObject.FindGameObjectsWithTag("Plate");
        currentPlateCount.AddRange(currentPlates);

        Screw[] _currentScrews = FindObjectsOfType<Screw>();
        currentScrews.AddRange(_currentScrews);
    }

    //IEnumerator CheckForLevelWinCoroutine()
    //{

    //}

    public bool CheckForPlatesAttachedToScrews()
    {
        foreach(Screw screw in currentScrews)
        {
            if (screw.GetComponent<HingeJoint2D>() != null)
            {
                return true;
            }
        }
        return false;
    }

    public void CheckForLevelWin()
    {
        if (currentPlateCount.Count <= 0)
        {
            confettiVFX.Play();

            UIController.Instance.ActivateLevelWin();
        }
    }
}
