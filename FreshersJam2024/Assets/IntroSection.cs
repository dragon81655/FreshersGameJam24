using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroSection : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private List<string> sections = new List<string>();
    [SerializeField] private TextMeshProUGUI textMeshPro;
    private int i = 0;
    [SerializeField] private int nextScene;
    [SerializeField] private SceneManagerGame game;
    private void Start()
    {
        textMeshPro.text = sections[i];
        game = GameObject.FindFirstObjectByType<SceneManagerGame>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown)
        {
            i++;
            if (i >= sections.Count)
            {
                SceneManager.LoadScene(nextScene);
                return;
            }
            textMeshPro.text = sections[i];
            
        }
    }
}
