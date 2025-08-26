using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private List<ItemSpawnPoint> _spawnPoints;
    [SerializeField] private Item _prefab;
    [SerializeField] private float _spawnRate = 5f;
    [SerializeField] private int _poolCapacity = 5;
    [SerializeField] private int _poolMaxSize = 5;

    private ObjectPool<Item> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<Item>(
            createFunc: () => Instantiate(_prefab),
            actionOnGet: (item) => ActivateItem(item),
            actionOnRelease: (item) => DeactivateItem(item),
            actionOnDestroy: (item) => Destroy(item),
            collectionCheck: true,
            defaultCapacity: _poolCapacity,
            maxSize: _poolMaxSize);
    }

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private void ActivateItem(Item item)
    {
        item.gameObject.SetActive(true);
        item.Collected += _pool.Release;
    }

    private void DeactivateItem(Item item)
    {
        item.Collected -= _pool.Release;
        item.gameObject.SetActive(false);
    }

    private bool TryGetSpawnPoint(out ItemSpawnPoint spawnPoint)
    {
        List<ItemSpawnPoint> availableSpawnPoints = new List<ItemSpawnPoint>();

        foreach (ItemSpawnPoint point in _spawnPoints)
        {
            if (point.IsAvailable())
            {
                availableSpawnPoints.Add(point);
            }
        }

        if (availableSpawnPoints.Count > 0)
        {
            spawnPoint = availableSpawnPoints[Random.Range(0, availableSpawnPoints.Count)];
        }
        else
        {
            spawnPoint = null;
        }

        return spawnPoint != null;
    }

    private IEnumerator Spawn()
    {
        WaitForSeconds delay = new WaitForSeconds(_spawnRate);

        while (enabled)
        {
            if (TryGetSpawnPoint(out ItemSpawnPoint spawnPoint))
            {
                _pool.Get().transform.position = spawnPoint.transform.position;
            }

            yield return delay;
        }
    }
}
