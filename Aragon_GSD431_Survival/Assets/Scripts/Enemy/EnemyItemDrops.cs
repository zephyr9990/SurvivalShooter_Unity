using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyItemDrops : MonoBehaviour
{
    public GameObject[] items;

    private EnemyHealth enemyHealth;
    private int enemyDropRate;
    private int numberOfItems;
    private bool itemDropped;

    void Awake()
    {
        enemyHealth = GetComponent<EnemyHealth>();
        enemyDropRate = 12;
        numberOfItems = 6;
        itemDropped = false;
    }

    // Update is called once per frame
    void Update()
    {
        int itemDropChance = Random.Range(1, 10);
        if (enemyHealth.currentHealth <= 0 
            && itemDropChance <= enemyDropRate
            && itemDropped == false)
        {
            SpawnItem(itemDropChance);
            itemDropped = true;
        }
    }

    void SpawnItem(int itemNumber)
    {
        if (itemNumber > numberOfItems)
        {
            itemNumber -= numberOfItems;
        }

        switch (itemNumber)
        {
            case 1:
                Instantiate(items[0], new Vector3(transform.position.x, items[0].transform.position.y, transform.position.z), items[0].transform.rotation);
                break;
            case 2:
                Instantiate(items[1], new Vector3(transform.position.x, items[1].transform.position.y, transform.position.z), items[1].transform.rotation);
                break;
            case 3:
                Instantiate(items[2], new Vector3(transform.position.x, items[2].transform.position.y, transform.position.z), items[2].transform.rotation);
                break;
            case 4:
                Instantiate(items[3], new Vector3(transform.position.x, items[3].transform.position.y, transform.position.z), items[3].transform.rotation);
                break;
            default:
                break;
        }

    }
}
