using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [Header("SpawnPoints")]
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private GameObject _enemyPrefab;

    private void Start()
    {
        foreach (Transform t in _spawnPoints)
            GameObject.Instantiate(_enemyPrefab, t.position, Quaternion.identity);
    }
}