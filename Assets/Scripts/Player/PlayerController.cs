using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController characterController;
    public Vector3 moveDirction;

    //player setting
    public float walkSpeed;
    public float runSpeed;
    public float crouchSpeed;
    private float Speed;

    public float jumpForce;
    public float gravity;
    //keyboard input setting
    public KeyCode jumpInputName = KeyCode.Space;
    public KeyCode runInputName = KeyCode.LeftShift;
    public KeyCode crouchInputName = KeyCode.LeftControl;

    //Player status 
    public MovementState movementState; 
    public bool isWalk;
    public bool isRun;
    public bool isGround ;
    public bool isJump;

    private CollisionFlags collisionFlags;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        walkSpeed = 10f;
        runSpeed = 15f;
        jumpForce = 0f;
        gravity = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        Moving();
    }

    //player move
    public void Moving()
    {
        //player instance stop when keyboard input stop:GetAxisRaw
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        isRun = Input.GetKey(runInputName);
        isWalk = (Mathf.Abs(h) > 0 || Mathf.Abs(v) > 0) ? true : false;

        if (isRun & isGround)
        {
            movementState = MovementState.running;
            Speed = runSpeed;
        }
        else if (isGround)
        { // walk normally
            {
                movementState = MovementState.walking;
                Speed = walkSpeed;
            }
        }
        
            moveDirction = (transform.right * h + transform.forward * v).normalized;
            characterController.Move(moveDirction * Speed * Time.deltaTime);
    }

    public void Jump()
    {
        isJump = Input.GetKey(jumpInputName);
        if (isJump&& isGround) //jump only avaliable when player on the ground
        {
            isGround = false;
            jumpForce = 5f;
        }
        // after jump and not on the ground
        if (!isGround)
        {
            jumpForce -= gravity * Time.deltaTime;//reduce jumpforce cumulatively , make player fall
            Vector3 jump = new Vector3(0,jumpForce* Time.deltaTime,0);//translate jumpforece to v3 position
            collisionFlags =  characterController.Move(jump);// use characterController move funciton to simulate  jumping

            if (collisionFlags == CollisionFlags.Below)
            {
                isGround = true;
                jumpForce = 0f;
            }

            if (isGround && collisionFlags == CollisionFlags.None)
            {
                isGround = false;
            }
        }

    } 
    public enum MovementState
    {
        walking,
        running,
        crouching,
        idle
    }
}
