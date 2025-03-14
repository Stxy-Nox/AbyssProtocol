using UnityEngine;

public class BuildingGenerater : MonoBehaviour
{
    public bool shouldRise = false;
    public bool shouldDestory = false;
    public float targetHeight = 0;
    public float riseSpeed = 1;
    public Vector3 startPosition;
    public Vector3 storePosition = new Vector3(10,-6,-25);//store outside of map
    void Start()
    {
         startPosition = new Vector3(-16,-6,-14);//magic number just for test
 
    }

    void Update()
    {


        if (shouldRise )
        {

            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, targetHeight, transform.position.z), riseSpeed * Time.deltaTime);
            if(transform.position.y >= targetHeight - 0.01f)
            {
                shouldRise = false;
            }
        }
        if (shouldDestory)
        {
            transform.position = storePosition;
            shouldDestory = false;
        }
        
    }

    public void StartingRising()
    {
        transform.position = startPosition;
        shouldDestory = false;
        shouldRise = true;
    }

    public void destoryBuilding()
    {
        shouldRise = false;
        shouldDestory = true;
    }
}
