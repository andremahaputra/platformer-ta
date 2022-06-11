using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthScreen : HealthEventChannelListener
{
    [SerializeField]
    private Slider healthBar;

    new public void Raise(HealthEventParam param) {
        print("ANjingggg");
        healthBar.maxValue = param.maxHp;
        healthBar.value = param.currentHp;
    }
}
