using UnityEngine;

public class EnemySpawnFactory : ISpawnFactory
{
    private Transform _spawnParent;
    private GameObject[] _enemyPrefabs;

    public EnemySpawnFactory(Transform spawnParent, GameObject[] enemyPrefabs)
    {
        _spawnParent = spawnParent;
        _enemyPrefabs = enemyPrefabs;
    }

    public void Spawn()
    {
        foreach (var prefab in _enemyPrefabs)
            GameObject.Instantiate(prefab, GetRandomSpawnPoint(), Quaternion.identity, _spawnParent);
    }

    private Vector3 GetRandomSpawnPoint()
    {
        return new Vector3(Random.Range(-10f, 10f), 0f, Random.Range(-10f, 10f));
    }
}
