using UnityEngine;

public class BuildingGenerater : MonoBehaviour
{
    private bool shouldRise = false;
    public float targetHeight = 0;
    public float riseSpeed = 1;
    public Vector3 startPosition;
    void Start()
    {
         startPosition = new Vector3(-16,-6,-14);//magic number just for test

    }

    void Update()
    {


        if (shouldRise && transform.position.y < 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, targetHeight, transform.position.z), riseSpeed * Time.deltaTime);
        }
        
    }

    public void StartingRising()
    {
        shouldRise = true;
    }
}
