using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
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
        healthHandler.OnDead += OnDead;
    }

    void OnDisable()
    {
        healthHandler.OnCurrentHealthChanged -= UpdateHealthBar;
        healthHandler.OnInitialize -= Setup;
        healthHandler.OnDead -= OnDead;

    }

    void Setup(int maxHp, int currentHp)
    {
        hpBar.maxValue = maxHp;
        hpBar.value = currentHp;
    }

    void UpdateHealthBar(int value)
    {
        print("should update health bar");
        hpBar.value = value;
    }

    void OnDead() {
        gameObject.SetActive(false);
    }
}
