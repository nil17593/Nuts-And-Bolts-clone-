using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrewController : MonoBehaviour
{
    public GameObject selectedObject;
    private Vector3 originalPosition;
    public GameObject duplicateScrew;
    private void Update()
    {
        if (LevelManager.Instance.numberOfMoves <= 0)
            return;

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
                        selectedObject.GetComponent<SpriteRenderer>().enabled = false;
                        duplicateScrew.transform.position = originalPosition + new Vector3(0, .5f, 0);
                        duplicateScrew.SetActive(true);
                        //selectedObject.transform.position += new Vector3(0, .5f, 0);
                    }
                }
            }
            else if (selectedObject != null)
            {
                Ray ray2 = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit2 = Physics2D.GetRayIntersection(ray2);
                if (hit2.collider != null)
                {
                    GameObject tappedObject2 = hit2.collider.gameObject;

                    ScrewHoleController screwHole = hit.collider.gameObject.GetComponent<ScrewHoleController>();
                    if (screwHole != null && screwHole.canFitScrew)
                    {
                        selectedObject.transform.position = tappedObject2.transform.position + new Vector3(0, 0, -0.01f);
                        selectedObject.GetComponent<SpriteRenderer>().enabled = true;
                        selectedObject.GetComponent<Screw>().ChangeScrewPosition();
                        duplicateScrew.SetActive(false);
                        UIController.Instance.ReduceMovesCount();
                    }
                    else
                    {
                        selectedObject.GetComponent<SpriteRenderer>().enabled = true;
                        selectedObject.transform.position = originalPosition + new Vector3(0, 0, -0.01f);
                        selectedObject = null;
                        duplicateScrew.SetActive(false);
                    }
                    selectedObject = null;
                }
                else
                {
                    selectedObject.GetComponent<SpriteRenderer>().enabled = true;
                    selectedObject.transform.position = originalPosition + new Vector3(0, 0, -0.01f);
                    selectedObject = null;
                    duplicateScrew.SetActive(false);
                }

            }
            else
            {
                if (selectedObject != null)
                {
                    selectedObject.GetComponent<SpriteRenderer>().enabled = true;
                    selectedObject.transform.position = originalPosition + new Vector3(0, 0, -0.01f);
                    selectedObject = null;
                    duplicateScrew.SetActive(false);
                }
            }
        }
    }
}
