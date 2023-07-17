 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerBehavior : MonoBehaviour
{
    //Speed (How fast the player will navigate on the Game)
    public float movementSpeed;

    //RigidBody (Handles Physics, Makes our player moves)
    public Rigidbody2D rigidBody;

    //Dictates where the player is moving
    private Vector2 movementInput;

    //Access our Animator
    public Animator anim;

    public int CoinCount;

    public int healthPoints;


    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        /*
        //if W key is pressed, trigger if else
        if (Input.GetKeyDown(KeyCode.W) || (Input.GetKeyDown(KeyCode.UpArrow)))
        {

            anim.enabled = true;
            anim.SetTrigger("Knight_Backward");

            if (Input.GetKeyDown(KeyCode.W))
            {
                Debug.Log("Press W key!");
            }
            else
            {
                Debug.Log("Press Up Arrow!");
            }
        }
        
        if (Input.GetKeyUp(KeyCode.W) || (Input.GetKeyUp(KeyCode.UpArrow)))
        {
            anim.SetTrigger("Knight_Backward_Pause");
            Debug.Log("Backward Animation Pause");
        }

        if (Input.GetKeyDown(KeyCode.S) || (Input.GetKeyDown(KeyCode.DownArrow)))
        {
            anim.SetTrigger("Knight_Forward");
            anim.enabled = true;
            if (Input.GetKeyDown(KeyCode.S))
            {
                Debug.Log("Press S key!");
            }
            else
            {
                Debug.Log("Press Down Arrow!");
            }
        }
        
        if (Input.GetKeyUp(KeyCode.S) || (Input.GetKeyUp(KeyCode.DownArrow))) 
        {
            anim.SetTrigger("Knight_Forward_Pause");
            Debug.Log("Forward Animation Pause");
        }

        if (Input.GetKeyDown(KeyCode.A) || (Input.GetKeyDown(KeyCode.LeftArrow))) 
        {
            anim.SetTrigger("Knight_Left");
            anim.enabled = true;
            if (Input.GetKeyDown(KeyCode.A))
            {
                Debug.Log("Press A key!");
            }
            else
            {
                Debug.Log("Press Left Arrow!");
            }
        }

        if (Input.GetKeyUp(KeyCode.A) || (Input.GetKeyUp(KeyCode.LeftArrow)))
        {
            anim.SetTrigger("Knight_Left_Pause");
            Debug.Log("Left Animation Pause");
        }

        if (Input.GetKeyDown(KeyCode.D) || (Input.GetKeyDown(KeyCode.RightArrow)))
        {
            anim.SetTrigger("Knight_Right");
            anim.enabled = true;
            if (Input.GetKeyDown(KeyCode.D))
            {
                Debug.Log("Press D key!");
            }
            else
            {
                Debug.Log("Press Right Arrow!");
            }
        }

        if (Input.GetKeyUp(KeyCode.D) || (Input.GetKeyUp(KeyCode.RightArrow)))
        {
            anim.SetTrigger("Knight_Right_Pause");
            Debug.Log("Right Animation Pause");
        }
        

        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            anim.enabled = false;
            Debug.Log("anim.enabled = false");
        }
        */

        anim.SetFloat("Horizontal", movementInput.x);
        //Debug.Log("MovementInput X");
        anim.SetFloat("Vertical", movementInput.y);
        //Debug.Log("MovementInput Y");
        anim.SetFloat("Speed", movementInput.sqrMagnitude);

    }

    //Fixed update for physics calculations
    private void FixedUpdate()
    {
        rigidBody.velocity = movementInput * movementSpeed;
        
    }

    //To get the Input System Clicks
    private void OnMove(InputValue inputValue)
    {
        //if press WASD =  to Vector 2 Values
        movementInput = inputValue.Get<Vector2>();

    }

    //OnTrigger - bool
    //(Enter) - if player enters the collision area
    //(Exit) - if player is not detected within collision area
    //(Stay) - if player is within collision area

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SpeedPowerUp")) 
        {
            //Destroy(collision.gameObject);
            //CoinCount++;
            Transform col = collision.transform;
            col.transform.position = new Vector2(999, 999);
            Debug.Log("Speed boost! \r\n Destroy speed power up");
            Debug.Log("Initiate Coroutine");
        }
        if (collision.gameObject.CompareTag("Coin"))
        {
            CoinCount++;
            Destroy(collision.gameObject);
            Debug.Log("Coin +1 \r\n Destroy coin");
        }
        if (collision.gameObject.CompareTag("HealthPowerUp"))
        {
            Destroy(collision.gameObject);
            Debug.Log("Destroy health power up");
        }

    }
   
}
