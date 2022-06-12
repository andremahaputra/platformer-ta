using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    [SerializeField] private Transform initialSpawnPoint;

    private List<Transform> spawnPoints = new List<Transform>();

    public void AddSpawnPoint(Transform t)
    {
        Debug.Log("Added checkpoint");
        spawnPoints.Add(t);
    }

    public void SpawnOnLastCheckpoint(GameObject g) {
        Debug.Log("Should spawn on last checkpoint: " + g.name);
        Vector3 spawnPos = initialSpawnPoint.position;
        if (spawnPoints.Count > 0)
            spawnPos = spawnPoints.Last().position;
        g.SetActive(false);
        g.transform.position = spawnPos;
        g.SetActive(true);
    }
}
