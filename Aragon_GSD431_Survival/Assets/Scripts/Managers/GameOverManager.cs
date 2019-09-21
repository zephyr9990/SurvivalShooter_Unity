using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public float restartDelay = 5f;


    Animator animator;
    float restartTimer;


    void Awake()
    {
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        if (playerHealth.currentHealth <= 0)
        {
            animator.SetTrigger("GameOver");

            restartTimer += Time.deltaTime;
            
            if (restartTimer >= restartDelay)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().ToString());
            }
        }
    }
}
