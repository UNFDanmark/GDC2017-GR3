using UnityEngine;
using System.Collections;

public class PlatformScript : MonoBehaviour {

    public float fallSpeed = 0.5f;
    public GameObject[] patternPrefabs1;
    public GameObject[] patternPrefabs2;
    public float patternOffset = 30f;
    public float countDown = 3;

	// Use this for initialization
	void Start () {
        Instantiate(patternPrefabs1[0], new Vector3(0, 0, 0), Quaternion.identity, transform);

        if (Time.timeSinceLevelLoad < 80)
        {
            for (int i = 1; i < 6; i++)
            {
                int rand = Random.Range(0, patternPrefabs1.Length);
                Instantiate(patternPrefabs1[i], new Vector3(0, patternOffset * i, 0), Quaternion.identity, transform);
            }
        }
        else
        {
            for (int i = 1; i < 50; i++)
            {
                int rand = Random.Range(0, patternPrefabs2.Length);
                Instantiate(patternPrefabs2[i], new Vector3(0, patternOffset * i, 0), Quaternion.identity, transform);
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
          if(Time.timeSinceLevelLoad > countDown)
            transform.position = new Vector3(transform.position.x, transform.position.y - fallSpeed * Time.deltaTime, 0);
       
	}
}
