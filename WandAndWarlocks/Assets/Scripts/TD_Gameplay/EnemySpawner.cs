using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//future feature notes:
/// <summary>
/// current feature is just test, continual flow of enemies spawing at regular interval
/// Next will have spawner spawn enemies according to lists loaded by level with differential load times
/// Spawn interval is a float, give ability for Sara's buff card to slow enemy wave & give you breathing space
/// </summary>
public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 3f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnNext", 0, spawnInterval);
    }

    void SpawnNext()
    {
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
    }
}
