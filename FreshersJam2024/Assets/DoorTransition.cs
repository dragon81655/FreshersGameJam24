using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTransition : MonoBehaviour
{
    public GameObject doorsound;

    [SerializeField] private int explorationScene;
   public void WhenClicked()
    {
        GameObject.Find("SceneManager")?.GetComponent<SceneManagerGame>().ChangeScene(explorationScene);

        doorsound.GetComponent<AudioSource>().Play();
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D t = Physics2D.OverlapArea(mousePos + new Vector2(0.5f, 0.5f), mousePos + new Vector2(-0.5f, -0.5f));
            if (!t) return;
            if(t.gameObject.name == "Door")
            {
                WhenClicked();
            }
        }
    }
}
