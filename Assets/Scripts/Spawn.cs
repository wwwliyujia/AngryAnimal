using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    // 鸟的预制体
    public GameObject birdPrefab;
    // 鸟是否在触发区域
    bool occupied = false;

    private void FixedUpdate()
    {
        if (!occupied && !sceneMoving())
        {
            spawnNext();
        }
    }

    void spawnNext()
    {
        Instantiate(birdPrefab, transform.position, Quaternion.identity);
        occupied = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        occupied = false;
    }

    bool sceneMoving()
    {
        Rigidbody2D[] bodies = FindObjectsOfType(typeof(Rigidbody2D)) as Rigidbody2D[];
        foreach (Rigidbody2D rb in bodies)
        {
            if (rb.velocity.sqrMagnitude > 5)
                return true;
        }
        return false;
    }
}
