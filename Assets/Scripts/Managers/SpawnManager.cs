using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject _enemyContainer;
    [SerializeField]
    private float enemySpawnSpeed = 5f;

    private bool _stopSpawning = false;
    void Start()
    {
        StartCoroutine("SpawnEnemies");
    }

    IEnumerator SpawnEnemies()
    {
        while (!_stopSpawning)
        {
            GameObject newEnemy = Instantiate(_enemyPrefab, transform.position + new Vector3(Random.Range(-10f, 10f), 0, 0), Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(enemySpawnSpeed);
        }
    }

    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }
}
