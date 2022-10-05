using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public float Health;
    public int scorePoint;
    public int collisionDamage;

    void Start()
    {
        
    }

    void Update()
    {
        if (GameManager.Instance.state == GameState.Play)
        {
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Laser laser = collision.GetComponent<Laser>();
        if (laser != null)
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
