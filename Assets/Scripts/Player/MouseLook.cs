using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSenstivity = 400f;
    private Transform player;//player position
    //camera rotation value
    private float yRotation = 0f ;
    private float xRotation = 0f ;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;//lock and hide cursor icon
        player = transform.GetComponentInParent<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSenstivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSenstivity * Time.deltaTime;
        yRotation -= mouseY;
        yRotation = Mathf.Clamp(yRotation, -60f, 60f);
        transform.localRotation = Quaternion.Euler(yRotation, 0f, 0f);//camera move up and down
        player.Rotate(Vector3.up * mouseX);//player turn left and right
    }
}
