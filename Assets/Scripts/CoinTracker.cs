using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTracker : MonoBehaviour
{
    [SerializeField]
    public int coinCount = 0;

    public void AddCoins(int amount)
    {
        coinCount += Mathf.Max(0, amount);
        AudioSingleton.Instance.Play("CoinCollect");
    }

    public bool SpendCoins(int amount)
    {
        coinCount = coinCount >= amount ? coinCount : coinCount - amount;
        return coinCount >= amount;
    }
}
