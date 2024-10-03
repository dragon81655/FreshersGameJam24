using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class recipies : MonoBehaviour
{
    public List<GameObject> recipieImages;
    [SerializeField] public Color invisible;
    [SerializeField] public Color visibleBackground;
    [SerializeField] public Color visibleText;
    bool shown = true;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(toggleRecipies);
        foreach (GameObject recipieImage in recipieImages)
        {
            recipieImage.GetComponent<Image>().color = invisible;
            recipieImage.GetComponentInChildren<TextMeshProUGUI>().color = invisible;
            shown = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void toggleRecipies()
    {
        Debug.Log("recipieImages list " + recipieImages.Count);
        if (shown)
        {
            foreach(GameObject recipieImage in recipieImages)
            {
                recipieImage.GetComponent<Image>().color = invisible;
                recipieImage.GetComponentInChildren<TextMeshProUGUI>().color = invisible;
                shown = false;
            }
        }
        else
        {
            foreach (GameObject recipieImage in recipieImages)
            {
                recipieImage.GetComponent<Image>().color = visibleBackground;
                recipieImage.GetComponentInChildren<TextMeshProUGUI>().color = visibleText;
                shown = true;
            }
        }
    }
}
