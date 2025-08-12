using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private List<CoinSpawnPoint> _spawnPoints;
    [SerializeField] private Coin _prefab;
    [SerializeField] private float _spawnRate = 5f;
    [SerializeField] private int _poolCapacity = 5;
    [SerializeField] private int _poolMaxSize = 5;

    private ObjectPool<Coin> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<Coin>(
            createFunc: () => Instantiate(_prefab),
            actionOnGet: (coin) => ActivateCoin(coin),
            actionOnRelease: (coin) => DeactivateCoin(coin),
            actionOnDestroy: (coin) => Destroy(coin),
            collectionCheck: true,
            defaultCapacity: _poolCapacity,
            maxSize: _poolMaxSize);
    }

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private void ActivateCoin(Coin coin)
    {
        coin.gameObject.SetActive(true);
        coin.Collected += _pool.Release;
    }

    private void DeactivateCoin(Coin coin)
    {
        coin.Collected -= _pool.Release;
        coin.gameObject.SetActive(false);
    }

    private bool TryGetSpawnPoint(out CoinSpawnPoint spawnPoint)
    {
        List<CoinSpawnPoint> availableSpawnPoints = new List<CoinSpawnPoint>();

        foreach (CoinSpawnPoint point in _spawnPoints)
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
            if (TryGetSpawnPoint(out CoinSpawnPoint spawnPoint))
            {
                _pool.Get().transform.position = spawnPoint.transform.position;
            }

            yield return delay;
        }
    }
}
