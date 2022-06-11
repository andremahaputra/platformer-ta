using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthScreen : MonoBehaviour
{
    [SerializeField]
    private Slider healthBar;
    
    [SerializeField]
    private TextMeshProUGUI enemyNameText;


    public void Setup(string enemyName, int enemyMaxHp, int enemyCurrentHp) {
        enemyNameText.text = enemyName;

        healthBar.minValue = 0;
        healthBar.maxValue = enemyCurrentHp;
        healthBar.value = enemyCurrentHp;
    }

    public void UpdateHealthBar (int value) {
        healthBar.value = value;
    }
}
