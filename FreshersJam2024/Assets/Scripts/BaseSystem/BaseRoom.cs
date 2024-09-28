using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BaseRoom : MonoBehaviour
{
    public bool ZoomedIn;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("base class room");
    }

    // Update is called once per frame
    void Update()
    {
        if (CameraManager.instance.HasZoomedIn)
        {
            OnRoomEntered();
        }
    }

    protected virtual void OnRoomEntered(){}

    public Vector3 GetTilemapCenter()
    {
        Tilemap tilemap = GetComponent<Tilemap>();

        Vector3 centerWorldPosition = Vector3.zero;

        if (tilemap != null)
        {
            // Get the bounds of the tilemap
            BoundsInt roomBounds = tilemap.cellBounds;

            // Calculate the center in local space
            Vector3Int roomCenter = new Vector3Int
                (
                (roomBounds.xMin + roomBounds.xMax) / 2,
                (roomBounds.yMin + roomBounds.yMax) / 2,
                (roomBounds.zMin + roomBounds.zMax) / 2
                );

            // Convert the local center to the world position
            centerWorldPosition = tilemap.CellToWorld(roomCenter);

            // Adjust by adding half a cell size to get the actual center of the tilemap
            centerWorldPosition += tilemap.cellSize / 2f;
        }

        return centerWorldPosition;
    }
}
