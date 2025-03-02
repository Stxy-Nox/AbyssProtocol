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

    private CollisionFlags collisionFlags;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        walkSpeed = 10f;
        runSpeed = 15f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        Moving();
    }

    //player move
    public void Moving()
    {
        //player instance stop when keyboard input stop:GetAxisRaw
        float h = Input.GetAxisRaw("Horizontal");
        float v =Input.GetAxisRaw("Vertical");

        isRun = Input.GetKey(runInputName);
        isWalk = (Mathf.Abs(h)>0 || Mathf.Abs(v)>0) ? true : false;

        if (isRun)
        {
            movementState = MovementState.running;
            Speed = runSpeed;
        }
        else
        {
            movementState = MovementState.walking;
            Speed = walkSpeed;
        }
        

        moveDirction = (transform.right * h + transform.forward * v).normalized;
        characterController.Move(moveDirction*Speed*Time.deltaTime);
    }

    public enum MovementState
    {
        walking,
        running,
        crouching,
        idle
    }
}
