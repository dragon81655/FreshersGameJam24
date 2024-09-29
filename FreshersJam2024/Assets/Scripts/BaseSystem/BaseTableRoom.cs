using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTableRoom : BaseRoom
{
    // Sprite array for members of the family
    [SerializeField]
    public List<SpriteRenderer> FamilyMembersSprites;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if (NewFamilyMemberFound)
        //{
        //  for
        //  AddFamilymember();
        //}

    }

    protected override void OnRoomEntered()
    {
    }

    void AddFamilyMember()
    { 
        if (FamilyMembersSprites.Count <= 3) 
        {
            FamilyMembersSprites.Add(new SpriteRenderer());
        }
    }
}
