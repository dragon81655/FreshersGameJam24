using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StoryController : MonoBehaviour
{
    // Start is called before the first frame update
    public int basicChance = 10;
    public int addedChance = 20;
    public int currentChance = 0;

    [SerializeField] private ExplorationLogUIController ui;
    void Start()
    {
        currentChance = basicChance;
        ui = GameObject.FindFirstObjectByType<ExplorationLogUIController>();
    }

    public void ProgressStory()
    {
        int roll = UnityEngine.Random.Range(0, 100);
        Debug.Log(roll);
        if(currentChance >= roll )
        {
            string i = StoryProgressionClass.UpdateProgress();
            ui.AddMessage(i);
            currentChance = basicChance;
        }
        else
        currentChance += addedChance;
    }
}
