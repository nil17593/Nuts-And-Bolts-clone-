using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrewController : MonoBehaviour
{
    public GameObject selectedObject;
    private Vector3 originalPosition;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray);
            if (selectedObject == null)
            {
                if (hit.collider != null)
                {
                    GameObject tappedObject = hit.collider.gameObject;
                    
                    if (tappedObject.GetComponent<Screw>()!=null)
                    {
                        selectedObject = tappedObject;
                        originalPosition = tappedObject.transform.position;
                        selectedObject.transform.position += new Vector3(0, .5f, 0);
                    }
                }
            }
            else if (selectedObject != null)
            {
                Ray ray2 = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit2 = Physics2D.GetRayIntersection(ray);
                if (hit.collider != null)
                {
                    GameObject tappedObject2 = hit.collider.gameObject;

                    if (tappedObject2.CompareTag("ScrewBase"))
                    {
                        selectedObject.transform.position = tappedObject2.transform.position;
                        selectedObject.GetComponent<Screw>().ChangeScrewPosition();
                        UIController.Instance.ReduceMovesCount();
                    }
                    else
                    {
                        if (selectedObject != null)
                        {
                            selectedObject.transform.position = originalPosition;
                            selectedObject = null;
                        }
                    }
                    selectedObject = null;
                }
                else
                {
                    selectedObject.transform.position = originalPosition;
                    selectedObject = null;
                }

            }
            else
            {
                if (selectedObject != null)
                {
                    selectedObject.transform.position = originalPosition;
                    selectedObject = null;
                }
            }
        }
    }
}
