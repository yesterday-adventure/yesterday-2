using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapManager
{
    private Tilemap mainMap;
    private Tilemap collisionMap;

    public static MapManager Instance;

    public bool CanMove(Vector3Int pos)
    {
        BoundsInt mapBound = mainMap.cellBounds;
        if(pos.x < mapBound.xMin || pos.x > mapBound.xMax || pos.y < mapBound.yMin || pos.y > mapBound.yMax)
        {
            return false;
        }

        return collisionMap.GetTile(pos) == null;
    }

    public Vector3Int GetTilePos(Vector3 worldPos)
    {
        return mainMap.WorldToCell(worldPos);
    }

    public Vector3 GetWorldPos(Vector3Int cellPos)
    {
        return mainMap.GetCellCenterWorld(cellPos);
    }

    public void Init(Transform tilemapObject)
    {
        collisionMap = tilemapObject.Find("Collisions").GetComponent<Tilemap>();
        mainMap = tilemapObject.Find("Background").GetComponent<Tilemap>();
        mainMap.CompressBounds();
    }
}
