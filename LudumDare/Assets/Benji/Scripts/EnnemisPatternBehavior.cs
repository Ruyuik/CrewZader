using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemisPatternBehavior : MonoBehaviour {

    public List<GameObject> enemy_Nav = new List<GameObject>();
    public List<GameObject> enemy_NavFront = new List<GameObject>();
    public List<GameObject> enemy_NavBack = new List<GameObject>();
    public List<GameObject> enemy_NavSpawn = new List<GameObject>();

    public List<GameObject> enemy_List = new List<GameObject>();

    public List<GameObject> enemy_ListToSpawn = new List<GameObject>();
    public List<GameObject> instantiatedEnemy = new List<GameObject>();

    List<EnemySpawnStats> enemy_Stats = new List<EnemySpawnStats>();

    int waveNum;
    int waveLastNum;
    public int destroyedEnemy;
    public int startPowerInWaves;
    public int powerWaveModif;

    float startWaveTimer;
    public float waveTime = 5;
    float waveTimer;
    bool waveStart;

    float startSpawnTimer;
    public float spawnTime = 2;
    float spawnTimer;
    bool enemySpawned;

    int waveGenState;
    int enemyInd;

    void Start () {
        for (int i = 0; i < transform.GetChild(0).childCount; i++)
        {
            if (transform.GetChild(0).GetChild(i).position.x == 10)
            {
                enemy_NavSpawn.Add(transform.GetChild(0).GetChild(i).gameObject);
            }
        }
        for (int i = 1; i < transform.childCount; i++)
        {
            enemy_Nav.Add(transform.GetChild(i).gameObject);

        }
        for (int i = 0; i < enemy_Nav.Count; i++)
        {
            if (transform.GetChild(i).position.x < 4 && transform.GetChild(i).position.x >= 0)
            {
                enemy_NavFront.Add(transform.GetChild(i).gameObject);
            }
            if (transform.GetChild(i).position.x > 4 && transform.GetChild(i).position.x <= 8)
            {

                enemy_NavBack.Add(transform.GetChild(i).gameObject);

            }
        }


        for (int i = 0; i < enemy_List.Count; i++)
        {
            enemy_Stats.Add(new EnemySpawnStats( enemy_List[i]));
        }

        waveGenState = 1;

        waveNum = 1;
        waveLastNum = waveNum;



        if (startPowerInWaves == 0)
        {
            startPowerInWaves = 3;
        }
        if (powerWaveModif == 0)
        {
            powerWaveModif = startPowerInWaves;
        }

    }

    private void Update()
    {
        if (waveGenState == 0)
        {
            NextWaveTrigger();
        }
        else if (waveGenState == 1)
        {
            StartNewWave();
        }
        else if (waveGenState == 2)
        {
            SetEnemyWaves();
        }
        else if (waveGenState == 3)
        {
            SpawnEnemyWave();
        }
    }


    void CheckDestroyedEnemy()
    {
        for (int i = 0; i < instantiatedEnemy.Count; i++)
        {
            if (instantiatedEnemy[i] == null)
            {
                destroyedEnemy++;
            }
        }
    }
    
    void NextWaveTrigger()
    {
        if (instantiatedEnemy.Count == enemy_ListToSpawn.Count)
        {

            if (destroyedEnemy == instantiatedEnemy.Count)
            {

                waveNum +=1;
                ModifEnemyWaveValues();
            }
        }
    }

    void ModifEnemyWaveValues()
    {
        if (waveNum != waveLastNum)
        {
            if (enemy_Stats[0].spawnPourcent <= 0.25f)
            {
                enemy_Stats[0].spawnPourcent -= 0.03f;
                enemy_Stats[1].spawnPourcent += 0.03f;
                //enemy_Stats[2].spawnPourcent += 0.02f;

            }
            if(waveNum < 10000)
            {
                startPowerInWaves += powerWaveModif;
            }

            waveLastNum = waveNum;
            waveStart = false;
            instantiatedEnemy = new List<GameObject>();
            enemy_ListToSpawn = new List<GameObject>();
            waveGenState = 1;
        }
    }

    void StartNewWave()
    {
        destroyedEnemy = 0;

        if (!waveStart)
        {
            waveStart = true;
            startWaveTimer = Time.time;
        }

        waveTimer = Time.time - startWaveTimer;

        if (waveTimer >= waveTime)
        {
            GetComponent<AudioSource>().Play();
            waveGenState = 2;
        }
    }

    void SetEnemyWaves()
    {
        waveGenState = 3;
        int wavePower = startPowerInWaves;
        int spawnedPower = 0;
        float randomPourcent;
        //int debug = 0;
        enemyInd = 0;

        for (int i = wavePower; i >0; i -= spawnedPower)
        {
            randomPourcent = Random.Range(0f, 1f);
            //debug++;


            if (randomPourcent <= enemy_Stats[0].spawnPourcent)
            {
                if (enemy_Stats[0].powerValue <= i)
                {
                    enemy_ListToSpawn.Add(enemy_Stats[0].enemyShip);
                    spawnedPower = enemy_Stats[0].powerValue;
                }
                else
                {
                    spawnedPower = 0;
                }
            }
            else if (randomPourcent >= 1 - enemy_Stats[1].spawnPourcent)
            //if (randomPourcent >= enemy_Stats[0].spawnPourcent && randomPourcent < enemy_Stats[0].spawnPourcent + enemy_Stats[1].spawnPourcent)
            {
                if (enemy_Stats[1].powerValue <= i)
                {
                    enemy_ListToSpawn.Add(enemy_Stats[1].enemyShip);
                    spawnedPower = enemy_Stats[1].powerValue;
                }
                else
                {
                    spawnedPower = 0;
                }
            }
            //else if (randomPourcent >= 1 - enemy_Stats[2].spawnPourcent)
            //{
            //    if (enemy_Stats[2].powerValue <= i)
            //    {
            //        enemy_ListToSpawn.Add(enemy_Stats[2].enemyShip);
            //        spawnedPower = enemy_Stats[2].powerValue;
            //    }
            //    else
            //    {
            //        spawnedPower = 0;
            //    }
            //}

            //if (debug > 10*wavePower)
            //{
            //    i = 0;
            //}
            

        }


    }

    void SpawnEnemyWave()
    {

        if (instantiatedEnemy.Count != enemy_ListToSpawn.Count)
        {
            if (!enemySpawned)
            {
                enemySpawned = true;
                startSpawnTimer = Time.time;
            }


            spawnTimer = Time.time - startSpawnTimer;

            if (spawnTimer > spawnTime)
            {
                GameObject nextEnemy = Instantiate(enemy_ListToSpawn[enemyInd], enemy_NavSpawn[Random.Range(0, enemy_NavSpawn.Count)].transform.position, Quaternion.identity);
                instantiatedEnemy.Add(nextEnemy);
                enemySpawned = false;
                enemyInd++;
            }
        }
        else {
        waveGenState = 0;
        }

    }


}

public class EnemySpawnStats{

    public GameObject enemyShip;
    public int powerValue;
    public float spawnPourcent;

    public EnemySpawnStats(GameObject my_enemy)
    {
        if (my_enemy.name == "Shooter")
        {
            enemyShip = my_enemy;
            powerValue = 1;
            spawnPourcent = .5f;
        }
        if (my_enemy.name == "Bomber")
        {
            enemyShip = my_enemy;
            powerValue = 2;
            spawnPourcent = 0.5f;
        }
        //if (my_enemy.name == "Lazer")
        //{
        //    enemyShip = my_enemy;
        //    powerValue = 3;
        //    spawnPourcent = 0;
        //}
    }
}