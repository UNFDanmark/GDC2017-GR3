using UnityEngine;
using System.Collections;

public class BackgroundScript : MonoBehaviour {

    public float fallSpeed = 1f;
    public float countDown = 3;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.timeSinceLevelLoad > countDown)
            transform.position = new Vector3(transform.position.x, transform.position.y - fallSpeed * Time.deltaTime, 0);
    }
}
