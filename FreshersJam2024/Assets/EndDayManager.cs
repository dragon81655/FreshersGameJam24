using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndDayManager : MonoBehaviour
{
    [SerializeField]
    private Button endDayButton;

    // Start is called before the first frame update
    void Start()
    {
        endDayButton.onClick.AddListener(EndDay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void EndDay()
    {

    }
}
