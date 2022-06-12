using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointHarmTrigger : CheckpointTrigger
{
    protected override void TriggerEvent(Collider c)
    {
        manager.SpawnOnLastCheckpoint(c.transform.root.gameObject);
    }
}
