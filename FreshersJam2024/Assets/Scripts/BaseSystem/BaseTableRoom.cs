using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTableRoom : BaseRoom
{
    // Sprite array for members of the family
    [SerializeField]
    public Dictionary<Transform, List<SpriteRenderer>> FamilyMembersSprites = new Dictionary<Transform, List<SpriteRenderer>>();

    public bool NewFamilyMemberFound;

    public static BaseTableRoom instance { get; private set; }

    // Called before Start
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

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
    }

    public void AddFamilyMember(Transform location, SpriteRenderer spriteRender)
    { 
        if (!FamilyMembersSprites.ContainsKey(location))
        {
            FamilyMembersSprites[location] = new List<SpriteRenderer>();
        }
        FamilyMembersSprites[location].Add(spriteRender);
    }
}
