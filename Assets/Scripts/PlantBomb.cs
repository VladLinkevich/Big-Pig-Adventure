using System;
using UnityEngine;
using UnityEngine.UI;

public class PlantBomb : MonoBehaviour
{
    public BombSpawnPointHandler bombSpawn;
    public BombPool bombPool;
    public Button button;

    private void OnEnable()
    {
        button.onClick.AddListener(Plant);
    }

    private void OnDisable()
    {
        button.onClick.RemoveListener(Plant);
    }

    private void Plant()
    {
        Vector3 spawnPoint = CalculateSpawnPoint();
        GameObject bomb = bombPool.GetBomb();

        bomb.SetActive(true);
        bomb.GetComponent<Bomb>().Plant();
        bomb.transform.position = spawnPoint;
    }

    private Vector3 CalculateSpawnPoint()
    {
        Vector3 minDistanceSpawnPoint = Vector3.zero;
        float minDistance = Single.MaxValue;
        
        Vector3 position = transform.position;

        foreach (var spawnPoint in bombSpawn.spawns)
        {
            float distance = Vector3.Distance(position, spawnPoint.position);
            if (minDistance > Math.Abs(distance))
            {
                minDistanceSpawnPoint = spawnPoint.position;
                minDistance = Math.Abs(distance);
            }
        }

        return minDistanceSpawnPoint;
    }
}