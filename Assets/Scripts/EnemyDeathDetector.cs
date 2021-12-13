using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathDetector : MonoBehaviour
{
    private GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    // horribly messy, but it works.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            player.GetComponent<PlayerMovement>().playerScore += gameObject.transform.parent.GetComponent<EnemyController>().points;
            Destroy(gameObject.transform.parent.gameObject);
            //Destroy(gameObject);
        }
    }
}
