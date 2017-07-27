using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour {

    public Text winningPlayer;
	// Use this for initialization
	void Start () {
        winningPlayer.text = PlayerScripts.winningPlayer + " wins!";
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
        SceneManager.LoadScene("Title Screen");
    }
}
