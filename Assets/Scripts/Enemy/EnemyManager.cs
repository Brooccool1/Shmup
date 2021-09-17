using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemyPrefab;
    [SerializeField] private GameObject _player;

    [SerializeField] private float _spawnDelay = 1;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("_spawnEnemy", _spawnDelay, Random.Range(10, 15));
    }

    private void _spawnEnemy()
    {
        if (_player)
        {
            int temp = Random.Range(0, _enemyPrefab.Length);
            Instantiate(_enemyPrefab[temp], transform.position, Quaternion.identity).GetComponent<BaseEnemy>().Player = _player;
        }
    }
}
