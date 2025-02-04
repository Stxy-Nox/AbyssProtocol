using UnityEngine;


public class MouseLook : MonoBehaviour
{
    public float mouseSenstivity = 400f;
    private Transform playerBody;
    private float yRotation = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerBody = transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
