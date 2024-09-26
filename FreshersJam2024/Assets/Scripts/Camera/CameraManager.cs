using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    // Zoom level
    private float zoom;

    // Velocity of zoom
    private float zoomVelocity = 2f;

    // Smooth transition
    private float smoothTransition = 0.25f;

    // Time between clicks to consider it a double click
    [SerializeField]
    private float doubleClickTime = 0.2f;

    // See when was the last time we clicked
    private float lastClickTime;

    // Flag to see if we've already zoom in
    private bool HasZoomIn = false;

    // Camera reference
    [SerializeField]
    private Camera cam = null;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            CheckForDoubleClick();
        }
    }

    void ZoomIn(BaseRoom room)
    {
        // Set the target position to the center of the room
        Vector3 targetPosition = new Vector3(room.transform.position.x, room.transform.position.y, cam.transform.position.z);

        // Set the zoom in flag to true
        HasZoomIn = true;
    }

    void ZoomOut()
    {

        // Set the zoom in flag to true
        HasZoomIn = false;
    }

    void CheckForDoubleClick()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

        // Check left mouse button click
        if (Input.GetMouseButtonDown(0)) 
        { 
            float timeSinceLastClick = Time.time - lastClickTime;

            if (timeSinceLastClick <= doubleClickTime) 
            {
                BaseRoom room = hit.collider.GetComponent<BaseRoom>();

                if (room != null) 
                { 
                    if (!HasZoomIn)
                    {
                        ZoomIn(room);
                    }
                    else
                    {
                        ZoomOut();
                    }
                }
          
            }
        }
    }
}
