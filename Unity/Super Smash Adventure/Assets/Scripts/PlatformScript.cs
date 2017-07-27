using UnityEngine;
using System.Collections;

public class PlatformScript : MonoBehaviour {

    public float fallSpeed = 0.5f;
    public GameObject[] patternPrefabs;
    public float patternOffset = 30f;
    public float countDown = 3;

	// Use this for initialization
	void Start () {
        Instantiate(patternPrefabs[0], new Vector3(0, 0, 0), Quaternion.identity, transform);
        
	    for( int i=1; i < 100; i++)
        {
            int rand = Random.Range(0, patternPrefabs.Length);
            Instantiate(patternPrefabs[rand], new Vector3(0, patternOffset*i, 0), Quaternion.identity, transform);
        }
	}
	
	// Update is called once per frame
	void Update () {
          if(Time.time > countDown)
            transform.position = new Vector3(transform.position.x, transform.position.y - fallSpeed * Time.deltaTime, 0);
       
	}
}
