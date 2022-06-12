using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class CheckpointSpawnTrigger : CheckpointTrigger {
    [SerializeField] Transform spawnPos;

    protected override void TriggerEvent(Collider c)
    {
        manager.AddSpawnPoint(spawnPos);
    }
}