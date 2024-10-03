using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using Unity.VisualScripting;
using UnityEngine;

public static class StoryProgressionClass
{
    public static int unlockLevel = 0;

    public static List<StoryProgression> progressions;

    public static int currentStory = 0;


    public static void AddMembers(List<StoryProgression> progression)
    {
        progressions = new List<StoryProgression>();
        for(int i = 0; i < progression.Count; i++)
        {
            progressions.Add(new StoryProgression(0, progression[i].levelString, progression[i].familyMemberName));
        }
    }
    public static string UpdateProgress()
    {
        string toReturn = progressions[currentStory].levelString[progressions[currentStory].currentProgression];
        StoryProgression temp = progressions[currentStory];
        temp.currentProgression++;
        progressions[currentStory] = temp;
        if(temp.currentProgression > 4) currentStory++;
        return toReturn;
    }
}

