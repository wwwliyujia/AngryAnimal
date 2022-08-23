using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullAndRelease : MonoBehaviour
{
    Vector2 startPos;
    public float force = 1300;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    private void OnMouseUp()
    {
        GetComponent<Rigidbody2D>().isKinematic = false;
        Vector2 dir = startPos - (Vector2)transform.position;
        GetComponent<Rigidbody2D>().AddForce(dir * force);
        Destroy(this);
    }

    private void OnMouseDrag()
    {
        Vector2 p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float radius = 1.8f;
        Vector2 dir = p - startPos;
        if(dir.sqrMagnitude > radius)
        {
            dir = dir.normalized * radius;
        }
        transform.position = startPos + dir;
    }
}
