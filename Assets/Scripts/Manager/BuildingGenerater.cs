using UnityEngine;

public class BuildingGenerater : MonoBehaviour
{
    private bool shouldRise = false;
    public float targetHeight = 2f;
    public float riseSpeed = 2f;
    private Vector3 startPosition;
    public GameObject buildingGroup;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        buildingGroup = GetComponentInChildren<GameObject>();
        startPosition = buildingGroup.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldRise)
        {
            buildingGroup.transform.position = Vector3.Lerp(transform.position, new Vector3(startPosition.x,targetHeight,startPosition.z),riseSpeed*Time.deltaTime);
        }
    }

    public void StartingRising()
    {
        shouldRise = true;
    }
}
