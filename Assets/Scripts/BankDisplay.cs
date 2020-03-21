using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BankDisplay : MonoBehaviour
{
    [SerializeField] int coins = 100;
    Text coinText;
    void Start()
    {
        coinText = GetComponent<Text>();
        UpdateDisplay();
    }
    public void AddCoins(int amount)
    {
        coins += amount;
        UpdateDisplay();
    }
    public void DepleteAccount()
    {
        coins = 0;
        UpdateDisplay();
    }
    public bool HaveEnoughCoins(int amount)
    {
        if (amount <= coins)
        {
            return true;
        } else {
            return false;
        }
    }
    public void SpendCoins(int amount)
    {
        if (coins >= amount)
        {
            coins -= amount;
            UpdateDisplay();
        }
    }
    private void UpdateDisplay()
    {
        coinText.text = coins.ToString();
    }
}
