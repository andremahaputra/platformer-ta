using UnityEngine;
using UnityEngine.Events;

public struct HealthEventParam {
    public int maxHp;
    public int currentHp;
}

[CreateAssetMenu()]
public class HealthEventChannel : EventChannel<HealthEventParam> {}

public abstract class HealthEventChannelListener : EventChannelListener<HealthEventParam, HealthEventChannel, UnityEvent<HealthEventParam>> {}