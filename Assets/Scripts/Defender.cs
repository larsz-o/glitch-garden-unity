using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
  [SerializeField] float cost = 100;
  public void AddCoins (float amount)
  {
    FindObjectOfType<BankDisplay>().AddCoins(amount);
  }
  public float GetCost()
  {
    return cost;
  }
  
}