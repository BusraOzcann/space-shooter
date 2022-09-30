using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private bool GameStarted = false;

    private float yPosCounter;
    public float enemyDistance;
    public float previousXPos;

    [Header("Enemy Prefabs")]
    public GameObject juniorEnemy;
    public GameObject midEnemy;
    public GameObject seniorEnemy;

    [Header("Rock Prefabs")]
    public List<GameObject> bigMeteor;
    public GameObject mediumMeteor;
    public List<GameObject> smallMeteor;

    public List<GameObject> enemyPool;
    public int juniorEnemyCount;
    public int midEnemyCount;
    public int seniorEnemyCount;
    public int bigRockCount;
    public int midRockCount;
    public int smallRockCount;


    void Start()
    {
        enemyPool = new List<GameObject>();

        //Enemy position
        enemyDistance = 2f;
        yPosCounter = 1;
        previousXPos = 0;
    }

    void Update()
    {
        if (GameManager.Instance.state == GameState.Play && GameStarted == false)
        {
            InsertEnemiesToList();
            GameStarted = true;
        }
    }

    public void InsertEnemiesToList()
    {
        for (int i = 0; i < juniorEnemyCount; i++) enemyPool.Add(juniorEnemy);
        for (int i = 0; i < midEnemyCount; i++) enemyPool.Add(midEnemy);
        for (int i = 0; i < seniorEnemyCount; i++) enemyPool.Add(seniorEnemy);
        for (int i = 0; i < bigRockCount; i++) enemyPool.Add(randomBigMeteor());
        for (int i = 0; i < midRockCount; i++) enemyPool.Add(midEnemy);
        for (int i = 0; i < smallRockCount; i++) enemyPool.Add(randomSmallMeteor());

        RandomizeList();
    }

    GameObject randomBigMeteor() {
        int random = bigMeteor.Count;
        return bigMeteor[Random.Range(0, random)];
    }
    GameObject randomSmallMeteor() {
        int random = smallMeteor.Count;
        return smallMeteor[Random.Range(0, random)];
    }

    public void RandomizeList()
    {

        int n = enemyPool.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            GameObject value = enemyPool[k];
            enemyPool[k] = enemyPool[n];
            enemyPool[n] = value;
        }
        CreateEnemies();
    }

    public void CreateEnemies()
    {
        for (int i = 0; i < enemyPool.Count; i++)
        {
            Vector3 createPos = InstancePosition(i);
            Instantiate(enemyPool[i], createPos, Quaternion.identity);
        }

        InsertEnemiesToList();
    }

    private Vector3 InstancePosition(int index)
    {
        float xPos = Random.Range(GameManager.Instance.screenBounds.x, GameManager.Instance.screenBounds.x * -1);
        if (previousXPos - xPos <= 1.5f) {
            InstancePosition(index);
        }
        else
        {
            yPosCounter++;
        }
            //previousXPos = index == 0 ? enemyPool[0].transform.position.x : enemyPool[index - 1].transform.position.x;
        float yPos = GameManager.Instance.screenBounds.y + (yPosCounter * enemyDistance);
        return new Vector3(xPos, yPos);

    }

}
