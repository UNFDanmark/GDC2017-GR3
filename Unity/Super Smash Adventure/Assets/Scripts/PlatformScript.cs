using UnityEngine;
using System.Collections;

public class PlatformScript : MonoBehaviour {

    public float fallSpeed = 0.5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new  Vector3 (transform.position.x, transform.position.y-fallSpeed * Time.deltaTime, 0);
	}
}
