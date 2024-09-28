using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseRoom : MonoBehaviour
{
    [SerializeField] 
    public SpriteRenderer BaseRoomSprite;

    public bool ZoomedIn;

    // Start is called before the first frame update
    void Start()
    {
        
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
}
