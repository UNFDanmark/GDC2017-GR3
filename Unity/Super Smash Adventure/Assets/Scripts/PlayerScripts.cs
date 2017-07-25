using UnityEngine;
using System.Collections;
//using UnityEngine;

public class PlayerScripts : MonoBehaviour {

    public GameObject otherPlayer;
	public float moveSpeed = 10f;
	public float jumpHeight = 20;
	public Rigidbody myRigidbody;
    public float rayLength = 1f;
    public float levelWidth = 15;

    public bool isPlayerTwo = false;

    public string horizontalAxis;
    public string verticalAxis;

    void awake() {
		myRigidbody = GetComponent<Rigidbody> ();
	}
             
    // Use this for initialization
    void Start(){
        
    }

    // Upd8 15 c8113d 0nc3 p3r fr8me3
	void Update () {
       // motion1();

        //Wall-teleport
        if (transform.position.x > levelWidth)
            transform.position = new Vector3(-levelWidth, myRigidbody.position.y, 0);
        else if (transform.position.x < -levelWidth)
            transform.position = new Vector3(levelWidth, myRigidbody.position.y, 0);

    }
    void FixedUpdate()
    {
        Move(moveSpeed * Input.GetAxis(horizontalAxis));
        if(Input.GetAxis(verticalAxis) == 1) Jump();
    }

    public void Move(float speed)
    {
        myRigidbody.velocity = transform.right * speed + Vector3.up * myRigidbody.velocity.y;
    }

    public void Jump()
    {
        print("JUMPY");
        if (Physics.Raycast(transform.position - new Vector3(0.5f, 0, 0), Vector3.down, rayLength, 1 << 8) ||
         Physics.Raycast(transform.position + new Vector3(0.5f, 0, 0), Vector3.down, rayLength, 1 << 8))
        {
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpHeight);
        }

    }

        /* void move (float speed) {
             myRigidbody.velocity = transform.right * speed + new Vector3 (0,myRigidbody.velocity.y,0);
         }

         void jump(float height)
         {
             if (Physics.Raycast(transform.position-new Vector3 (0.5f,0,0), Vector3.down, rayLength, 1 << 8) || 
                 Physics.Raycast(transform.position+new Vector3 (0.5f,0,0), Vector3.down, rayLength, 1 << 8))
             {
                 myRigidbody.velocity = transform.up * height * 2;
                 */
    




    void Motion1()
    {
        if (!isPlayerTwo)
        {
            // Player 1

            //if (Input.GetKey(KeyCode.A))
               // move(-moveSpeed);

            /*if (Input.GetKeyUp(KeyCode.D))
                myRigidbody.velocity = new Vector3(0, myRigidbody.velocity.y, 0);
            if (Input.GetKeyUp(KeyCode.A))
                myRigidbody.velocity = new Vector3(0, myRigidbody.velocity.y, 0);

            if (Input.GetKeyDown(KeyCode.W))
                jump(jumpHeight);

            if (Input.GetKeyDown(KeyCode.Tab))
                push();*/
        }
        else
        {
            /* Player 2
            if (Input.GetKey(KeyCode.RightArrow))
                move(moveSpeed);
            if (Input.GetKey(KeyCode.LeftArrow))
                move(-moveSpeed);

            if (Input.GetKeyUp(KeyCode.RightArrow))
                myRigidbody.velocity = new Vector3(0, myRigidbody.velocity.y, 0);
            if (Input.GetKeyUp(KeyCode.LeftArrow))
                myRigidbody.velocity = new Vector3(0, myRigidbody.velocity.y, 0);

            if (Input.GetKeyDown(KeyCode.UpArrow))
                jump(jumpHeight);*/
        }

        //move(Input.GetAxis(horizontalAxis));
    }
    
    void push()
    {
        //otherPlayer.transform.position;
        Vector3 dist = otherPlayer.transform.position - transform.position;
        if (dist.magnitude < 3)
        {
            dist.Normalize();
            otherPlayer.GetComponent<Rigidbody>().AddForce(dist * 20, ForceMode.Impulse);
        }
    }
    
}
