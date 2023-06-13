using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        //if W key is pressed, trigger if else
        if (Input.GetKeyDown(KeyCode.W))
        {
            anim.SetTrigger("Knight_Backward");
            Debug.Log("Press W key!");
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            anim.SetTrigger("Knight_Backward_Pause");
            Debug.Log("Backward Animation Pause");
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            anim.SetTrigger("Knight_Forward");
            Debug.Log("Press S key!");
        }
        
        if (Input.GetKeyUp(KeyCode.S)) 
        {
            anim.SetTrigger("Knight_Forward_Pause");
            Debug.Log("Forward Animation Pause");
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            anim.SetTrigger("Knight_Left");
            Debug.Log("Press A key!");
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            anim.SetTrigger("Knight_Left_Pause");
            Debug.Log("Left Animation Pause");
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            anim.SetTrigger("Knight_Right");
            Debug.Log("Press D key!");
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            anim.SetTrigger("Knight_Right_Pause");
            Debug.Log("Right Animation Pause");
        }
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
}
