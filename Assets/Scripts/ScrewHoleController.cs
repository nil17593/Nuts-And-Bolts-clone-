using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrewHoleController : MonoBehaviour
{
    public bool isColliding = false;
    public bool canFitScrew = false;
    // OnTriggerStay2D is called when another Collider2D enters or stays within the trigger collider of GameObject A.
    private void OnTriggerStay2D(Collider2D other)
    {
        // Check if the collision is with a game object other than itself.
        if (other.gameObject != gameObject)
        {
            //Debug.Log("HAI");
            isColliding = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject != gameObject)
        {
            //Debug.Log("HAI");
            isColliding = false;
        }
    }

    // Update is called once per frame.
    private void Update()
    {
        // If no collisions are detected, invoke a callback or perform any other desired action.
        if (!isColliding)
        {
            // Do something when there are no collisions.
            canFitScrew = true;
        }
        else
        {
            // Reset the collision flag.
            //isColliding = false;
            canFitScrew = false;
        }
    }
}
