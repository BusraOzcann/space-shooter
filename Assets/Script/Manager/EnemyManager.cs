using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public float enemyDistance;
    public GameObject createdPrefab;
    public int createdPrefabCounter;
    [HideInInspector] public float enemyRespawnTime;
    [HideInInspector] public float tempRespawnTime;

    [Header("Enemy Prefabs")]
    public List<GameObject> Juniors;
    public List<GameObject> Mids;
    public List<GameObject> Seniors;

    [Header("Enemy Prefab Changes")]
    public float juniorChange;
    public float midsChange;
    public float seniorChange;

    private void Start()
    {
        enemyRespawnTime = 1.5f;
        tempRespawnTime = enemyRespawnTime;
    }

    void Update()
    {
        if(GameManager.Instance.state == GameState.Play)
        {
            if (enemyRespawnTime <= 0)
            {
                CreateEnemie();
                enemyRespawnTime = tempRespawnTime;
            }
            enemyRespawnTime -= Time.deltaTime;
        }
        
    }

    public void ChangeRespawnTime( float val)
    {
        tempRespawnTime = val;
    }

    public void CreateEnemie()
    {
        GameObject prefab = GetRandomPrefab();
        float xPos = RandomXPos(prefab);
        float yPos = CalcYPos();
        createdPrefab = Instantiate(prefab);
        createdPrefab.transform.position = new Vector3(xPos, yPos, 0);
    }

    private GameObject GetRandomPrefab()
    {
        if(GameManager.Instance.playerScore < 20){
            return Juniors[Random.Range(0, Juniors.Count)];
        }
        else if (GameManager.Instance.playerScore < 40)
        {
            return Mids[Random.Range(0, Mids.Count)];
        }
        return Seniors[Random.Range(0, Seniors.Count)];
    }

    private float RandomXPos(GameObject prefab)
    {
        float x = Random.Range(GameManager.Instance.screenBounds.x - prefab.transform.localScale.x/2, (GameManager.Instance.screenBounds.x * -1) + prefab.transform.localScale.x / 2);
        if(createdPrefab != null)
        {
            if(Mathf.Abs(createdPrefab.transform.position.x - x) < 2f)
            {
                return RandomXPos(prefab);
            }
        }
        return x;
    }

    private float CalcYPos()
    {
        return GameManager.Instance.screenBounds.y + enemyDistance;
    }
}
