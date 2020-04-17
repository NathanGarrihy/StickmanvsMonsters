using System.Collections.Generic;
using UnityEngine;
using Utilities;

//        InvokeRepeating(SPAWN_ENEMY_METHOD, spawnDelay, spawnInterval);

public class PointSpawners : MonoBehaviour
{
    // == private fields ==
    [SerializeField] public Enemy enemyPrefab;
    [SerializeField] public Enemy enemyPrefab2;
    [SerializeField] public ReflectEnemy enemyPrefab3;

    [SerializeField] private float spawnDelay = 0.25f;
    [SerializeField] private float spawnInterval = 0.35f;

    private const string SPAWN_ENEMY_METHOD = "SpawnOneEnemy";

    private IList<SpawnPoint> spawnPoints;

    private Stack<SpawnPoint> spawnStack;

    private GameObject enemyParent;

    //private ListUtils listUtils = new ListUtils();

    // == private methods ==
    // Start is called before the first frame update
    private void Start()
    {
        enemyParent = GameObject.Find("EnemyParent");
        if (!enemyParent)
        {
            enemyParent = new GameObject("EnemyParent");
        }
        // get the spawn points here
        spawnPoints = GetComponentsInChildren<SpawnPoint>();
        SpawnEnemyWaves();
    }

    private void SpawnEnemyWaves()
    {
        // create the stack of points
        spawnStack = ListUtils.CreateShuffledStack(spawnPoints);
        //InvokeRepeating("SpawnOneEnemy", 0f, 0.25f);
        InvokeRepeating(SPAWN_ENEMY_METHOD, spawnDelay, spawnInterval);
    }

    // stack version
    private void SpawnOneEnemy()
    {
        if (spawnStack.Count == 0)
        {
            spawnStack = ListUtils.CreateShuffledStack(spawnPoints);
        }

        // RNG for enemy selection
        int rand = UnityEngine.Random.Range(0, 5);
		//Debug.Log(rand);

        var enemy = new Enemy();
        var reflectEnemy = new ReflectEnemy();
        
        // Instantiates enemy object
        // 50% passive enemy, 50% other enemies
        if (rand == 1)
        {
            enemy = Instantiate(enemyPrefab, enemyParent.transform);
        }
        else if (rand == 2)
        {
            enemy = Instantiate(enemyPrefab2, enemyParent.transform);
        }
        else if (rand == 3)
        {
            enemy = Instantiate(enemyPrefab2, enemyParent.transform);
        }
        else if (rand == 4)
        {
            reflectEnemy = Instantiate(enemyPrefab3, enemyParent.transform);
        }

        var sp = spawnStack.Pop();
        
        // uses selected type of enemy
        if (rand == 1 || rand == 2 || rand == 3)
        {
            enemy.transform.position = sp.transform.position;
        }
        else if (rand == 4)
        {
            reflectEnemy.transform.position = sp.transform.position;
        }
    }
}
