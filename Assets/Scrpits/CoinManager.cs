using UnityEngine;
using System;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance { get; private set; }

    public int TotalCoins { get; private set; }

    public event Action<int> OnCoinCountChanged;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void AddCoins(int amount)
    {
        TotalCoins += amount;

        Debug.Log("Total Coins: " + TotalCoins);

        OnCoinCountChanged?.Invoke(TotalCoins);
    }
}

