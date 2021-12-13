using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemyController : MonoBehaviour
{
    //[HideInInspector] private int fogReveal; // overwriting, hiding from the inspector
    [SerializeField] private float speed = 2.5f;
    [SerializeField] public int moveLimit = 1;

    [HideInInspector] public Vector3Int entityTile;
    [SerializeField] private Tilemap groundMap;

    [SerializeField] public Transform prefab;

    private Vector3Int basePos;

    Transform gb;


    private void Start()
    {
        entityTile = this.groundMap.WorldToCell(transform.position);
        transform.position = this.groundMap.CellToWorld(this.entityTile); // snaps to grid
        basePos = this.entityTile; // reference for the Move()

        gb = Instantiate(prefab, transform.position - new Vector3(0, moveLimit, -30), Quaternion.identity, transform); // cheating and adding an unecessary script
        gb.gameObject.AddComponent<EnemyDeathDetector>();
        // https://stackoverflow.com/questions/51068774/unity-rotate-an-object-around-a-point-in-2d need to use this 

        StartCoroutine(Move());
    }


    private IEnumerator Move()
    {
        transform.Rotate(0, 0, -moveLimit*3); // decent offset to make everything align

        while (gb.gameObject.activeSelf) {
            yield return Utility.wait(speed);
            transform.Rotate(0, 0, 360 / (moveLimit * 6));
        }

        // FAILED CODE ATTEMPTS: ENTER WITH CAUTION
        // keeping for reference.

        //yield return Utility.wait(speed);
        //transform.position = groundMap.CellToWorld(basePos + new Vector3Int(-1, 0, 0));
        //yield return Utility.wait(speed);
        //transform.position = groundMap.CellToWorld(basePos + new Vector3Int(-1, 1, 0));
        //yield return Utility.wait(speed);
        //transform.position = groundMap.CellToWorld(basePos + new Vector3Int(0, 1, 0));
        //yield return Utility.wait(speed);
        //transform.position = groundMap.CellToWorld(basePos + new Vector3Int(1, 0, 0));
        //yield return Utility.wait(speed);
        //transform.position = groundMap.CellToWorld(basePos + new Vector3Int(0, -1, 0));
        //yield return Utility.wait(speed);
        //transform.position = groundMap.CellToWorld(basePos + new Vector3Int(-1, -1, 0));

        //for (int x = -moveLimit; x <= moveLimit; x++)
        //{
        //    transform.position = groundMap.CellToWorld(basePos + new Vector3Int(x, 0, 0));
        //    yield return Utility.wait(speed);

        //    for (int y = -moveLimit; y < moveLimit; y++)
        //    {
        //        transform.position = groundMap.CellToWorld(basePos + new Vector3Int(y, x, 0));
        //        yield return Utility.wait(speed);

        //    }
        //}
    }

}
