using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    // some code from this file is sourced from here: https://www.youtube.com/watch?v=bcPqdCSGCls&ab_channel=Unity

    // the reveal of the fog once the player is moved
    [SerializeField] private int fogReveal = 1;
    [SerializeField] private int moveLimit = 2;
    // extra fog tilemap
    [SerializeField] private Tilemap fogOfWar;
    [SerializeField] private Tilemap groundMap;

    [SerializeField] private Sprite waterSprite;

    private LayerMask groundLayer;

    [HideInInspector] public Vector3Int entityTile;

    private void Start()
    {
        
    }

    private void Update()
    {
        entityTile = this.groundMap.WorldToCell(transform.position);
        UpdateFogOfWar();

        if (Input.GetMouseButtonDown(0))
        {
            transform.position = MovePlayer();
        }
    }

    public bool canMoveToTile(Vector3Int tile) // takes cell coords
    {
        bool returnVar;

        if ((groundMap.GetSprite(tile) == null) || (groundMap.GetSprite(tile) == waterSprite))
        {
            returnVar = true;
        } else
        {
            returnVar = false;
        }

        return returnVar;

    }

    public bool MeasureBetweenTiles(Vector3Int firstTile, Vector3Int secondTile)
    {
        bool returnVal = false;

        if (Vector3.Distance(firstTile, secondTile) >= moveLimit)
        {
            returnVal = true;
        } else
        {
            returnVal = false;
        }

        return returnVal;
    }

    // https://stackoverflow.com/a/48353867 quite helpful, simple though.
    private Vector3 MovePlayer()
    {
        Vector3Int var;
        Vector3 returnVar;

        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;

        var = groundMap.WorldToCell(pos);

        // this is HORRIFIC, but it works.
        if (canMoveToTile(var))
        {
            returnVar = transform.position; // returns the current position, so that you don't move.
            Debug.Log("sorry, you cannot move there");
        } 
        else if (!MeasureBetweenTiles(groundMap.WorldToCell(transform.position), var))
        {
            returnVar = groundMap.CellToWorld(var); // returns the new position
        } 
        else
        {
            returnVar = transform.position;
            Debug.Log("sorry, that is outside of your movelimit");
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