using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseUIManager : MonoBehaviour
{
    [SerializeField]
    private Sprite WaterSprite;

    [SerializeField]
    private Text WaterQuantityText;

    [SerializeField]
    private Sprite PotatoSprite;

    [SerializeField]
    private Text PotatoQuantityText;

    [SerializeField]
    private Button SelectBackpackButton;

    [SerializeField]
    private Button SelectChestButton;

    [SerializeField]
    private Button UpgradeRoomButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
