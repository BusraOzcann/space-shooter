using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float health;
    public float collisionDamage;

    void Start()
    {
        
    }

    void Update()
    {
       if(GameManager.Instance.state == GameState.Play)
        {
            UIManager.UIInstance.ChangePlayerHealth(health.ToString());
            if (health <= 0)
            {
                UIManager.UIInstance.EndGame();
            }
        } 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>())
        {
            health -= collision.gameObject.GetComponent<Enemy>().collisionDamage;
        }
        else if (collision.gameObject.GetComponent<Meteor>())
        {
            health -= collision.gameObject.GetComponent<Meteor>().collisionDamage;
        }
    }
}
