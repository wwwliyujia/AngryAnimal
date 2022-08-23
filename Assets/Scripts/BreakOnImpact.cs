using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakOnImpact : MonoBehaviour
{
    public float forceNeed = 1000;

    float collisionForce(Collision2D coll)
    {
        float speed = coll.relativeVelocity.sqrMagnitude;
        if (coll.collider.GetComponent<Rigidbody2D>())
        {
            return speed * coll.collider.GetComponent<Rigidbody2D>().mass;
        }
        return speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collisionForce(collision) >= forceNeed)
            Destroy(gameObject);
    }
}
