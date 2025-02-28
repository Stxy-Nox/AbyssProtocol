using System;
using UnityEngine;

public class MyEnemyAttack : MonoBehaviour
{
    public float EnemyAttackDamage;
    private GameObject player;
    private bool playerInRange =false;
    private MyPlayerHealth myPlayerHealth;
    private float timer = 0;
    private Animator enemyAnimator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        myPlayerHealth = player.GetComponent<MyPlayerHealth>();
        enemyAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (!myPlayerHealth.IsPlayerDead && playerInRange && timer > 0.5f) 
        {
            Attack();
        }

        if (myPlayerHealth.IsPlayerDead)
        {
            enemyAnimator.SetTrigger("PlayerDead");
        }

        
    }

    private void Attack()
    {
        myPlayerHealth.TakeDamage(10);
        timer = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            //Debug.Log("Player get hited");
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            //Debug.Log("Player leave");
            playerInRange = false;
        }
    }
}
