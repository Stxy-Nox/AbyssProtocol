using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MyPlayerHealth : MonoBehaviour
{
    public int PlayerHealthMax = 100;
    public int PlayerHealthCurrent = 100;
    public bool IsPlayerDead = false;
    private AudioSource playerAudio;
    public AudioClip PlayerDeathClip;

    private PlayerController playerController;
    private MouseLook playerMouseLook;
    private MyPlayerShooting myPlayerShooting;
    public Slider playerHealthUI;
    public TextMeshProUGUI playerHealthValue;
    public Image DamegeImage;
    private float deadCount = 0;
    private bool dagemed = false;
    public Color FlashColor = new Color(1f, 0, 0, 0.1f);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void Awake()
    {
        playerAudio = GetComponent<AudioSource>();
        playerController = GetComponent<PlayerController>();
        playerMouseLook = GetComponentInChildren<MouseLook>();
        myPlayerShooting = GetComponentInChildren<MyPlayerShooting>();

    }
    // Update is called once per frame
    void Update()
    {
        if (dagemed)
        {
            DamegeImage.color = FlashColor;
        }
        else
        {
            DamegeImage.color = Color.Lerp(DamegeImage.color, Color.clear, 5f * Time.deltaTime);
        }
        dagemed = false;
        if (IsPlayerDead)
        {
            deadCount += 1f * Time.deltaTime;
        }
        if (deadCount > 3f)
        {
            RestartLevel();
            deadCount = 0;
        }

    }

    public void TakeDamage(int amount)
    {
        if (IsPlayerDead == true)
        {
            return;
        }
        dagemed =   true;
        playerAudio.Play();
        PlayerHealthCurrent -= amount;
        playerHealthUI.value = PlayerHealthCurrent;
        playerHealthValue.text = $"HP: {PlayerHealthCurrent}/{PlayerHealthMax}";
        Debug.Log(PlayerHealthCurrent);
        if (PlayerHealthCurrent <= 0)
        {
            Death();
        }
    }


    private void Death()
    {
        IsPlayerDead = true;
        playerAudio.clip = PlayerDeathClip;
        playerAudio.Play();

        playerController.enabled = false;
        playerMouseLook.enabled = false;
        myPlayerShooting.enabled = false;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }
}
