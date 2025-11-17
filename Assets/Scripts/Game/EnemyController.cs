using System;
using UnityEngine;
using UnityEngine.Pool;

public class EnemyManager : MonoBehaviour
{
    const int enemyCount = 1000;

    [SerializeField]
    private Enemy _enemyPrefab;
    [SerializeField]
    private Transform _enemyParent;
    [SerializeField]
    public Collider2D spawnArea;

    protected ObjectPool<Enemy> enemyPool;

    private void Start()
    {
        enemyPool = new ObjectPool<Enemy>(
            createFunc: () => CreateNewEnemy(),
            actionOnGet: (enemy) => SetEnemy(enemy),
            actionOnRelease: (enemy) => enemy.OnRelease(),
            actionOnDestroy: (enemy) => Destroy(enemy.gameObject),
            collectionCheck: false,
            defaultCapacity: 10,
            maxSize: 1000
        );
        SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        do
        {
            Enemy enemy = enemyPool.Get();
        }
        while (enemyCount > enemyPool.CountActive);
    }

    private void SetEnemy(Enemy enemy)
    {
        enemy.transform.position = GetRandomPositionInCollider(spawnArea);
        enemy.OnActive();
    }

    private Vector3 GetRandomPositionInCollider(Collider2D collider)
    {
        Bounds bounds = collider.bounds;
        Vector3 min = bounds.min;
        Vector3 max = bounds.max;

        Vector3 randomPoint;
        int maxAttempts = 10;
        int attempts = 0;

        do
        {
            float x = UnityEngine.Random.Range(min.x, max.x);
            float y = UnityEngine.Random.Range(min.y, max.y);
            randomPoint = new Vector3(x, y);
            attempts++;
        }
        while (!collider.bounds.Contains(randomPoint) && attempts < maxAttempts);

        return collider.ClosestPoint(randomPoint);
    }

    private Enemy CreateNewEnemy()
    {
        Enemy enemy = Instantiate(_enemyPrefab, _enemyParent);
        SetEnemy(enemy);
        return enemy;
    }
}
