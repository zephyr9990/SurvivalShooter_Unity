using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CoinManager : MonoBehaviour
{
    public static int coins;

    Text text;

    void Awake()
    {
        text = GetComponent<Text>();
        coins = 0;
    }

    void Update()
    {
        text.text = "Coins: " + coins;
    }
}
