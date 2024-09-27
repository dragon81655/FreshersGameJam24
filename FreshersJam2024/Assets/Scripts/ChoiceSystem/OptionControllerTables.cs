using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionControllerTables : MonoBehaviour
{
    private Options[] ops = new Options[4];
    private ExplorationManager explorationManager;

    [Header("UI")]
    [SerializeField] private Button[] buttons;
    [SerializeField] private TextMeshProUGUI textMeshProUGUI;

    private void Start()
    {
        explorationManager = FindFirstObjectByType<ExplorationManager>();
    }
    public void OptionChosen(int op)
    {
        explorationManager.OptionChose(ops[op]);
        foreach(Button b in buttons)
        {
            b.gameObject.SetActive(false);
        }
        gameObject.SetActive(false);
    }

    public void LoadOptions(OptionBaseExploration op)
    {
        ops = op.options;
        UIUpdate(op);
    }

    private void UIUpdate(OptionBaseExploration op)
    {
        //I'm too tired for this shit, I will just make the UI Update on a different method...
        for (int i = 0; i < op.options.Length; i++)
        {
            buttons[i].gameObject.SetActive(true);
            int t = i;
            buttons[i].onClick.RemoveAllListeners();
            buttons[i].onClick.AddListener(() => { OptionChosen(t); });
            buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = op.options[i].text;
            textMeshProUGUI.text = op.text;
        }
    }
}
