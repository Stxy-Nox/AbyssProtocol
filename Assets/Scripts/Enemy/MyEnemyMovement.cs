using UnityEngine;
using UnityEngine.AI;

public class MyEnemyMovement : MonoBehaviour
{
    private Transform player;
    private NavMeshAgent nav;
    private MyEnemyHealth myEnemyHealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<NavMeshAgent>();
        myEnemyHealth = GetComponent<MyEnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        //detect if enemy dead or not; if dead, no more navigation. 
        if (!myEnemyHealth.isDead)
        {
            nav.SetDestination(player.position);
        }

    }
}
