﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defender defender;
    private void AttemptToPlaceDefenderAt(Vector2 gridPos)
    {
        var bankDisplay = FindObjectOfType<BankDisplay>();
        int defenderCost = defender.GetCost();
        if (bankDisplay.HaveEnoughCoins(defenderCost))
        {
            SpawnDefender(gridPos);
            bankDisplay.SpendCoins(defenderCost);
        }
    }
    private void OnMouseDown()
    {
        AttemptToPlaceDefenderAt(GetSquareClicked());
    }
    private Vector2 GetSquareClicked()
    {
        Vector2 clickPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(clickPosition);
        Vector2 gridPosition = SnapToGrid(worldPosition);
        return gridPosition;
    }
    public void SetSelectedDefender(Defender defenderToSelect)
    {
        defender = defenderToSelect;
    }
    private Vector2 SnapToGrid(Vector2 rawWorldPosition)
    {
        float xPos = Mathf.Round(rawWorldPosition.x);
        float yPos = Mathf.Round(rawWorldPosition.y);
        return new Vector2(xPos, yPos);
    }
    private void SpawnDefender(Vector2 currentPosition)
    {
        Defender newDefender = Instantiate(defender, currentPosition, Quaternion.identity) as Defender;
    }
}