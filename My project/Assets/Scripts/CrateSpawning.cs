using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateSpawning : MonoBehaviour
{
    [SerializeField] private float period;
    [SerializeField] private float areaMargin;
    [SerializeField] private float spawnHeight;
    private float timer;
    [SerializeField] private GameObject cratePrefab;

    private void Start()
    {
        InvokeRepeating("SpawnCrate", 0f, period);
        print("adlkua");
    }

    private void SpawnCrate()
    {
        print("yes");
        Instantiate(cratePrefab, new Vector3(Random.Range(-areaMargin, areaMargin), spawnHeight, 0), Quaternion.identity);
    }

}
