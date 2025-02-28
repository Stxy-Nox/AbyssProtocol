using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController characterController;
    public Vector3 moveDirction;

    //player setting
    public float walkSpeed;
    public float runSpeed;
    private float Speed;

    public float jumpForce;
    public float gravity;

    public KeyCode jumpInputName = KeyCode.Space;
    
    private CollisionFlags collisionFlags;
    public bool isGround ;

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

        Speed = walkSpeed;

        moveDirction = (transform.right * h + transform.forward * v).normalized;
        characterController.Move(moveDirction*Speed*Time.deltaTime);
    }
}
