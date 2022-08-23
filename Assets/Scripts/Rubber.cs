using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rubber : MonoBehaviour
{
    public Transform leftRubber;
    public Transform rightRubber;

    void adjustRubber(Transform bird, Transform rubber)
    {
        Vector2 dir = rubber.position - bird.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        rubber.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        float dist = Vector3.Distance(bird.position, rubber.position);
        dist += bird.GetComponent<Collider2D>().bounds.extents.x;
        rubber.localScale = new Vector2(dist, 1);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        adjustRubber(collision.transform, leftRubber);
        adjustRubber(collision.transform, rightRubber);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        leftRubber.localScale = new Vector2(0, 1);
        rightRubber.localScale = new Vector2(0, 1);
    }
}
