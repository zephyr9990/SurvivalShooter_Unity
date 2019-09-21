using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shield : MonoBehaviour
{
    private GameObject player;
    private PlayerHealth playerHealth;
    public Text shieldText;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerHealth.Shielded = true;
            Destroy(gameObject);
            shieldText.gameObject.SetActive(true);
            StartCoroutine(Shielded());
        }
    }


    private IEnumerator Shielded()
    {
        Debug.Log("Hi");
        yield return new WaitForSeconds(1f);
        Debug.Log("Hi2");
        playerHealth.Shielded = false;
        Debug.Log(playerHealth.Shielded.ToString());
    }
}
