using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

//public class TurnAround :  MonoBehaviour { }
public class PlayerScripts : MonoBehaviour {

    public GameObject otherPlayer;
	public float moveSpeed = 10f;
	public float jumpHeight = 20;
	public Rigidbody myRigidbody;
    public float rayLength = 0.6f;
    public float levelWidth = 15;
    public int lives = 5;
    public GameObject life;
    public float lifeOffset = 0.5f;

    public static string winningPlayer = "";

    public float pushbackDistance = 5f;
    public float pushForce = 30;
    public float timeSinceBeingPush;
    public float timeSincePushed;
    public float pushLock = 0.2f;
    public float pushTime = 0.2f;

    public AudioScript audioScript;

    public bool isPlayerTwo = false;
    public bool pushed = false;

    public string horizontalAxis;
    public string verticalAxis;

    public GameObject model;
    public Vector3 standardRotation;

    void awake() {
		myRigidbody = GetComponent<Rigidbody> ();
        timeSincePushed = -pushTime;
    }
             
    // Use this for initialization
    void Start(){
       // drawLives();
    }

    // Upd8 15 c8113d 0nc3 p3r fr8me3
    void Update() {
        // motion1();
        if (timeSinceBeingPush + pushLock < Time.time)
        {
            pushed = false;
        }
        


        //Wall-teleport
        if (transform.position.x > levelWidth)
            transform.position = new Vector3(-levelWidth, myRigidbody.position.y, 0);
        else if (transform.position.x < -levelWidth)
            transform.position = new Vector3(levelWidth, myRigidbody.position.y, 0);

        if (Input.GetKeyDown(KeyCode.LeftShift) && isPlayerTwo == false)
        {
            Pushback();
        }

       if (Input.GetKeyDown(KeyCode.RightShift) && isPlayerTwo == true)
        {
            Pushback();
        }

       
    }

    /*void drawLives()
    {
        for (int i = 0; i < lives; i++)
        {
            Instantiate(life, new Vector3(life.transform.position.x + lifeOffset*i, 14, 0), Quaternion.identity, transform);

        }
    }*/
    void Pushback()
    {
        if (Vector3.Distance(transform.position, otherPlayer.transform.position) < pushbackDistance && Time.time>timeSincePushed+pushTime)
        {
            timeSincePushed = Time.time;
            print("Push ");
            otherPlayer.GetComponent<PlayerScripts>().BeingPushed();
            otherPlayer.GetComponent<Rigidbody>().AddForce(Vector3.Normalize(otherPlayer.transform.position - gameObject.transform.position)*pushForce,ForceMode.Impulse);
            audioScript.HitSound();
        }
    }
    void FixedUpdate()
    {
        if (!pushed)
        {
            Move(moveSpeed * Input.GetAxis(horizontalAxis));

            if (Input.GetAxis(horizontalAxis) == -1)
            {
                model.transform.rotation = Quaternion.Euler(standardRotation + new Vector3(0, 180, 0));
            }
            else if (Input.GetAxis(horizontalAxis) == 1)
            {
                model.transform.rotation = Quaternion.Euler(standardRotation);
            }

            if (Input.GetAxis(verticalAxis) == 1)
            {
                Jump();
            }
        }
    }

    public void Move(float speed)
    {
        myRigidbody.velocity = transform.right * speed + Vector3.up * myRigidbody.velocity.y;
    }

    public void Jump()
    {
        if (Physics.Raycast(transform.position - new Vector3(0.5f, 0, 0), Vector3.down, rayLength, 1 << 8) ||
         Physics.Raycast(transform.position + new Vector3(0.5f, 0, 0), Vector3.down, rayLength, 1 << 8))
        {
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpHeight);
            audioScript.JumpSound();
        }
    }
    //Access to DeathZone
    void OnTriggerEnter(Collider collider) {
        

        if (collider.tag == "DeathZone")
        {
            audioScript.FallingSound();
            if (lives > 1)
            {
                gameObject.transform.position = new Vector3(0, 20, 0);
                lives--;
                print(gameObject + "lives: " + lives);
            } else
            {
                if(gameObject.name == "Player1")
                {
                    winningPlayer = "Robot";
                }
                else if (gameObject.name == "Player2")
                {
                    winningPlayer = "Wizard";
                }
                SceneManager.LoadScene("GameOver");
            }
        }
    }
    
   

    public void BeingPushed()
    {
        timeSinceBeingPush = Time.time;
        pushed = true;

    }
}
