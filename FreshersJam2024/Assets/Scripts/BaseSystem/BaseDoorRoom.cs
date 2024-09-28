using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseDoorRoom : BaseRoom
{
    [SerializeField]
    private Button openDoorButton;

    // Start is called before the first frame update
    void Start()
    {
        openDoorButton.onClick.AddListener(OpenDoor);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void OnRoomEntered()
    {
        // Activate door button click possibility for door
    }

    void OpenDoor()
    {

    }
}
