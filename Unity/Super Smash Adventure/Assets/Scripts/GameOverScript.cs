using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void retry()
    {
        SceneManager.LoadScene("MultiPlayer");
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("TitleScreen");
    }
}
