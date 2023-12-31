using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private bool enableSpawning;
    [SerializeField] public int amountSpawnEnemies;
    [SerializeField] private float firstSpawn;
    [SerializeField] private float spawnSpeedMax;
    [SerializeField] private float spawnSpeedMin;

    [Header("Other")] private int lastIndex;

    [Header("References")] [SerializeField]
    private GameObject[] spawnPoints;

    [SerializeField] private GameObject[] signs;
    [SerializeField] private GameObject enemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
    }

    private void Awake()
    {
        if (!enableSpawning) return;
        StartCoroutine(SpawnEnemyCooldown(firstSpawn));
    }

    IEnumerator SpawnEnemyCooldown(float time)
    {
        List<int> indexes = new List<int>();
        for (int i = 0; i < amountSpawnEnemies; i++)
        {
            int index = 0;
            do
            {
                index = (int)Random.Range(0, spawnPoints.Length);
            } while (index == lastIndex);
            lastIndex = index;
            signs[index].GetComponent<Sign>().ShowSign(Sign.SignType.EnemyAppearing, time - 0.2f);
            indexes.Add(index);
        }

        yield return new WaitForSeconds(time);
        foreach (var index in indexes)
        {
            SpawnEnemy(index);
        }
        indexes.Clear();
        float randomTime = Random.Range(spawnSpeedMin, spawnSpeedMax);
        StartCoroutine(SpawnEnemyCooldown(randomTime));

    }

    private void SpawnEnemy(int index)
    {
        Enemy enemy = Instantiate(enemyPrefab,
            spawnPoints[index].transform.position,
            quaternion.identity).GetComponent<Enemy>();
    }
}