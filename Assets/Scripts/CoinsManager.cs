using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CoinsManager : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private int countCoin;
    
    private List<Coin> coins = new List<Coin>();

    private void Start()
    {
        InstanceCoins(countCoin);
    }
    
    
    private void InstanceCoins(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Vector3 randomPosition = new Vector3(Random.Range(-40f, 40f), 0.5f, Random.Range(-40f, 40f));
            GameObject coin = Instantiate(coinPrefab, randomPosition, Quaternion.identity);
            coins.Add(coin.GetComponent<Coin>());
        }
    }

    public void ColectCoins(Coin thisCoin)
    {
        coins.Remove(thisCoin);
        Destroy(thisCoin.gameObject);
    }
}
