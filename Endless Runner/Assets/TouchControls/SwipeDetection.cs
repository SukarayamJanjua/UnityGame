using System.Collections;

using UnityEngine;

public class SwipeDetection : MonoBehaviour
{
    //Imported from movement
    public CharacterController controller;

    
    public float xValue;
    public float sideMoveSpeed = 2f;
    public float moveSpeed = 11f;
    public float yValue = 0f;
    public Animator myAnimator;
    public bool isGrounded = true;
    public float jumpHeight = 7f;
    public float xRange = 1f;
    public Transform playerTransform;
     


    [SerializeField]
    private float minimumDistance = 0.1f;
    [SerializeField]
    private float maximumTime = 1f;


    private TouchControls touchControls;
    private Vector2 startPosition;
    private float startTime;
    private Vector2 endPosition;
    private float endTime;

    [SerializeField ,Range(0f,1f)]
    private float directionThreshold = 0.9f;


    public bool distanceSurpased = false;
    public float sideMoveDistance = 3f;
    //public float moveSmooth = 0.8f;
    void Awake()
    {
        touchControls = TouchControls.Instance;
    }
    void Start()
    {
        //controller = GetComponent<CharacterController>();
        //myAnimator = GetComponent<Animator>();
    }
    void OnEnable()
    {
        touchControls.OnStartTouch += SwipeStart;
        touchControls.OnEndTouch += SwipeEnd;
    }
    void OnDisable()
    {

        touchControls.OnStartTouch -= SwipeStart;
        touchControls.OnEndTouch -= SwipeEnd;
    }
    private void SwipeStart(Vector2 position , float time)
    {
        startPosition = position;
        startTime = time;
    }
    private void SwipeEnd(Vector2 position ,float time)
    {
        endPosition = position;
        endTime = time;
        DetectSwipe();
    }
    private void DetectSwipe()
    {
        if(Vector3.Distance(startPosition,endPosition) >= minimumDistance && 
            (endTime-startTime) <= maximumTime)
        {
            Debug.DrawLine(startPosition, endPosition, Color.red, 5f);
            Vector3 direction = endPosition - startPosition;
            Vector2 direction2D = new Vector2(direction.x, direction.y).normalized;
            SwipeDirection(direction2D);
        }
    }
    private void SwipeDirection(Vector2 direction)
    {
        if(Vector2.Dot(Vector2.up,direction) > directionThreshold)
        {
            Debug.Log("Swipe Up");
            JumpMechanism();
        }

        else if (Vector2.Dot(Vector2.down, direction) > directionThreshold)
        {
            Debug.Log("Swipe down");
        }

        else if (Vector2.Dot(Vector2.left, direction) > directionThreshold)
        {
            Debug.Log("Swipe left");
            xValue = -sideMoveDistance;


            Vector3 tempvector = new Vector3(xValue, 0f, 0f);
            controller.Move(tempvector);

            //Vector2 tempVector = new Vector2(xValue, yValue);
            //float tempXPosition = playerTransform.position.x;
            //float tempYPosition = playerTransform.position.y;
            //Vector2 tempPosition = new Vector2(tempXPosition, tempYPosition);
            //if (Vector2.Distance(tempPosition, tempVector) <3f)
            //{
            //    xValue = 0f;
            //}




        }
        else if (Vector2.Dot(Vector2.right, direction) > directionThreshold)
        {
            
            Debug.Log("Swipe right");
            xValue = sideMoveDistance ;

            //float step = Mathf.SmoothStep(playerTransform.position.x, xValue, moveSmoothTime);

            Vector3 tempvector = new Vector3(xValue, 0f, 0f);
            controller.Move(tempvector);


            //xValue += sideMoveDistance;



            //if(xValue > xRange)
            //{
            //    xValue = 0f;
            //}

        }
        else
        {
            xValue = 0f;
        }



    }
    void Update()
    {


        float zValue = Vector3.forward.z;
     
        Vector3 moveVector = new Vector3(0f, yValue, zValue * moveSpeed);


        controller.Move(moveVector * Time.deltaTime);

        
    
    }
    public void JumpMechanism()
    {
        if (isGrounded == true)
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
