using UnityEngine;

public class MyPlayerShooting : MonoBehaviour
{
    public float timeBetweenBullets = 0.2f;
    
    private Light gunLight;
    private float effctsDisplayTime = 0.2f;
    private AudioSource gunAudio;
    private LineRenderer gunLine;
    private ParticleSystem gunParticle;
    float time = 0f;

    //shooting line variables
    private Ray shootRay;
    private RaycastHit shootHit;
    private int shootMask;


    private void Awake()
    {
        gunAudio = GetComponent<AudioSource>();
        gunLight = GetComponent<Light>();
        gunLine = GetComponent<LineRenderer>();
        gunParticle = GetComponent<ParticleSystem>();
        //get raycast mask
        shootMask = LayerMask.GetMask("Shootable");
    }

    // Update is called once per frame
    void Update()
    {
        time = time + Time.deltaTime;
        if(Input.GetButton("Fire1") && time >= timeBetweenBullets )
        {
            Shoot();
        }

        if(time >= timeBetweenBullets * effctsDisplayTime)
        {
            gunLight.enabled = false;
            gunLine.enabled = false;
        }
    }

    void Shoot()
    { 
        time = 0; 
        gunLight.enabled = true;

        gunLine.SetPosition(0,transform.position);
        //gunLine.SetPosition(1,transform.position+transform.forward*50);
        gunLine.enabled = true ;
        gunParticle.Play();

        gunAudio.Play();
        //detect if ray hit target
        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;

        if(Physics.Raycast(shootRay, out shootHit, 100, shootMask))
        {
            gunLine.SetPosition(1,shootHit.point);
            if (shootHit.collider.tag == "Enemy")
            {
                MyEnemyHealth enemyHealth =  shootHit.collider.GetComponent<MyEnemyHealth>();
                enemyHealth.TakeDamege(10, shootHit.point);
                //int health = enemyHealth.StartingHealth;
            }
            if (shootHit.collider.tag == "Trigger")
            {
                TargetForBuildingRise targetForBuildingRise = shootHit.collider.GetComponent<TargetForBuildingRise>();
                targetForBuildingRise.isHit = true;
            }
        }
        else
        {
            gunLine.SetPosition(1, transform.position + transform.forward * 50);
        }
    }
}
