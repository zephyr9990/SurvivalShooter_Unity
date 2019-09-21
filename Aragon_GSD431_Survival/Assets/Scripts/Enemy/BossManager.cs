using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager
{
    public bool BossSpawned { get { return this.bossSpawned; } set { this.bossSpawned = value; } }

    private bool bossSpawned;
    private static BossManager instance;

    private BossManager()
    {
        bossSpawned = false;
    }

    public static BossManager GetInstance()
    {
        if (instance == null)
        {
            instance = new BossManager();
            return instance;
        }
        else
        {
            return instance;
        }
    }
}
