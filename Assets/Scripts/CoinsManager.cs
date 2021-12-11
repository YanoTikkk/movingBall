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
    private Coin closesCoin;
    private float distanceToCoin;
    private float minDistance;

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

    public Coin GetCloses(Vector3 arrow)
    {
        minDistance = Mathf.Infinity;
        closesCoin = null;

        for (int i = 0; i < coins.Count; i++)
        {
            distanceToCoin = Vector3.Distance(arrow, coins[i].transform.position);
            if (distanceToCoin < minDistance)
            {
                minDistance = distanceToCoin;
                closesCoin = coins[i];
            }
        }
        
        return closesCoin;
    }
}
