using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoverHealth : MonoBehaviour
{
    public int amountHealed;

    private GameObject player;
    private PlayerHealth playerHealth;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && playerHealth.currentHealth > 0)
        {
            playerHealth.Heal(amountHealed);
            Destroy(gameObject);
        }
    }

}
