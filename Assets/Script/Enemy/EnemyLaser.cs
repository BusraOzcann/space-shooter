using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaser : MonoBehaviour
{
    public Sprite hitSprite;
    public float damage = 20f;

    public float speed;

    void Start()
    {

    }

    void Update()
    {
        if (GameManager.Instance.state == GameState.Play) Move();
    }

    private void Move()
    {
        transform.position -= new Vector3(0, speed * Time.deltaTime, 0);

        if (transform.position.y >= GameManager.Instance.screenBounds.y || transform.position.y <= (GameManager.Instance.screenBounds.y * -1))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = hitSprite;
        if (collision.gameObject.GetComponent<Player>())
        {
            speed = 0;
            collision.gameObject.GetComponent<Player>().health -= damage;
        }
    }
}
