using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Plate"))
        {
            // Handle the collision with the plate.
            RemovePlateFromHingeJoints(collision.gameObject);
        }
    }

    void RemovePlateFromHingeJoints(GameObject plate)
    {
        Screw[] bObjects = FindObjectsOfType<Screw>();
        foreach (Screw bObject in bObjects)
        {
            HingeJoint2D[] hingeJoints = bObject.GetComponents<HingeJoint2D>();
            foreach (HingeJoint2D hingeJoint2D in  hingeJoints)
            {
                if (hingeJoint2D.connectedBody != null && hingeJoint2D.connectedBody.gameObject == plate)
                {
                    Destroy(plate);
                    if (LevelManager.Instance.currentScrews.Contains(bObject))
                    {
                        LevelManager.Instance.currentScrews.Remove(bObject);
                    }
                    Destroy(hingeJoint2D.gameObject);
                }
            }
        }
        if (LevelManager.Instance.currentPlateCount.Contains(plate))
        {
            LevelManager.Instance.currentPlateCount.Remove(plate);
        }
        Destroy(gameObject);
    }

}
