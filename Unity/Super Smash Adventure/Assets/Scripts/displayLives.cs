using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class displayLives : MonoBehaviour {

    public Image[] hearts = new Image[5];
    public Sprite full;
    public Sprite empty;
    public GameObject player;
    private PlayerScripts playerScript;

   
    void Awake()
    {
        playerScript = player.GetComponent<PlayerScripts>();
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    for (int i = 0; i < playerScript.lives; i++)
        {
            hearts[i].sprite = full;
        }
        for (int i = playerScript.lives; i < 5; i++)
        {
            hearts[i].sprite = empty;
        }
	}
}
