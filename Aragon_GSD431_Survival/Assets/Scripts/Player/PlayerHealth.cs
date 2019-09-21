using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
    public Image damageImage;
    public AudioClip deathClip;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);


    Animator animator;
    AudioSource playerAudio;
    PlayerMovement playerMovement;
    PlayerShooting playerShooting;
    bool isDead;
    bool damaged;

    private bool shielded;
    public bool Shielded { get { return shielded; } set { shielded = value; } }

    private int maxHealth;

    void Awake ()
    {
        animator = GetComponent <Animator> ();
        playerAudio = GetComponent <AudioSource> ();
        playerMovement = GetComponent <PlayerMovement> (); 
        playerShooting = GetComponentInChildren <PlayerShooting> ();
        currentHealth = startingHealth;
        maxHealth = 100;
        shielded = false;
    }


    void Update ()
    {
        if(damaged)
        {
            damageImage.color = flashColour;
        }
        else
        {
            damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;
    }


    public void TakeDamage (int amount)
    {
        if (!shielded)
        {
            damaged = true;

            currentHealth -= amount;

            healthSlider.value = currentHealth;

            playerAudio.Play();

            if (currentHealth <= 0 && !isDead)
            {
                Death();
            }
        }
    }

    public void Heal (int amount)
    {
        if (currentHealth + amount > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth += amount;
        }

        healthSlider.value = currentHealth;
    }

    void Death ()
    {
        isDead = true;

        playerShooting.DisableEffects ();

        animator.SetTrigger ("Die");

        playerAudio.clip = deathClip;
        playerAudio.Play ();

        playerMovement.enabled = false;
        playerShooting.enabled = false;
    }


    public void RestartLevel ()
    {
        SceneManager.LoadScene (0);
    }
}
