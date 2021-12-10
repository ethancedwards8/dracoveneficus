using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathDetector : MonoBehaviour
{
    // horribly messy, but it works.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collision");
        if (collision.gameObject.name == "Player")
        {
            Destroy(gameObject);
        }
    }
}
