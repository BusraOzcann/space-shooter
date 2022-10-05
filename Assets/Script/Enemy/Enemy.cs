using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Health;
    public int collisionDamage;
    public int scorePoint;

    public List<GameObject> laserPos;
    public GameObject Player;
    public GameObject laser;
    public float detechDistance;
    public float speed;
    public float fireTempTime;
    private float fireTimer; 
    private bool fire;
    Vector3 playerPos;

    void Start()
    {
        Player = GameObject.FindObjectOfType<Player>().gameObject;
        fireTimer = -1f;
        fire = false;
    }

    // Update is called once per frame
    void Update()
    {        
        if(GameManager.Instance.state == GameState.Play)
        {
            if(detechDistance <= GetDistance() && GetDistance() > 0)
            {
                if (fireTimer <= 0 && !fire)
                {
                    fire = true;
                    playerPos = Player.transform.position;
                    CheckXPos();
                }
                fireTimer -= Time.deltaTime;
            }

            if(fire)
            {
                CheckXPos();
            }
            

            if (transform.position.y < (GameManager.Instance.screenBounds.y * -1) - 1)
            {
                Destroy(gameObject);
            }

            if (Health <= 0)
            {
                GameManager.Instance.playerScore += scorePoint;
                UIManager.UIInstance.UpdateScoreText(GameManager.Instance.playerScore.ToString());
                Destroy(gameObject);
            }
        }

        if (GameManager.Instance.state == GameState.Score || GameManager.Instance.state == GameState.Score || GameManager.Instance.state == GameState.WaitingPanel)
        {
            Destroy(gameObject);
        }

    }

    void CheckXPos()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(playerPos.x, transform.position.y), speed * Time.deltaTime);
        if (Mathf.Abs(transform.position.x - playerPos.x) <= 0.1f) {
            fireTimer = fireTempTime;
            fire = false;
            Fire();
        };
    }

    float GetDistance()
    {
        return (transform.position.y - Player.transform.position.y);
    }

    void Fire()
    {
        for (int i = 0; i < laserPos.Count; i++)
        {
            Instantiate(laser, laserPos[i].transform.position, laserPos[i].transform.rotation);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Laser laser = collision.GetComponent<Laser>();
        if(laser != null)
        {
            Health -= laser.damage;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            Health -= collision.gameObject.GetComponent<Player>().collisionDamage;
        }
    }

}
