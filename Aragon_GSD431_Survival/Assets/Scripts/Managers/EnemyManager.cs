using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject enemy;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;
    public EnemyHealth bossHealth;

    private BossManager bossManager;

    private void Awake()
    {
        bossManager = BossManager.GetInstance();
    }

    void Start ()
    {
        InvokeRepeating ("Spawn", spawnTime, spawnTime);
    }


    void Spawn ()
    {
        if (playerHealth.currentHealth <= 0f)
        {
            return;
        }

        int spawnPointIndex = Random.Range (0, spawnPoints.Length);
        
        if (enemy.CompareTag("Boss") && bossManager.BossSpawned == false)
        {
            Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            bossManager.BossSpawned = true;
            Debug.Log("Spawning Boss");
        }
            
        if (enemy.CompareTag("Enemy"))
        {
            Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        }

        
    }
}
