using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FillGrid : MonoBehaviour
{

    private Tilemap tilemap;
    public TileBase placeTile;
    // Start is called before the first frame update
    void Start()
    {
        tilemap = gameObject.GetComponent<Tilemap>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Mouse0))
        {
            Camera camera = Camera.main;

            Vector2 localPos = camera.ScreenToWorldPoint(Input.mousePosition);

            Vector3Int gridPos = tilemap.WorldToCell(localPos);

            tilemap.SetTile(gridPos, placeTile);
        }
    }
}
