using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour
{
    [SerializeField]
    private HealthHandler healthHandler;

    [SerializeField]
    private Collider coll;

    void Awake() { }

    void OnEnable()
    {
        if (healthHandler == null) healthHandler = GetComponent<HealthHandler>();
        healthHandler.OnDead += OnDead;
    }

    void OnDisable()
    {
        healthHandler.OnDead -= OnDead;
    }

    void OnDead()
    {
        coll.enabled = false;
    }
}
