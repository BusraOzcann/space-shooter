using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Health;
    public int scorePoint;

    public List<GameObject> laserPos;
    public GameObject laser;
    public float detechDistance;
    public float speed;
    public float fireTempTime;
    private float fireTimer = -1.0f;  // 3sn de ateþ etsin
    private GameObject Player;
    private float laserTimer = -1.0f;
    private bool fire = false;


    void Start()
    {
        Player = GameObject.FindObjectOfType<Player>().gameObject;
        laserPos = new List<GameObject>();

    }

    // Update is called once per frame
    void Update()
    {        
        if (fire && detechDistance <= GetDistance())
        {
            if (fireTimer <= 0)
            {
                CheckXPos();
            }
            fireTimer -= Time.deltaTime;
        }
    }

    void CheckXPos()
    {
        Vector3 playerPos = Player.transform.position;
        gameObject.transform.position = Vector2.MoveTowards(transform.position, new Vector2(playerPos.x, transform.position.y), speed * Time.deltaTime);
        if (Mathf.Abs(transform.position.x - playerPos.x) <= 0.3f) {
            Fire();
            fireTimer = fireTempTime;
        };
    }

    float GetDistance()
    {
        return (transform.position.y - Player.transform.position.y);
    }

    void Fire()
    {
        laserTimer -= Time.deltaTime;
        if (laserTimer <= 0f)
        {
            for(int i = 0; i < laserPos.Count; i++)
            {
                Instantiate(laser, laserPos[i].transform.position, Quaternion.identity);
            }


            laserTimer = 0.4f;
        }
    }
}
