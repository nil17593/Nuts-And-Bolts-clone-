using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrewController : MonoBehaviour
{
    public List<GameObject> screws = new List<GameObject>();
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
                    Debug.Log(hit.collider.name);
                    GameObject tappedObject = hit.collider.gameObject;

                    if (tappedObject.GetComponent<Screw>()!=null)
                    {
                        selectedObject = tappedObject;
                        originalPosition = tappedObject.transform.position;
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
                        //HingeJoint2D[] hingeJoint2Ds;
                        //hingeJoint2Ds = selectedObject.GetComponents<HingeJoint2D>();
                        //foreach (HingeJoint2D joint2D in hingeJoint2Ds)
                        //{
                        //joint2D.connectedBody = null;
                        //}
                        selectedObject.GetComponent<Screw>().ChangeScrewPosition();
                    }
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
