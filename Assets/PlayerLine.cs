using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerLine : MonoBehaviour
{
    private Tilemap tilemap;
    public TileBase placeTile;

    public bool isDrawingLine = false;
    public Vector3Int[] tiles;

    void Start()
    {
        tilemap = GetComponent<Tilemap>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isDrawingLine = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDrawingLine = false;
        }

        if (isDrawingLine && Input.mousePosition != null)
        {
            Vector2 mousePos = Input.mousePosition;
            Vector2 localPos = Camera.current.ScreenToWorldPoint(mousePos);

            Vector3Int tilePos = tilemap.WorldToCell(localPos);
            if(tilePos != null) 
                Debug.Log("Tile Pos: " + tilePos);
            if(canPlaceHere(tilePos)) 
                tilemap.SetTile(tilePos, placeTile);
        }
    }

    bool canPlaceHere(Vector3Int tilePos)
    {
        return tilemap.GetTile(tilePos + new Vector3Int(0, 1, 0)) == placeTile || tilemap.GetTile(tilePos + new Vector3Int(1, 0, 0)) == placeTile
            || tilemap.GetTile(tilePos + new Vector3Int(0, -1, 0)) == placeTile || tilemap.GetTile(tilePos + new Vector3Int(-1, 0, 0)) == placeTile;
    }
}
