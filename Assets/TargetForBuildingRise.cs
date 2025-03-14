using UnityEngine;

public class TargetForBuildingRise : MonoBehaviour
{
    public bool isHit = false;
    private BuildingGenerater buildingGenerater;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isHit)
        {
            buildingGenerater.StartingRising();
        }
    }
}
