using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateCatcher : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Plate"))
        {
            Destroy(collision.gameObject);
            if (LevelManager.Instance.currentPlateCount.Contains(collision.gameObject))
            {
                LevelManager.Instance.currentPlateCount.Remove(collision.gameObject);
            }
            LevelManager.Instance.CheckForLevelWin();
        }
    }
}
