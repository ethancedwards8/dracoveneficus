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

    private Vector3Int basePos;

    private void Start()
    {
        entityTile = this.groundMap.WorldToCell(transform.position);
        transform.position = this.entityTile; // snaps to grid
        basePos = this.entityTile; // reference for the Move()
        StartCoroutine(Move());
    }
    
    private IEnumerator Move()
    {
        yield return Utility.wait(speed);
        transform.position = groundMap.CellToWorld(basePos + new Vector3Int(-1, 1, 0));

        //for (int x = -moveLimit; x <= moveLimit; x++)
        //{
        //    yield return Utility.wait(speed);
        //    transform.position = groundMap.CellToWorld(basePos + new Vector3Int(x, 0, 0));
        //    for (int y = -moveLimit; y <= moveLimit; y++)
        //    {
        //        yield return Utility.wait(speed);
        //        transform.position = groundMap.CellToWorld(basePos + new Vector3Int(x, -y, 0));
        //    }
        //}
    }

}
