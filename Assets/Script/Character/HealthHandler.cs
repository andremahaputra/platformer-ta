using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthHandler : MonoBehaviour
{
    [Header("Configuration")]
    public CharacterStatus stats;

    public void TakeDamage(int damageAmount) {
        this.stats.health -= damageAmount;
    }
}
