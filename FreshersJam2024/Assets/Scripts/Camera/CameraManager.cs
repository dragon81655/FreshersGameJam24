using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    // Zoom level
    private float targetZoom;
    private float defaultZoom;

    // Velocity of zoom
    [SerializeField]
    private float zoomVelocity = 2f;

    // Smooth transition
    [SerializeField]
    private float smoothTransition = 0.25f;

    // Time between clicks to consider it a double click
    [SerializeField]
    private float doubleClickTime = 0.2f;

    // See when was the last time we clicked
    private float lastClickTime;

    // Flag to see if we've already zoom in
    private bool HasZoomedIn = false;

    // Flag to check if we're in the process of zooming in or out
    private bool isZooming = false;

    // Camera reference
    [SerializeField]
    private Camera cam;

    // Target position for the camera to move
    private Vector3 targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        defaultZoom = cam.orthographicSize;
        targetZoom = defaultZoom;
        targetPosition = cam.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            CheckForDoubleClick();
        }

        if (isZooming)
        {
            // Smoothly interpolate the camera's position and zoom level
            cam.transform.position = Vector3.Lerp(cam.transform.position, targetPosition, smoothTransition * Time.deltaTime * zoomVelocity);
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetZoom, smoothTransition * Time.deltaTime * zoomVelocity);

            // Check if the camera has reached the target position and zoom level
            if (Vector3.Distance(cam.transform.position, targetPosition) < 0.01f && Mathf.Abs(cam.orthographicSize - targetZoom) < 0.01f)
            {
                // Stop zooming once the target is reached
                isZooming = false;
            }
        }
    }

    void ZoomIn(BaseRoom room)
    {
        // Set the target position to the center of the room
        targetPosition = new Vector3(room.transform.position.x, room.transform.position.y, cam.transform.position.z);

        // Set the target zoom level to be closer
        targetZoom = defaultZoom / 2f;

        // Set the zoom in flag to true
        HasZoomedIn = true;

        // Start the zooming process
        isZooming = true;
    }

    void ZoomOut()
    {
        // reset to the original position and zoom
        targetPosition = new Vector3(0, 0, cam.transform.position.z);
        targetZoom = defaultZoom;

        // Set the zoom in flag to true
        HasZoomedIn = false;

        // Start the zooming process
        isZooming = true;
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
                    if (!HasZoomedIn)
                    {
                        ZoomIn(room);
                    }
                    else
                    {
                        ZoomOut();
                    }
                }
          
            }

            // Update the last click time
            lastClickTime = Time.time;
        }
    }
}
