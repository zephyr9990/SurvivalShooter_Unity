using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    public int coinValue;

    private AudioSource coinSound;

    private void Awake()
    {
        coinSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            coinSound.Play(0);
            CoinManager.coins += coinValue;
            Destroy(gameObject);
        }
    }
}
