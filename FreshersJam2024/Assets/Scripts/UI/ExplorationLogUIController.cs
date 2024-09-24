using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ExplorationLogUIController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TextMeshProUGUI m_TextMeshProUGUI;
    void Start()
    {
        
    }

    public void NewLootTableSelected(ItemLootTable lootTable)
    {
        m_TextMeshProUGUI.text= lootTable.baseDes +"\n"+ lootTable.addedDesc +"\n"+"\n"+m_TextMeshProUGUI.text;
    }
}
