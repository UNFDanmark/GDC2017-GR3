using UnityEngine;
using System.Collections;
//using UnityEngine;

public class PlayerScripts : MonoBehaviour {

	public float moveSpeed = 10f;
	public float jumpHeight = 10;
	public Rigidbody myRigidbody;
    public float jumpsensitivity = 0.7f;

	void awake() {
		myRigidbody = GetComponent<Rigidbody> ();
	}

    // Use this for initialization
    void Start(){
        
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.D))
            move(moveSpeed);
        if (Input.GetKey(KeyCode.A))
            move(-moveSpeed);
        if (Input.GetKeyDown(KeyCode.W))
            jump(jumpHeight);

    }

	void move (float speed) {
        myRigidbody.velocity = transform.right * speed;
    }

    void jump(float height)
    {
        if (Physics.Raycast(transform.position, Vector3.down, jumpsensitivity, 1 << 8))
        {
            myRigidbody.velocity = transform.up * height;
        }
    }
	/*void FixedUpdate () {
		
	}*/

}
