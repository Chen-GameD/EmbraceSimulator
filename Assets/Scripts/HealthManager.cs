using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    private int CurrentHealth = 0;
    private int MaxHealth = 0;

    [SerializeField] private TextMeshProUGUI HealthText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Init(int i_MaxHealth)
    {
        MaxHealth = i_MaxHealth;
        CurrentHealth = MaxHealth;
        UpdateHealth(0);
    }

    public int GetHealth()
    {
        return CurrentHealth;
    }

    public void UpdateHealth(int DamageDelta)
    {
        // Update CurrentHealth
        CurrentHealth -= DamageDelta;
        if (CurrentHealth > MaxHealth)
        {
            CurrentHealth = MaxHealth;
        }
        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            // Need end game
            GameManager.Instance.EndGame();
        }

        // Update UI
        HealthText.text = "HP: " + CurrentHealth;
        Debug.Log("Current health: " + CurrentHealth);
    }
}
