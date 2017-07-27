using UnityEngine;
using System.Collections;

public class PlatformScript : MonoBehaviour {

    public float fallSpeed = 0.5f;
    public bool falling = false;
    public GameObject[] patternPrefabs;
    public float patternOffset = 14.25f;

	// Use this for initialization
	void Start () {
	    for( int i=0; i < 100; i++)
        {
            int rand = Random.Range(0, patternPrefabs.Length);
            print(rand);
            Instantiate(patternPrefabs[rand], new Vector3(0, patternOffset*i, 0), Quaternion.identity, transform);
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
