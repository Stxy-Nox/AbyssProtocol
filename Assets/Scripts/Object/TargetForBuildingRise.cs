using UnityEngine;

public class TargetForBuildingRise : MonoBehaviour
{
    public bool isHit = false;
    public BuildingGenerater buildingGenerater;
    public int hitFlag;
    private MeshRenderer meshRenderer;
    //public GameObject buildingGroup;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hitFlag = 0;
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if (isHit) {
            if(hitFlag % 2 == 1){
                buildingGenerater.StartingRising();
                meshRenderer.materials[0].color = Color.red;
            }
        else{
                buildingGenerater.destoryBuilding();
                meshRenderer.materials[0].color = Color.green;
            }
            isHit = false;
        }
    }
}
