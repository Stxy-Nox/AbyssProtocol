using System;
using UnityEngine;

public class MyEnemyManager : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject CreateEnemyPoint;
    public float firstSpawnEnemyTime = 0f;
    public float createEnemyTime = 3f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("Spawn", firstSpawnEnemyTime, createEnemyTime);
    }

    // Update is called once per frame
    //void Update()
    //{
    //    createEnemyTime += Time.deltaTime;
    //    if(createEnemyTime > 3f)
    //    {
    //        Spawn();
    //    }

    //}

    private void Spawn()
    {

        Instantiate(Enemy, CreateEnemyPoint.transform.position, CreateEnemyPoint.transform.rotation);
    }
}
