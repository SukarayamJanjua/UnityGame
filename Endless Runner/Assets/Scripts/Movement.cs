using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Movement : MonoBehaviour
{
    
    private CharacterController controller;
    public Animator myAnimator;

    public Joystick joystick;
  
    
    //fix double jumping peoblem
    //public Transform groundCheck;
    //public float groundDistance = 0.4f;
    //public LayerMask groundMask;
    //public bool isGrounded = true;

    [Header("declaring all variable")]
    public float moveSpeed = 11f;
    public float sideMoveSpeed = 20f;
    public float xRange = 3f;
    public float jumpHeight = 7f;
    public float xValue;
    public float yValue = 0f;
    public bool isGrounded = true;
  
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        myAnimator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {  
        //getting x,y,z values
        if (joystick.Horizontal > 0.1f)
        {
            xValue = sideMoveSpeed;
        }
        else if (joystick.Horizontal < -0.1f)
        {
            xValue = -sideMoveSpeed;
        }
        //else if (joystick.Vertical > 0.235f)
        //{
        //    JumpMechanism();
        //}
        else
        {
            xValue = 0f;
        }

       
       
        //float xValue = Input.GetAxis("Horizontal");
        //float yValue = 0f;
        float zValue = Vector3.forward.z;
        


        //putting these values into moveVector vector;
        Vector3 moveVector = new Vector3(xValue * sideMoveSpeed, yValue, zValue * moveSpeed);
        //moving the gameobject to the moveVector position
        controller.Move(moveVector * Time.deltaTime);

    }

    public void JumpMechanism()
    {
        if(isGrounded == true)
        {
            myAnimator.SetBool("Jump", true);
            yValue += jumpHeight;
            isGrounded = false;
            Invoke("JumpToSprint", 0.3f);
        }

        //myAnimator.SetBool("Jump", true);
        //yValue += jumpHeight ;
        //Invoke("JumpToSprint", 0.5f);

    }
    //public void DoubleJumpMechanism()
    //{   
    //    myAnimator.SetBool("Jump", true);
    //    yValue += jumpHeight;
    //    Invoke("JumpToSprint", 0.5f);

    //}

    public void JumpToSprint()
    {
        myAnimator.SetBool("Jump", false);
        yValue = 0;
        
        isGrounded = true;
    }
    public void SetMoveSpeed(float modifier)
    {
        moveSpeed = 11f + modifier;
    }
}
    
