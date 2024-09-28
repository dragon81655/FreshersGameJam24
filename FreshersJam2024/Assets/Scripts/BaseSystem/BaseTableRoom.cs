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
        
    }

    protected override void OnRoomEntered()
    {
        // Activate crafting button click possibility for backpack and chest
    }

    void AddFamilyMember() 
    { 
    
    }
}
