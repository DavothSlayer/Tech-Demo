using UnityEngine;

public class ItemSpawnFactory : ISpawnFactory
{
    private Transform _spawnParent;
    private GameObject[] _itemPrefabs;

    public ItemSpawnFactory(Transform spawnParent, GameObject[] itemPrefabs)
    {
        _spawnParent = spawnParent;
        _itemPrefabs = itemPrefabs;
    }

    public void Spawn()
    {
        foreach (var prefab in _itemPrefabs)
            GameObject.Instantiate(prefab, GetRandomSpawnPoint(), Quaternion.identity, _spawnParent);
    }

    private Vector3 GetRandomSpawnPoint()
    {
        return new Vector3(Random.Range(-10f, 10f), 0f, Random.Range(-10f, 10f));
    }
}
