using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screw : MonoBehaviour
{
    public float detectionRadius = 2.0f;
    public List<HingeJoint2D> hingeJoint2s = new List<HingeJoint2D>();
    private void Start()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, -0.01f);

        Collider2D[] nearbyPlates = Physics2D.OverlapCircleAll(transform.position, detectionRadius);
        List<Collider2D> plates = new List<Collider2D>();
        foreach (Collider2D collider in nearbyPlates)
        {
            if (collider.CompareTag("Plate"))
            {
                plates.Add(collider);
            }
        }

        if (plates.Count <= 0)
            return;

        for (int i = 0; i < plates.Count; i++)
        {
            HingeJoint2D joint = gameObject.AddComponent<HingeJoint2D>();
            joint.connectedBody = plates[i].GetComponent<Rigidbody2D>();
            joint.autoConfigureConnectedAnchor = true;
        }
    }

    public void ChangeScrewPosition()
    {
        HingeJoint2D[] hingeJoint2D = gameObject.GetComponents<HingeJoint2D>();
        foreach (HingeJoint2D hingeJoint2D1 in hingeJoint2D)
        {
            Destroy(hingeJoint2D1);
        }

        Collider2D[] nearbyPlates = Physics2D.OverlapCircleAll(transform.position, detectionRadius);
        List<Collider2D> plates = new List<Collider2D>();


        foreach (Collider2D collider in nearbyPlates)
        {
            if (collider.CompareTag("Plate"))
            {
                plates.Add(collider);
            }
        }

        SoundManager.Instance.Play(Sounds.ScrewDown);

        if (plates.Count <= 0)
            return;

        for (int i = 0; i < plates.Count; i++)
        {
            HingeJoint2D joint = gameObject.AddComponent<HingeJoint2D>();
            joint.connectedBody = plates[i].GetComponent<Rigidbody2D>();
            joint.autoConfigureConnectedAnchor = true;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Plate"))
        {
            SoundManager.Instance.Play(Sounds.PlateScrew);
        }
    }
}

