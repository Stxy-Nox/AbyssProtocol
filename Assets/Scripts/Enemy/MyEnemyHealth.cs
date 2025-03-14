using System;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MyEnemyHealth : MonoBehaviour
{
    public AudioClip DeathClip;
    public int StartingHealth = 100;
    public bool isDead = false;
    private AudioSource enemyAudioSource;
    private ParticleSystem enemyParticle;
    private Animator enemyAnimator;
    private CapsuleCollider enemyCapsuleCollider;
    private bool isSinking = false;
    public Slider enemyHealthUI;

    private void Awake()
    {
        enemyAudioSource = GetComponent<AudioSource>(); 
        enemyParticle = GetComponentInChildren<ParticleSystem>();
        enemyAnimator = GetComponent<Animator>();
        enemyCapsuleCollider = GetComponent<CapsuleCollider>();
        enemyHealthUI = GetComponentInChildren<Slider>();
    }


    // Update is called once per frame
    void Update()
    {
        if (isSinking)
        {
            transform.Translate(-transform.up*Time.deltaTime);
        }
    }


    public void TakeDamege(int amount,Vector3 hitPoint)
    {
        if(isDead) return;
        //play zombunny hurt audio
        enemyAudioSource.Play();
        //play hited effect
        enemyParticle.transform.position = hitPoint;
        enemyParticle.Play();

        StartingHealth -=  amount;
        enemyHealthUI.value = StartingHealth;
        if (StartingHealth <= 0)
        {
            Death();
        }

        
    }

    private void Death()
    {
        isDead = true;
        MyPlayerScore.Scores += 10;
        //play enemy death animation
        enemyAnimator.SetTrigger("Death");
        //disable dead enemy move
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        //play enemy death audio
        enemyAudioSource.clip=  DeathClip;
        enemyAudioSource.Play();

        enemyCapsuleCollider.isTrigger = true;
        //disable
    }

    public void StartSinking()
    {
        isSinking = true;
        Destroy(gameObject, 2f);
    }



}
