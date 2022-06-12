using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DamageReceiverHandler))]
public class HitIndicatorHandler : MonoBehaviour
{
    [SerializeField]
    private HitIndicator hitIndicator;

    [SerializeField]
    private DamageReceiverHandler damageReceiverHandler;
    
    void OnEnable()
    {
        if (damageReceiverHandler == null) damageReceiverHandler = GetComponent<DamageReceiverHandler>();
        damageReceiverHandler.OnReceiveDamage += SpawnHitIndicator;
    }

    void OnDisable()
    {
        damageReceiverHandler.OnReceiveDamage -= SpawnHitIndicator;
    }

    private void SpawnHitIndicator(DamageSource source)
    {
        var indicator = Instantiate(hitIndicator, source.gameObject.transform.position + Vector3.forward * -2, Quaternion.identity);
        indicator.gameObject.SetActive(true);
    }
}
