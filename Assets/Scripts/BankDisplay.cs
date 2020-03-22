using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BankDisplay : MonoBehaviour
{
    [SerializeField] float coins = 100;
    Text coinText;
    void Start()
    {
        coins = Mathf.Round(coins / PlayerPrefsController.GetMasterDifficulty());
        coinText = GetComponent<Text>();
        UpdateDisplay();
    }
    public void AddCoins(float amount)
    {
        coins += amount;
        UpdateDisplay();
    }
    public void DepleteAccount()
    {
        coins = 0;
        UpdateDisplay();
    }
    public bool HaveEnoughCoins(float amount)
    {
        if (amount <= coins)
        {
            return true;
        } else {
            return false;
        }
    }
    public void SpendCoins(float amount)
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
