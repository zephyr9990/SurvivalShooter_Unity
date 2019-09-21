using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreathAttack : MonoBehaviour
{
    public GameObject breathAttack;
    public GameObject trunkEnd;

    private GameObject spawnedAttack;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("BreatheDanger", 5f, 10f);
    }

    void BreatheDanger()
    {
        spawnedAttack = Instantiate(breathAttack, trunkEnd.transform.position, breathAttack.transform.rotation);
    }
}
