using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    // some code from this file is sourced from here: https://www.youtube.com/watch?v=bcPqdCSGCls&ab_channel=Unity

    // the reveal of the fog once the player is moved
    [SerializeField] public int fogReveal = 1;
    // extra fog tilemap
    [SerializeField] private Tilemap fogOfWar;
    [SerializeField] private Tilemap groundMap;

    public LayerMask groundLayer;

    Vector3Int playerTile;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        playerTile = this.groundMap.WorldToCell(transform.position);
        UpdateFogOfWar();

        if (Input.GetMouseButtonDown(0))
        {
            transform.position = ReturnMousePos();
        }
    }



    // https://stackoverflow.com/a/48353867 quite helpful, simple though.
    public Vector3 ReturnMousePos()
    {
        Vector3Int var;

        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;

        var = groundMap.WorldToCell(pos);

        return groundMap.CellToWorld(var);
    }

    public void UpdateFogOfWar()
    {
        Vector3Int currentTile = this.fogOfWar.WorldToCell(transform.position);

        for (int x = -fogReveal; x <= fogReveal; x++)
        {
            for (int y = -fogReveal; y <= fogReveal; y++)
            {
                fogOfWar.SetTile(currentTile + new Vector3Int(x, y, 0), null);
            }
        }
    }
}