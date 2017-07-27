using UnityEngine;
using System.Collections;

public class PlatformScript : MonoBehaviour {

    public float fallSpeed = 0.5f;
    public bool falling = false;
    public GameObject patternPrefab;
    public float patternOffset = 13.85f;

	// Use this for initialization
	void Start () {
	    for( int i=0; i < 10; i++)
        {
            Instantiate(patternPrefab, new Vector3(0, patternOffset*i, 0), Quaternion.identity, transform);
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (falling)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - fallSpeed * Time.deltaTime, 0);
        }
	}
}
