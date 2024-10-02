using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryLoader : MonoBehaviour
{
    [SerializeField] private List<StoryProgression> stories;
    void Start()
    {
        StoryProgressionClass.AddMembers(stories);
    }

}
