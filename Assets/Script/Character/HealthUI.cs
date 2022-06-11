using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField]
    private HealthHandler healthHandler;

    [SerializeField]

    private Slider hpBar;

    void OnEnable()
    {
        if (healthHandler == null) healthHandler = GetComponentInParent<HealthHandler>();

        healthHandler.OnCurrentHealthChanged += UpdateHealthBar;
        healthHandler.OnInitialize += Setup;
    }

    void OnDisable()
    {
        healthHandler.OnCurrentHealthChanged -= UpdateHealthBar;
        healthHandler.OnInitialize -= Setup;
    }

    public void Setup(int maxHp, int currentHp)
    {
        hpBar.maxValue = maxHp;
        hpBar.value = currentHp;
    }

    public void UpdateHealthBar(int value)
    {
        print("should update health bar");
        hpBar.value = value;
    }
}