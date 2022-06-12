using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour
{
    [SerializeField]
    private HealthHandler healthHandler;

    [SerializeField]
    private Collider coll;

    void Start()
    {
        if (healthHandler == null) healthHandler = GetComponent<HealthHandler>();
    }

    void OnEnable()
    {
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

