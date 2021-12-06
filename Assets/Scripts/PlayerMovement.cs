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
    [SerializeField] public int moveLimit = 2;
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
            transform.position = MovePlayer();
        }
    }

    public bool isTileEmpty(Vector3Int tile) // takes cell coords
    {
        bool returnVar;

        if (groundMap.GetSprite(tile) == null)
        {
            returnVar = true;
        } else
        {
            returnVar = false;
        }

        return returnVar;

    }

    // https://stackoverflow.com/a/48353867 quite helpful, simple though.
    public Vector3 MovePlayer()
    {
        Vector3Int var;
        Vector3 returnVar;

        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;

        var = groundMap.WorldToCell(pos);

        if (isTileEmpty(var))
        {
            returnVar = transform.position; // returns the current position, so that you don't move.
            Debug.Log("sorry, you cannot move to an empty tile");
        } else
        {
            returnVar = groundMap.CellToWorld(var); // returns the new position
        }

        return returnVar;
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