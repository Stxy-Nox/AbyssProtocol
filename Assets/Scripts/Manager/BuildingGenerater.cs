using UnityEngine;

public class BuildingGenerater : MonoBehaviour
{
    public bool shouldRise = false;
    public float targetHeight = 0;
    public float riseSpeed = 1;
    public Vector3 startPosition;
    void Start()
    {
         startPosition = new Vector3(-16,-6,-14);//magic number just for test

    }

    void Update()
    {


        if (transform.position.y < 0)
        {
            StartingRising(targetHeight, riseSpeed);
        }
        
    }

    public void StartingRising(float height, float speed)
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, height, transform.position.z), speed*Time.deltaTime);
    }
}
