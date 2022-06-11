using System.Numerics;
using System.Security.AccessControl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageReceiverHandler : MonoBehaviour
{
    public delegate void ReceiveDamageDelegate(DamageSource source);

    public event ReceiveDamageDelegate OnReceiveDamage;
    
    public void TakeDamage(DamageSource source) {
        OnReceiveDamage?.Invoke(source);
    }
}
