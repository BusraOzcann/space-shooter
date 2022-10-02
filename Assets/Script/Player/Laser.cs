using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public Sprite hitSprite;
    public float damage = 20f;

    public float speed;

    void Start()
    {

    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        if(GameManager.Instance.state == GameState.Play) transform.position += new Vector3(0, speed * Time.deltaTime, 0);

        if (transform.position.y >= GameManager.Instance.screenBounds.y || transform.position.y <= (GameManager.Instance.screenBounds.y * -1))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = hitSprite;
        StartCoroutine(Remove());
    }

    IEnumerator Remove()
    {
        speed = 0;
        yield return new WaitForSeconds(0.25f);
        Destroy(gameObject);
    }

}
