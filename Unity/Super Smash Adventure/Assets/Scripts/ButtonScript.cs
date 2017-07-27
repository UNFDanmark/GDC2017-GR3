using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        print("btnScript loaded");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void changeScene()
    {
        print("changeScene");
        SceneManager.LoadScene("Multiplayer");
    }
}
