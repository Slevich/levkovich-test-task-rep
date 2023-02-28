using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    #region Поля
    [Header("Layer mask 'Obstacle'")]
    [SerializeField] private LayerMask obstacleMask;
    [Header("Box collider of ground plane")]
    [SerializeField] private BoxCollider groundCollider;
    [Header("Game object prefab with simple coin")]
    [SerializeField] private GameObject simpleCoinPrefab;
    [Header("Game object prefab with red coin")]
    [SerializeField] private GameObject redCoinPrefab;
    [Header("Count of all coins on level")]
    [SerializeField] private int simpleCoinsSpawnCount;
    [SerializeField] private int redCoinsSpawnCount;
    [Header("The number by which the z-coordinate of the coin spawn increases.")]
    [SerializeField] private float spawnHeightDifference;
    [Header("The radius of the sphere that checks for obstacles.")]
    [SerializeField] private float checkRadius;

    private int maxFalseIterations = 10;
    #endregion

    #region Свойства
    //Свойство для доступа к триггеру монетки.
    private CapsuleCollider coinColldier => simpleCoinPrefab.GetComponent<CapsuleCollider>();
    //Свойства для получения значений полей.
    public int SimpleCoinsCount => simpleCoinsSpawnCount;
    public int RedCoinsCount => redCoinsSpawnCount;
    #endregion

    #region Методы
    private void OnValidate()
    {
        if (simpleCoinsSpawnCount < 1) simpleCoinsSpawnCount = 1;

        if (redCoinsSpawnCount < 1) redCoinsSpawnCount = 1;

        if (spawnHeightDifference < 0) spawnHeightDifference = 0;

        if (checkRadius < 0) checkRadius = 0;
    }

    //В Awake спавним монетки.
    private void Awake()
    {
        SpawnCoins(simpleCoinPrefab, simpleCoinsSpawnCount);
        SpawnCoins(redCoinPrefab, redCoinsSpawnCount);
    }

    //Метод генерирует рандомную точку на объекте земли.
    private Vector3 GenerateSpawnPoint()
    {
        float xCoordinate = Random.Range(groundCollider.transform.position.x - groundCollider.bounds.extents.x, 
                                         groundCollider.transform.position.x + groundCollider.bounds.extents.x);
        float zCoordinate = Random.Range(groundCollider.transform.position.z - groundCollider.bounds.extents.z,
                                         groundCollider.transform.position.z + groundCollider.bounds.extents.z);

        return new Vector3(xCoordinate, groundCollider.transform.position.y + spawnHeightDifference, zCoordinate);
    }

    /* Метод проверяет, не занята ли точка препятствием. Если нет - спавнит монетку.
     * При этом, метод проверяет, если пустых итераций больше 10, уменьшает радиус проверки вдвое.
     */
    private void SpawnCoins(GameObject coinPrefab, int coinCount)
    {
        int errorIterations = 0;

        for (int i = 0; i < coinCount; )
        {
            Vector3 spawnCoordinates = GenerateSpawnPoint();

            if (CanSpawnAtPosition(spawnCoordinates))
            {
                GameObject newCoin = Instantiate(coinPrefab, spawnCoordinates, Quaternion.identity);
                i++;
                errorIterations = 0;
            }
            else
            {
                errorIterations++;
                if(errorIterations > maxFalseIterations) checkRadius /= 2;
                continue;
            }
        }
    }

    //Метод кастует сферу, которая проверяет есть ли в точке преграды.
    private bool CanSpawnAtPosition(Vector3 spawnCoordinates)
    {
        var colliders = Physics.OverlapSphere(spawnCoordinates, checkRadius, obstacleMask);

        if (colliders.Length > 0) return false;
        else return true;
    }
    #endregion
}